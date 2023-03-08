using System.Globalization;
using Postfix_Calc.TokenClasses;

namespace Postfix_Calc.LexerClass
{
    internal class Lexer
    {
        public Lexer() { }
        public List<Token> tokenize(string src)
        {
            src += " ";
            int cPos = 0;
            int cLine = 0;
            List<Token> curTokens = new List<Token>();
            string tmp = string.Empty;
            foreach (char c in src)
            {
                // if found a Newline indicator count the Line up and reset position in current line
                if (c == '\n')
                {
                    cLine++;
                    cPos = 0;
                }
                else cPos++; // count Position in current line

                if (char.IsDigit(c) || c == '.') tmp += c; // if found a digit or a decimal point add it to the temporary string
                else
                {
                    if (tmp != string.Empty) // if temp string is not empty..
                    {
                        Token Operand = new Token();

                        // check for valid integer
                        if (double.TryParse(tmp, NumberStyles.Any, CultureInfo.InvariantCulture, out var flt))
                        {
                            Operand.Token_Type = TokenTypes.Types.NUMBER;
                            Operand.Value = flt;
                        }
                        else
                        {
                            // throw an Error if its not
                            throw new Exception($"Lexer exception in line {cLine}, pos {cPos}. The Operand-Datatype is not supported.");
                        }
                        // Add the Token to the Lexer output and clear temp string
                        Operand.line = cLine;
                        Operand.pos = cPos;
                        curTokens.Add(Operand);
                        tmp = string.Empty;
                    }

                    if (char.IsWhiteSpace(c)) continue; // skip whitespace since we dont need to check them at this point
                    Token Operator = new Token();

                    // Set Token Type to given Operator found by the Lexer
                    switch (c)
                    {
                        case '+':
                            Operator.Token_Type = TokenTypes.Types.PLUS;
                            break;
                        case '-':
                            Operator.Token_Type = TokenTypes.Types.MINUS;
                            break;
                        case '*':
                            Operator.Token_Type = TokenTypes.Types.MUL;
                            break;
                        case '/':
                            Operator.Token_Type = TokenTypes.Types.DIV;
                            break;
                        case '%':
                            Operator.Token_Type = TokenTypes.Types.MOD;
                            break;
                        case '^':
                            Operator.Token_Type = TokenTypes.Types.EXP;
                            break;
                        case '(':
                            Operator.Token_Type = TokenTypes.Types.LPAREN;
                            break;
                        case ')':
                            Operator.Token_Type = TokenTypes.Types.RPAREN;
                            break;
                    }
                    // finally add the Operator to the Lexer output
                    Operator.Value = c;
                    Operator.line = cLine;
                    Operator.pos = cPos;
                    curTokens.Add(Operator);
                }
            }
            return curTokens;
        }
    }
}
