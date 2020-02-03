using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
/*Implement a program which analyzes and evaluates an input mathematic expression. 
 * For example: (123+2)*4-10+(12*(2+1)+((-12)-2)/10+(-2/(10-(22+13+(-34)))+4))-3*2.
 * Nesting of operators is unlimited. Implement errors handling using exceptions.*/
namespace OPNReverse
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("\nInsert Math Expression: ");

                OPNReverse instance = new OPNReverse();              

                instance.MathExpresion = Console.ReadLine().Replace(" ", string.Empty); 
                if (instance.MathExpresion != null)
                {
                    Console.WriteLine("\nResult of your expression is: {0}", +instance.Counting(instance.OPNReverseString(instance.MathExpresion)));
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
}



