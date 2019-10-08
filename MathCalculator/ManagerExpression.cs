using System;
using System.Collections.Generic;

namespace MathCalculator
{
    public static class ManagerExpression
    {
        public static double Control(string operat, Stack<double> stackExpression)
        {
            try
            {
                if (MathOperations.BasicOperators[operat].IsBinary == true)
                {
                    double first, second;

                    if (stackExpression.Count >= 2)
                    {
                        second = stackExpression.Pop();
                        first = stackExpression.Pop();
                    }
                    else
                    {
                        throw new Exception("Expression is not valid!");
                    }

                    switch (operat)
                    {
                        case MathOperations.Plus: return first + second;
                        case MathOperations.BinaryMinus: return first - second;
                        case MathOperations.Multiplication: return first * second;
                        case MathOperations.Division:
                            {
                                if (second == 0) throw new Exception("Cannot be divided by zero");
                                return first / second;
                            };

                        default: throw new Exception("Invalid operator!");
                    }
                }
                else
                {
                    double value;
                    if (stackExpression.Count >= 1)
                    {
                        value = stackExpression.Pop();

                        switch (operat)
                        {
                            case MathOperations.UnaryMinus: return -value;
                            default: throw new Exception("Invalid operator!");
                        }
                    }
                    else
                    {
                        throw new Exception("Expression is not valid!");
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("The given key"))
                {
                    throw new Exception("Invalid operator!");
                }
                else
                {
                    throw ex;
                }
            }
        }
    }
}
