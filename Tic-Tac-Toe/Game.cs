using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossAndNought
{
    class Game
    {
        public Player PlayerO;
        public Player PlayerX;
        public Player CurrentPlayer;
        public Field field;

        // Constructor
        public Game()
        {
            PlayerO = new Player("O");
            PlayerX = new Player("X");
            field = new Field();
            CurrentPlayer = PlayerO; // Player "O" starts by default
        }
        private void changePlayer()
        {
            if (CurrentPlayer.Name == "O")
                CurrentPlayer = PlayerX;
            else CurrentPlayer = PlayerO;
        }

        public void Start()
        {
            int movements = 0;
            bool winner = false;
            field.ShowFields();
            while (!winner && movements < 9)
            {
                //Whose move is now
                Movement move = CurrentPlayer.makeMovement();
                field.fields[move.Xcoord, move.Ycoord] = new Player(CurrentPlayer.Name);

                // Show Board
                field.ShowFields();

                //Check Winning result
                winner = field.CheckWin();
                if (winner)
                {
                    Console.WriteLine("\nWinner is Player {0}!", CurrentPlayer.Name + "\nPress any key to leave the programme");
                    break;
                }

                if (movements == 9 && !winner)
                {
                    Console.WriteLine("Game result is Draw!");
                    break;
                }
                //Change Player
                changePlayer();

                Console.WriteLine(CurrentPlayer.Name + " move:");
                movements++;
            }
        }
    }
}
