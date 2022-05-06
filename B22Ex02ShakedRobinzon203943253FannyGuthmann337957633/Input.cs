using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Input
    {
        public static int numberOfPlayers()
        {
            Boolean validNumberEnter = false;
            int o_numberOfPlayers = 1;
            Console.WriteLine("Welcome to Checkers!");
            while (!validNumberEnter)
            { 
                Console.WriteLine("Please choose number of players: 1/2");
                o_numberOfPlayers = int.Parse(Console.ReadLine());
                if (o_numberOfPlayers == 2)
                {
                    Console.WriteLine("Not supported yet");
                    
                }
                else if (o_numberOfPlayers == 1)
                {
                    validNumberEnter = true;
                } else
                {
                    Console.WriteLine("The number you entered is not valid");
                }
            }
            return o_numberOfPlayers;
        }

        public static int boardSize()
        {
            Boolean validNumberEnter = false;
            int o_boardSize = 0;
            while (!validNumberEnter)
            {
                Console.WriteLine("Please choose board size: 6/8/10");
                o_boardSize = int.Parse(Console.ReadLine());
                if (o_boardSize != 6 && o_boardSize != 8 && o_boardSize != 10)
                {
                    Console.WriteLine("The size you entered is not correct");
                }
                else
                {
                    validNumberEnter = true;
                }
            }
            return o_boardSize;
        }

        public static string getPlayerName()
        {
            Boolean validString = false;
            string playerName = "";
            while (!validString) { 
                Console.WriteLine("Please enter your name");
                playerName = Console.ReadLine();
                if (playerName.Contains(" ") || String.IsNullOrEmpty(playerName))
                {
                    Console.WriteLine("Please enter a name without spaces");
                } else if (playerName.Length > 10)
                {
                    Console.WriteLine("Please enter a name with less than 10 " +
                        "characters");
                }
                else
                {
                    validString = true;
                }
            }
            return playerName;
        }

        //public static string nextMove(string i_move)
        //{
            
        //}
    }
}
