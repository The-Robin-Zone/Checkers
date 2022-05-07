using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Input
    {
        public static int numberOfPlayers()
        {
            bool validNumberEnter = true;
            int intNumOfPlayers = 0;
            string i_numOfPlayers;
            Console.WriteLine("Welcome to Checkers!");

            while (validNumberEnter)
            { 
                Console.WriteLine("Please choose number of players: 1/2");
               
                i_numOfPlayers = Console.ReadLine();
                int.TryParse(i_numOfPlayers, out intNumOfPlayers);

                if (intNumOfPlayers == 1)
                {
                    Console.WriteLine("Not supported yet");
                    
                }
                else if (intNumOfPlayers == 2)
                {
                    validNumberEnter = false;
                } else
                {
                    Console.WriteLine("The number you entered is not valid");
                }
            }
            return intNumOfPlayers;
        }

        public static string getPlayerName(int i_playerNum)
        {
            bool validString = true;
            string playerName = "";

            while (validString)
            {
                Console.WriteLine("Please enter player's " + i_playerNum + " name");
                playerName = Console.ReadLine();

                if (playerName.Contains(" ") || String.IsNullOrEmpty(playerName))
                {
                    Console.WriteLine("Please enter a name without spaces");
                }
                else if (playerName.Length > 10)
                {
                    Console.WriteLine("Please enter a name with less than 10 " +
                        "characters");
                }
                else
                {
                    validString = false;
                }
            }
            return playerName;
        }

        public static int boardSize()
        {
            bool validNumberEnter = true;
            int intBoardSize = 0;
            string i_boardSize;

            while (validNumberEnter)
            {
                Console.WriteLine("Please choose board size: 6/8/10");

                i_boardSize = Console.ReadLine();

                int.TryParse(i_boardSize, out intBoardSize);

                if (intBoardSize != 6 && intBoardSize != 8 && intBoardSize != 10)
                {
                    Console.WriteLine("The size you entered is not correct");
                }
                else
                {
                    validNumberEnter = false;
                }
            }
            return intBoardSize;
        }
    }
}
