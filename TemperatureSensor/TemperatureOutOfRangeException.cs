using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature
{
    class TemperatureOutOfRangeException : Exception
    {
        public void Method()
        {
            Console.WriteLine("Temperature range Exception! 0 >= t <= 100 degrees!");
        }
    }
}
