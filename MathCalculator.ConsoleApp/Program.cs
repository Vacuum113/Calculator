﻿using System;

namespace MathCalculator.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string incomingStr;
            double result;
            while (true)
            {
                try
                {
                    Console.WriteLine("Enter expression");

                    incomingStr = Console.ReadLine();

                    if (string.IsNullOrWhiteSpace(incomingStr))
                    {
                        throw new Exception("String is Empty");
                    }

                    result = new Runner(incomingStr).Run();

                    Console.WriteLine(result);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
