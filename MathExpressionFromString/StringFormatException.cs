using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OPNReverse
{
    public class StringFormatException : Exception
    {
        public bool CheckOperators(string input)
        {
            char[] arr = input.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                if ((arr[i] == '+' | arr[i] == '-' | arr[i] == '*' | arr[i] == '/') && (arr[i + 1] == '+' | arr[i + 1] == '-' | arr[i + 1] == '*' | arr[i + 1] == '/'))
                {
                    // Console.WriteLine("Operators' exception is detected!");
                    return false;
                }
            }
            return true;
        }
        public bool CheckSymbols(string input)
        {
            Regex symbols = new Regex(@"([^0-9\*\-\+\/\(\)])");
            MatchCollection mathexpr = symbols.Matches(input);

            if (mathexpr.Count > 0)
            {
                return false;
            }
            else 
                return true;
        }

        public bool CheckBrackets(string input)
        {
            // Quantityty of brackets
            int numberOfBrackets = 0;

            char[] arr = input.ToCharArray();

            for (int i = 0; i < input.Length; i++)
            {
                if (arr[i] == '(')
                {
                    numberOfBrackets++;
                }
                if (arr[i] == ')')
                {
                    numberOfBrackets--;
                }
                if (numberOfBrackets < 0)
                {
                    //   Console.WriteLine("Brackets' Order exception is detected!");
                    return false;
                }
            }

            if (numberOfBrackets == 0)
            {
                return true;
            }
            else
            {
                //  Console.WriteLine("Brackets' Quantity exception is detected!");
                return false;
            }
        }
    }
}
