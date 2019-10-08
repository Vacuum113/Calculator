using System;
using System.Collections.Generic;
using System.Text;

namespace MathCalculator
{
    /*  
     *  If you need to add a new function, 
     *  then just add a new key and 
     *  value to the dictionary for this function 
     *  and a constant variable.  
     *  And add the operation itself to the switch in the ManagerExpression class,
     *  depending on whether the operation is binary or unary and that's it.  
     */

    public class Operations
    {
        public int Prior { get; set; }
        public bool? IsBinary { get; set; }
        public bool? IsPrefix { get; set; }
    }

    public class MathOperations
    {
        public const string OpenBracket = "(";
        public const string CloseBracket = ")";
        public const string BinaryMinus = "-";
        public const string Plus = "+";
        public const string Division = "/";
        public const string Multiplication = "*";
        public const string UnaryMinus = "~";

        public static Dictionary<string, Operations> BasicOperators = new Dictionary<string, Operations>
        {
            {OpenBracket,    new Operations() { Prior = 0} },
            {CloseBracket,   new Operations() { Prior = 0} },
            {BinaryMinus,    new Operations() { Prior = 1, IsBinary = true} },
            {Plus,           new Operations() { Prior = 1, IsBinary = true} },
            {Division,       new Operations() { Prior = 2, IsBinary = true} },
            {Multiplication, new Operations() { Prior = 2, IsBinary = true} },
            {UnaryMinus,     new Operations() { Prior = 3, IsBinary = false, IsPrefix = true } },
        };
    }
}
