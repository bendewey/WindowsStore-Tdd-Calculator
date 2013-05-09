using System;

namespace App1
{
    public class Calculator
    {
        public decimal Solve(Equation equation)
        {
            decimal left = 0m;
            decimal right = 0m;

            for (var i = 0; i < equation.Tokens.Count; i++)
            {
                var token = equation.Tokens[i];
                if (i == 0 && token.Type == TokenType.Value)
                {
                    left = (decimal)token.Value;
                    continue;
                }

                if (token.Type == TokenType.Operator)
                {
                    var rightToken = equation.Tokens[++i];
                    if (rightToken.Type == TokenType.Value)
                    {
                        right = (decimal)rightToken.Value;
                    }

                    left = Solve(left, right, token.Value.ToString());
                }
            }

            return left;
        }

        private decimal Solve(decimal left, decimal right, string oper)
        {
            if (oper == "+")
            {
                return Add(left, right);
            }
            throw new NotImplementedException();
        }

        private decimal Add(decimal left, decimal right)
        {
            return left + right;
        }
    }
}