using System.Collections.Generic;

namespace App1
{
    public interface IEquationParser
    {
        Equation Parse(string value);
    }

    public class EquationParser : IEquationParser
    {
        public Equation Parse(string value)
        {
            var equation = new Equation()
                {
                    Tokens = new List<Token>()
                };

            if (value == null)
                return equation;

            var current = "";
            var currentType = TokenType.None;
            Token currentToken = null;
            for (int i = 0; i < value.Length; i++)
            {
                var item = value[i];
                var type = GetTokenType(item);

                if (type != currentType)
                {
                    // add
                    if (currentToken != null)
                    {
                        if (currentToken.Type == TokenType.Value)
                        {
                            currentToken.Value = decimal.Parse(current);
                        }
                        else
                        {
                            currentToken.Value = current;
                        }
                        equation.Tokens.Add(currentToken);
                    }

                    currentToken = new Token();
                    currentToken.Type = type;
                    current = item.ToString();
                }
                else
                {
                    current += item;
                }
            }

            if (currentToken != null)
            {
                if (currentToken.Type == TokenType.Value)
                {
                    currentToken.Value = decimal.Parse(current);
                }
                else
                {
                    currentToken.Value = current;
                }
                equation.Tokens.Add(currentToken);
            }

            return equation;
        }

        private TokenType GetTokenType(char item)
        {
            int i;
            if (int.TryParse(item.ToString(), out i))
            {
                return TokenType.Value;
            }
            return TokenType.Operator;
        }
    }
}