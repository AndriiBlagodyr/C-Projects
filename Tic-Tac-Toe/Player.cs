using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossAndNought
{
    class Player
    {
        public string Name { get; set; }       

        public Player(string playerName)
        {
            Name = playerName;         
        }
        static string check = string.Empty;
        public Movement makeMovement()
        {
        Label1:
            Console.WriteLine("\nChoose section adress to make your move (example 00, 12 etc.):");
            
            string section = Console.ReadLine();
            switch (section)
            {
                case "00":
                case "01":
                case "02":
                case "10":
                case "11":
                case "12":
                case "20":
                case "21":
                case "22":
                    break;
                default:
                    Console.WriteLine("Icorrect section id/format.");
                    Console.WriteLine("Please insert section adress again:");
                    goto Label1;
            }
            if (check.Contains(section))
            {
                Console.WriteLine("The section is already inserted");
                goto Label1;
            }
            check += (section + " ");
            Movement move = new Movement();
            move.Xcoord = Convert.ToInt32(section) / 10;
            move.Ycoord = (Convert.ToInt32(section)) % 10;
            return move;
        }
    }
}
