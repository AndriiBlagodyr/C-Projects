using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossAndNought
{
    class Field
    {
        public Player[,] fields { get; set; }

        // Constructor
        public Field()
        {
            fields = new Player[3, 3];
            for (int i = 0; i < 3; ++i)
            {
                for (int j = 0; j < 3; ++j)
                {
                    fields[i, j] = new Player("-");
                }
            }
        }

        public bool CheckWin()
        {
            if ((fields[0, 0].Name == fields[0, 1].Name & fields[0, 1].Name == fields[0, 2].Name & fields[0, 2].Name != "-") |
                 (fields[1, 0].Name == fields[1, 1].Name & fields[1, 1].Name == fields[1, 2].Name & fields[1, 2].Name != "-") |
                 (fields[2, 0].Name == fields[2, 1].Name & fields[2, 1].Name == fields[2, 2].Name & fields[2, 2].Name != "-") |
                 (fields[0, 0].Name == fields[1, 0].Name & fields[1, 0].Name == fields[2, 0].Name & fields[2, 0].Name != "-") |
                 (fields[0, 1].Name == fields[1, 1].Name & fields[1, 1].Name == fields[2, 1].Name & fields[2, 1].Name != "-") |
                 (fields[0, 2].Name == fields[1, 2].Name & fields[1, 2].Name == fields[2, 2].Name & fields[2, 2].Name != "-") |
                 (fields[0, 0].Name == fields[1, 1].Name & fields[1, 1].Name == fields[2, 2].Name & fields[2, 2].Name != "-") |
                 (fields[0, 2].Name == fields[1, 1].Name & fields[1, 1].Name == fields[2, 0].Name & fields[2, 0].Name != "-"))
            {
                return true;
            }
            return false;
        }
        public void ShowFields()
        {
            Console.Clear();
            Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.Green;
            for (int i = 0; i < 3; i++)
            {
                Console.Write(" {0} ", i);
            }
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("{0}", i);
            }
            for (int i = 0; i < 3; ++i)
            {
                Console.SetCursorPosition(2, i + 1);
                for (int j = 0; j < 3; ++j)
                {
                    Console.Write(fields[i, j].Name + "  ");
                }
                Console.Write("\n");
            }
        }
    }
}
