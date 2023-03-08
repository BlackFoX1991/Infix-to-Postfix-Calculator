namespace Postfix_Calc.TokenClasses
{
    /// <summary>
    /// Token Class which includes Information for the given Token
    /// </summary>
    internal class Token
    {
        public TokenTypes.Types Token_Type { get; set; } = TokenTypes.Types.NULL;
        public object Value { get; set; } = null!;
        public int line { get; set; } = -1;
        public int pos { get; set; } = -1;
    }
}
