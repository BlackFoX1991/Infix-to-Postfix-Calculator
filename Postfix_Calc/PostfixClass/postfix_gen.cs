using Postfix_Calc.TokenClasses;
namespace Postfix_Calc.PostfixClass
{
    internal class postfix_gen
    {

        // Precedences of the Operators
        readonly Dictionary<TokenTypes.Types, int> preds = new Dictionary<TokenTypes.Types, int>()
        {
            {TokenTypes.Types.LPAREN , 0 },
            {TokenTypes.Types.PLUS , 1 },
            {TokenTypes.Types.MINUS , 1 },

            {TokenTypes.Types.MUL , 2 },
            {TokenTypes.Types.DIV , 2 },
            {TokenTypes.Types.MOD, 2 },

            {TokenTypes.Types.EXP , 3 },
        };
        public postfix_gen()
        {
        }
        public double evaluatePostfix(List<Token> postfix)
        {
            Stack<double> Operands = new Stack<double>();
            double left = 0;
            double right = 0;
            double EndErgebnis = 0;
            foreach (Token t in postfix)
            {
                // if its a Number, push it to the Operand Stack
                if (t.Token_Type == TokenTypes.Types.NUMBER)
                {
                    Operands.Push((double)t.Value);
                }
                else
                {
                    // Get Operand for left and right
                    left = Operands.Pop();
                    right = Operands.Pop();

                    // Check Operation Type
                    switch (t.Token_Type)
                    {
                        case TokenTypes.Types.PLUS:
                            EndErgebnis = left + right;
                            break;
                        case TokenTypes.Types.MINUS:
                            EndErgebnis = left - right;
                            break;
                        case TokenTypes.Types.MUL:
                            EndErgebnis = left * right;
                            break;
                        case TokenTypes.Types.DIV:
                            EndErgebnis = left / right;
                            break;
                        case TokenTypes.Types.MOD:
                            EndErgebnis = left % right;
                            break;
                        case TokenTypes.Types.EXP:
                            EndErgebnis = (long)left ^ (long)right;
                            break;
                    }
                    // Push the new Value to the Stack
                    Operands.Push(EndErgebnis);
                }
            }
            // Return the Result
            return EndErgebnis;
        }
        public List<Token> ToPostfix(List<Token> LexerInfix)
        {
            List<Token> lexList = LexerInfix;
            List<Token> postfix = new List<Token>();
            Stack<Token> Operators = new Stack<Token>();

            foreach (Token t in lexList)
            {
                if (t.Token_Type == TokenTypes.Types.NUMBER)
                {
                    postfix.Add(t);
                }
                else if (t.Token_Type == TokenTypes.Types.LPAREN)
                {
                    Operators.Push(t);
                }
                else if (t.Token_Type == TokenTypes.Types.RPAREN)
                {
                    while (Operators.Peek().Token_Type != TokenTypes.Types.LPAREN)
                    {
                        postfix.Add(Operators.Pop());
                    }
                    Operators.Pop();
                }
                else
                {
                    while (Operators.Count != 0 &&
                        preds[t.Token_Type] <= preds[Operators.Peek().Token_Type])
                    {
                        postfix.Add(Operators.Pop());
                    }
                    Operators.Push(t);
                }
            }
            while (Operators.Count != 0) postfix.Add(Operators.Pop());
            return postfix;
        }

    }
}
