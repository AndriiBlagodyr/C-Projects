using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
   public class BigIntegerValue
    {
       public int [] arrayValues;

        public BigIntegerValue(string text)
        {
            text = text.TrimStart('0');

            arrayValues = new int[text.Length];

            for (int i = 0; i < text.Length; i++)
                arrayValues[i] = text[i] - '0';            
           
            Array.Reverse(arrayValues);            
        }
       
    }
}
