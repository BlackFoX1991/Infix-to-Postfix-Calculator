namespace Postfix_Calc.TokenClasses
{
    internal class TokenTypes
    {
        /// <summary>
        /// Currently available Token-Types for Lexer and further Usage
        /// </summary>
        public enum Types
        {
            NULL,
            NUMBER,
            VARIABLE,
            LPAREN,
            RPAREN,
            PLUS,
            MINUS,
            MUL,
            MOD,
            DIV,
            EXP
        }
    }
}
