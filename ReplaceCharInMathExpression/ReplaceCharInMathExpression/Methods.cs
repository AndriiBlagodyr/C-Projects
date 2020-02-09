using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ReChangeMathOperators
{
    public class Methods
    {
        public static List<string> Combinations(int val)
        {
            string[] operators = { "+", "-", "*", "/" };

            int[] array = new int[val];

            int capacity = (int)Math.Pow(operators.Length, array.Length);

            List<string> collection = new List<string>(capacity);

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = 0;
            }

            while (true)
            {
                string y = null;
                for (int z = 0; z < array.Length; z++)
                {
                    y += operators[array[z]];  // replace 0,1,2... for  '+','-','*'...
                }
                collection.Add(y); // Add collection element

                int i = array.Length - 1;

                for (; i >= 0; i--)
                {
                    array[i] += 1;

                    if (array[i] == operators.Length)
                    {
                        array[i] = 0;
                    }

                    else
                    {
                        break;
                    }
                }

                if (i < 0)
                {
                    break;
                }
            }

            return collection;
        }

        public ArrayList OPNReverseString(string input)
        {
            Regex patern = new Regex(@"\(\-\d+\)|\(|\)|\+|\-|\*|\/|(\d+\.?\d*)|()");
            Regex numbers = new Regex(@"\d+\.?\d*"); // numbers
            Regex minnumbers = new Regex(@"\(\-\d+\)"); // - min numbers
            Regex brackets = new Regex(@"\(|\)"); // brackets
            Regex operators = new Regex(@"\(|\)|\+|\-|\*|\/"); // operators     
            Stack stackOpers = new Stack();
            ArrayList expression = new ArrayList();

            MatchCollection mathexpr = patern.Matches(input);

            foreach (Match value in mathexpr)
            {
                Match val;
                val = minnumbers.Match(value.Value);
                if (val.Success)
                {
                    string s = String.Empty;
                    s = val.Value.Substring(1, val.Value.Length - 2);
                    expression.Add(s); continue;
                }
                val = numbers.Match(value.Value);
                if (val.Success) { expression.Add(val.Value); continue; }
                val = brackets.Match(value.Value);
                if (val.Success)
                {
                    if (val.Value == "(") { stackOpers.Push(val.Value); continue; }
                    string op = stackOpers.Pop().ToString();
                    while (op != "(")
                    {
                        expression.Add(op);
                        op = stackOpers.Pop().ToString();
                    }
                    continue;
                }
                val = operators.Match(value.Value);
                if (val.Success)
                {
                    try
                    {
                        while (GetPriority(val.Value) <= GetPriority((string)stackOpers.Peek()))
                        {
                            if (stackOpers.Peek().ToString() == "(") break;
                            expression.Add(stackOpers.Pop().ToString());
                        }
                    }
                    catch (System.Exception)
                    {
                        // Empty stack exception
                    }
                    stackOpers.Push(val.Value);
                }
            }
            while (stackOpers.Count != 0)
            {
                expression.Add(stackOpers.Pop().ToString());
            }
            return expression;
        }

        //Method of operator's priority
        public static byte GetPriority(string s)
        {
            switch (s)
            {
                case "(": return 0;
                case ")": return 0;
                case "+": return 1;
                case "-": return 1;
                case "*": return 2;
                case "/": return 2;
                default: return 7;
            }
        }

        // Counting result from OPN method
        public double Counting(ArrayList expression)
        {
            double result = 0; //Result
            Stack<double> temp = new Stack<double>(); //Temporary stack

            string[] array = new string[expression.Count];

            for (int i = 0; i < expression.Count; i++)
            {
                array[i] = (string)expression[i];
            }

            Regex numbers = new Regex(@"^\d+$"); // numbers
            Regex numbers1 = new Regex(@"^-[0-9]*[1-9][0-9]*$"); // min numbers
            Regex operators = new Regex(@"\(|\)|\+|\-|\*|\/"); // operators

            for (int i = 0; i < expression.Count; i++)
            {
                if (numbers1.IsMatch(array[i]) | numbers.IsMatch(array[i])) // Check if value is equal to operands
                {
                    temp.Push(double.Parse(array[i]));
                }
                else if (operators.IsMatch(array[i])) // Check if value is equal to operators
                {
                    try
                    {
                        double a = temp.Pop();
                        double b = temp.Pop();
                        if (a == 0 & array[i] == "/")
                        {
                            try
                            {
                                //Console.WriteLine("Devide by zero exseption is detected");
                                throw new DivideByZeroException();
                            }
                            catch (DivideByZeroException)
                            {

                                return -1.157;  // DivideByZeroException
                            }
                        }
                        switch (array[i])
                        {
                            case "+": result = b + a; break;
                            case "-": result = b - a; break;
                            case "*": result = b * a; break;
                            case "/": result = b / a; break;
                        }
                    }
                    catch
                    {
                        // Empty stack exception
                    }
                    temp.Push(result);
                }
            }
            return temp.Peek();
        }
    }

}
