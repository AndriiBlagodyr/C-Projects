using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OPNReverse
{
    class OPNReverse : StringFormatException
    {
        private string mathExpresion;

        public OPNReverse()
        {
        }

        public string MathExpresion
        {
            set
            {
                if (CheckOperators(value))
                {
                    if (CheckBrackets(value))
                    {
                        if (CheckSymbols(value))
                        {
                            this.mathExpresion = value;
                        }
                        else
                        {
                            try
                            {
                                throw new StringFormatException();
                            }
                            catch (StringFormatException e)
                            {
                                Console.WriteLine("Incorrect symbol exception is detected!");
                               // Console.WriteLine(e.Message);
                                this.mathExpresion = null;
                            }
                        }
                    }
                    else
                    {
                        try
                        {
                            throw new StringFormatException();
                        }
                        catch (StringFormatException e)
                        {
                            Console.WriteLine("Brackets' Order/Quantity exception is detected!");
                           // Console.WriteLine(e.Message);
                            this.mathExpresion = null;
                        }
                    }
                }
                else
                {
                    try
                    {
                        throw new StringFormatException();
                    }
                    catch (StringFormatException e)
                    {
                        Console.WriteLine("Operators' exception is detected!");
                      //  Console.WriteLine(e.Message);
                        this.mathExpresion = null;
                    }
                }
            }
            get
            {
                return mathExpresion;
            }
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
                        if (GetPriority(val.Value) <= GetPriority((string)stackOpers.Peek()))
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
            Console.WriteLine("OPN of your string is: ");
            foreach (string s in expression)
            {
                Console.Write(s + " ");
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
                            catch (DivideByZeroException e)
                            {
                                Console.WriteLine("\n" + e.Message);
                                return 0;
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
            Console.ForegroundColor = ConsoleColor.Blue;
            return temp.Peek();
        }

    }
}
