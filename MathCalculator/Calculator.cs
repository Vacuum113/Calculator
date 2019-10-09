using System;
using System.Collections.Generic;

namespace MathCalculator
{
    public class Calculator
    {
        public double Calculation(List<string> listStringToCalculate)
        {
            Stack<double> stackResult = new Stack<double>();

            foreach (string value in listStringToCalculate)
            {
                double outParse;

                stackResult.Push(double.TryParse(value, out outParse) ? outParse : ManagerExpression.Control(value, stackResult));
            }

            if (stackResult.Count == 1)
            {
                return stackResult.Pop();
            }
            else
            {
                throw new Exception("Expression is not valid!");
            }
        }
    }
}
