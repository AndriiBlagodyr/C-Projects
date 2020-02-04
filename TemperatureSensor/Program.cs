using System;
/*Implement a program which uses events, delegates and exception handling. 
 * For example, temperature sensor and several listeners. 
 * Create a TemperatureChanged event on the sensor level and subscribe to it listeners.
 * Custom exceptions should be thrown (and handled) by listeners in case if temperature less than 0 or greater than 100 degrees */
namespace Temperature
{

    public delegate void TemperatureValue();

    class Program
    {
        static void Main()
        {
            TemperatureSensor temperature = new TemperatureSensor();

            temperature.TempValue = 88;            
            
            temperature.SetTempVal += delegate { Console.WriteLine("Temperature value is {0} degrees!", temperature.TempValue); };

            Console.ForegroundColor = ConsoleColor.Green;
            temperature.InvokeSetTempVal();

            Console.ReadKey();
        }
    }
}
