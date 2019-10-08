using System;
using System.Collections.Generic;

namespace MathCalculator
{
    public class ConvertToPostfixNotation
    {
        bool isCloseBracketFound = true;
        bool isOpenBracketFound = false;
        private List<string> _convertedString;
        private Stack<string> _operationStack;
        private List<string> _stringToConvert;
        private Dictionary<string, Operations> _basicOperators;

        private void WhileNotFoundOpeneBracket()
        {
            isCloseBracketFound = true;
            while (_operationStack.Count != 0)
            {
                if (_operationStack.Peek().Equals(MathOperations.OpenBracket))
                {
                    isOpenBracketFound = true;
                    _operationStack.Pop();
                    break;
                }
                _convertedString.Add(_operationStack.Pop());
            }

            if (!isOpenBracketFound)
            {
                throw new Exception("Open bracket not found!");
            }
        }

        private void OperatorOperations(int i)
        {
            while (_operationStack.Count != 0)
            {
                if (_basicOperators[_operationStack.Peek()].IsPrefix == true ||
                     _basicOperators[_operationStack.Peek()].Prior >= _basicOperators[_stringToConvert[i]].Prior)
                {
                    _convertedString.Add(_operationStack.Pop());
                }
                else
                    break;
            }
        }

        public ConvertToPostfixNotation(List<string> stringToConvert)
        {
            _convertedString = new List<string>();
            _operationStack = new Stack<string>();
            _stringToConvert = stringToConvert;
            _basicOperators = MathOperations.BasicOperators;
        }

        //  Algorithm of translation in RPN.
        public List<string> Convert()
        {
            for (int i = 0; i < _stringToConvert.Count; i++)
            {
                if (_basicOperators.ContainsKey(_stringToConvert[i]))
                {
                    if (_basicOperators[_stringToConvert[i]].IsPrefix == true)
                    {
                        _operationStack.Push(_stringToConvert[i]);
                        continue;
                    }

                    if (_stringToConvert[i].Equals(MathOperations.OpenBracket))
                    {
                        isCloseBracketFound = false;
                        _operationStack.Push(_stringToConvert[i]);
                        continue;
                    }

                    if (_stringToConvert[i].Equals(MathOperations.CloseBracket))
                    {
                        WhileNotFoundOpeneBracket();
                        continue;
                    }

                    if (_basicOperators[_stringToConvert[i]].IsBinary == true)
                    {
                        OperatorOperations(i);
                    }
                    _operationStack.Push(_stringToConvert[i]);
                }
                else
                {
                    if (_stringToConvert[i] != "" && _stringToConvert[i] != " ")
                    {
                        _convertedString.Add(_stringToConvert[i]);
                    }
                    else
                        continue;
                }
            }
            while (_operationStack.Count != 0)
            {
                _convertedString.Add(_operationStack.Pop());
            }
            if (!isCloseBracketFound)
            {
                throw new Exception("Close bracket not found!");
            }
            return _convertedString;
        }

    }
}
