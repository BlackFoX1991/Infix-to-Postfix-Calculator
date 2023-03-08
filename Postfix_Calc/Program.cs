// See https://aka.ms/new-console-template for more information
using Postfix_Calc.LexerClass;
using Postfix_Calc.PostfixClass;
using Postfix_Calc.TokenClasses;

string expr = "2+(3*1%(8+0.5))";


// Testing the Lexer
Lexer Test = new Lexer();
List<Token> TST = Test.tokenize(expr); // Tokenize to TST
Console.WriteLine("LEXER :");
foreach (Token t in TST) Console.WriteLine(t.Value + " -> " + t.Token_Type.ToString());
Console.WriteLine("");


// Generate Postfix Expression out of Tokens given from the Lexer above
postfix_gen tb = new postfix_gen();
List<Token> sExpr = tb.ToPostfix(TST); // Pass TST to Postfix Generator
Console.WriteLine("POSTFIX:");
foreach (Token pf in sExpr) Console.Write($"{pf.Value.ToString()} ");
Console.WriteLine("");

// Evaluate the given Postfix Expression
Console.WriteLine(tb.evaluatePostfix(sExpr).ToString());

