using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Specialized;


// Replace char '?' in math expresion "20?30?40?10=10?(20?10)" that the left expression part was equal to the right part of expression
namespace ReChangeMathOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Insert math expression:");

                string input = Console.ReadLine();
            //string input = "20?((30?20)?10)=20?20";
           // string input = "20?30?40?10=10?(20?10)";
            // string input = "10?10=40?10?10";

            string[] operators = { "+", "-", "*", "/" };

            input = input.Replace(" ", string.Empty);  // string without space chars

            string left = input.Remove(input.IndexOf("="));
            string right = input.Substring(1 + input.IndexOf("="));

            string[] leftArr = left.Split('?');  // Array consists of elements separeted with char '?'
            string[] rightArr = right.Split('?');

            int leftCounter, rightCounter, leftCapacity, rightCapacity = 0;

            leftCounter = leftArr.Length - 1;       //3 chars '?'    leftArr.Length - 1
            rightCounter = rightArr.Length - 1;     //2 chars '?'    rightArr.Length - 1

            leftCapacity = (int)Math.Pow(operators.Length, leftCounter);  // Quantity of possible combinations. Collection Capacity. Pow(4,3)
            rightCapacity = (int)Math.Pow(operators.Length, rightCounter); // Pow(4,2)


            List<string> leftCol = Methods.Combinations(leftCounter);  // Collection of operators' combinations for one part of the string
            List<string> rightCol = Methods.Combinations(rightCounter);

            NameValueCollection leftname = new NameValueCollection(leftCapacity);  // Collection Key-Value with all available results
            NameValueCollection rightname = new NameValueCollection(rightCapacity);

            for (int i = 0; i < leftCapacity; i++)  // Add elements to leftname Collection
            {
                StringBuilder builder = new StringBuilder();

                for (int j = 0; j < leftCounter; j++)
                {
                    builder.Append(leftArr[j]).Append(((string)leftCol[i])[j]);
                }
                builder.Append(leftArr[leftCounter]);

                string build1 = builder.ToString();

                Methods instance = new Methods();

                string value = instance.Counting(instance.OPNReverseString(build1)).ToString();

                leftname.Add(build1, value);
            }

            for (int i = 0; i < rightCapacity; i++)  // Add elements to rightname Collection
            {
                StringBuilder builder = new StringBuilder();

                for (int j = 0; j < rightCounter; j++)
                {
                    builder.Append(rightArr[j]).Append(((string)rightCol[i])[j]);
                }
                builder.Append(rightArr[rightCounter]);

                string build1 = builder.ToString();

                Methods instance = new Methods();

                string value = instance.Counting(instance.OPNReverseString(build1)).ToString();

                rightname.Add(build1, value);
            }
            bool flag = false;
            for (int i = 0; i < leftname.Count; i++)
            {
                for (int j = 0; j < rightname.Count; j++)
                {
                    if (leftname.Get(i) == rightname.Get(j))
                    {
                        Console.WriteLine(leftname.GetKey(i) + " = " + rightname.GetKey(j) + "     result=" + rightname.Get(j));

                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                Console.WriteLine("No matches is found!");
            }
          }

            
        }
    }
}

