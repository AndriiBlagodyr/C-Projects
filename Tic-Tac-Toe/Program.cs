using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossAndNought
{  
    class Program
    {
        static void Main()
        {
            Game play = new Game();
            play.Start();

            Console.ReadKey();
        }
    }
}
