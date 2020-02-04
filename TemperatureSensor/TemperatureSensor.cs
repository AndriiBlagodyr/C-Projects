using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Temperature
{
    class TemperatureSensor
    {
        // ctor
        public TemperatureSensor() 
        {
        }

        private double tempValue = 0;

        // tempValue Property
        public double TempValue
        {
            // (setter)
            set 
            {
                if (value >= 0 && value <= 100)
                    tempValue = value;
                else
                    try
                    {
                        throw new TemperatureOutOfRangeException();
                    }
                    catch (TemperatureOutOfRangeException myException)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Exception was detected!");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        myException.Method();
                        Console.WriteLine("Exception time is {0}: ", DateTime.Now);
                    }
                    finally
                    {                        
                        Console.WriteLine("Press any key to leave the programme . . .");
                        Console.ReadKey();
                        System.Diagnostics.Process proc = System.Diagnostics.Process.GetCurrentProcess();
                        proc.Kill();
                    }
            }
            // (getter)
            get
            {
                return tempValue;
            }
        }

        // Event
        public event TemperatureValue SetTempVal = null;

        public void InvokeSetTempVal()
        {
            if (SetTempVal != null)
            {
                SetTempVal.Invoke();
            }
        }
    }
}
