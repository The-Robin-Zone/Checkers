using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Input
    {
        public static int NumberOfPlayers()
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


                if (intNumOfPlayers == 2 || intNumOfPlayers == 1)
                {
                    validNumberEnter = false;
                }
                else
                {
                    Console.WriteLine("The number you entered is not valid");
                }
            }
            return intNumOfPlayers;
        }

        public static string GetPlayerName(int i_playerNum)
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

        public static int BoardSize()
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

        public static char ReadChar()
        {
            bool isInputCorrect = true;
            string userInput;
            char userOutput = ' ';

            while (isInputCorrect)
            {
                userInput = Console.ReadLine();

                if (userInput.Length == 1)
                {
                    isInputCorrect = false;
                    userOutput = userInput[0];
                }
                else
                {
                    Output.InvalidInputPrompt();
                }
            }
            
            return userOutput;
        }

        public static string ReadMoveString(Player currPlayerTurn)
        {
            Console.WriteLine(currPlayerTurn.PlayerName + "'s turn (" + currPlayerTurn.Color + "): ");
            string i_playerMove = Console.ReadLine();
            Console.WriteLine();
            return i_playerMove;
        }

        public static bool IsMoveLegal(string i_playerMove)
        {
            bool moveStringIsValid = true;

            if (String.Equals(i_playerMove, "q"))
            {
                GameManager.EndGame();
            }
            if (i_playerMove.Length != 5 || String.Equals(i_playerMove, string.Empty))
            {
                moveStringIsValid = false;
            }
            else if (!char.IsUpper(i_playerMove[0]))
            {
                moveStringIsValid = false;
            }
            else if (!char.IsLower(i_playerMove[1]))
            {
                moveStringIsValid = false;
            }
            else if ('>'.CompareTo(i_playerMove[2]) != 0)
            {
                moveStringIsValid = false;
            }
            else if (!char.IsUpper(i_playerMove[3]))
            {
                moveStringIsValid = false;
            }
            else if (!char.IsLower(i_playerMove[4]))
            {
                moveStringIsValid = false;
            }
            return moveStringIsValid;
        
        }
    }
}
