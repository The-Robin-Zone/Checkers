using System;

namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Input
    {
        public static int NumberOfPlayers()
        {
            bool validNumberEnter = true;
            int o_IntNumOfPlayers = 0;
            string numOfPlayers;

            Console.WriteLine("Welcome to Checkers!");

            while (validNumberEnter)
            { 
                Console.WriteLine("Please choose number of players: 1/2");
               
                numOfPlayers = Console.ReadLine();
                int.TryParse(numOfPlayers, out o_IntNumOfPlayers);

                if (o_IntNumOfPlayers == 2 || o_IntNumOfPlayers == 1)
                {
                    validNumberEnter = false;
                }
                else
                {
                    Console.WriteLine("The number you entered is not valid");
                }
            }

            return o_IntNumOfPlayers;
        }

        public static string GetPlayerName(int i_PlayerNum)
        {
            bool validString = true;
            string o_PlayerName = string.Empty;

            while (validString)
            {
                Console.WriteLine("Please enter player's " + i_PlayerNum + " name");
                o_PlayerName = Console.ReadLine();

                if (o_PlayerName.Contains(" ") || string.IsNullOrEmpty(o_PlayerName))
                {
                    Console.WriteLine("Please enter a name without spaces");
                }
                else if (o_PlayerName.Length > 10)
                {
                    Console.WriteLine("Please enter a name with less than 10 " +
                        "characters");
                }
                else
                {
                    validString = false;
                }
            }

            return o_PlayerName;
        }

        public static int BoardSize()
        {
            bool validNumberEnter = true;
            int o_IntBoardSize = 0;
            string boardSize = string.Empty;

            while (validNumberEnter)
            {
                Console.WriteLine("Please choose board size: 6/8/10");

                boardSize = Console.ReadLine();

                int.TryParse(boardSize, out o_IntBoardSize);

                if (o_IntBoardSize != 6 && o_IntBoardSize != 8 && o_IntBoardSize != 10)
                {
                    Console.WriteLine("The size you entered is not correct");
                }
                else
                {
                    validNumberEnter = false;
                }
            }

            return o_IntBoardSize;
        }

        public static char ReadChar()
        {
            bool isInputCorrect = true;
            string userInput = string.Empty;
            char o_UserOutput = ' ';

            while (isInputCorrect)
            {
                userInput = Console.ReadLine();

                if (userInput.Length == 1)
                {
                    isInputCorrect = false;
                    o_UserOutput = userInput[0];
                }
                else
                {
                    Output.InvalidInputPrompt();
                }
            }
            
            return o_UserOutput;
        }

        public static string ReadMoveString(Player i_CurrPlayerTurn)
        {
            string o_PlayerMove = string.Empty;
            Console.WriteLine(i_CurrPlayerTurn.PlayerName + "'s turn (" + i_CurrPlayerTurn.Color + "): ");
            o_PlayerMove = Console.ReadLine();
            Console.WriteLine();
            return o_PlayerMove;
        }

        public static bool IsMoveLegal(string i_PlayerMove)
        {
            bool o_MoveStringIsValid = true;

            if (string.Equals(i_PlayerMove, "q"))
            {
                GameManager.EndGame();
            }

            if (i_PlayerMove.Length != 5 || string.Equals(i_PlayerMove, string.Empty))
            {
                o_MoveStringIsValid = false;
            }
            else if (!char.IsUpper(i_PlayerMove[0]))
            {
                o_MoveStringIsValid = false;
            }
            else if (!char.IsLower(i_PlayerMove[1]))
            {
                o_MoveStringIsValid = false;
            }
            else if ('>'.CompareTo(i_PlayerMove[2]) != 0)
            {
                o_MoveStringIsValid = false;
            }
            else if (!char.IsUpper(i_PlayerMove[3]))
            {
                o_MoveStringIsValid = false;
            }
            else if (!char.IsLower(i_PlayerMove[4]))
            {
                o_MoveStringIsValid = false;
            }

            return o_MoveStringIsValid;        
        }
    }
}
