using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        private static double calculate(char[] initialExpression)
        {
            double result = 0;
            char lastOperationSymbol = '_';
            for (int i = 0; i < initialExpression.Length; i++)
            {
                if (initialExpression[i] == '+' || initialExpression[i] == '-' || initialExpression[i] == '*')
                {
                    lastOperationSymbol = initialExpression[i];
                }
                else if (char.IsDigit(initialExpression[i]))
                {
                    if (i == 0)
                    {
                        result = initialExpression[i] - '0';
                    }
                    else if (lastOperationSymbol == '+')
                    {
                        result += initialExpression[i] - '0';
                    }
                    else if (lastOperationSymbol == '-')
                    {
                        result -= initialExpression[i] - '0';
                    }
                    else if (lastOperationSymbol == '*')
                    {
                        result *= initialExpression[i] - '0';
                    }
                }
                else if (initialExpression[i] == '(')
                {
                    for (int j = initialExpression.Length - 1; j > i; j--)
                    {
                        if (initialExpression[j] == ')')
                        {
                            var a = calculate(initialExpression.ToList().GetRange(i + 1, j - (i + 1)).ToArray());
                            if (i == 0)
                            {
                                result = a;
                            }
                            else if (lastOperationSymbol == '+')
                            {
                                result += a;
                            }
                            else if (lastOperationSymbol == '-')
                            {
                                result -= a;
                            }
                            else if (lastOperationSymbol == '*')
                            {
                                result *= a;
                            }
                            i = j;
                            break;
                        }
                    }
                }
            }
            return result;
        }
        static void Main(string[] args)
        {
            //    (5*3)+1    //    1+(7*8)*5
            Console.WriteLine(calculate(Console.ReadLine().ToCharArray()));
        }
    }
}
