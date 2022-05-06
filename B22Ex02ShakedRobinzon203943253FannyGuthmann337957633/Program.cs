using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Program
    {
        public static void Main()
        {
            //initializeGame();
            Coin[,] gameBoard = initializeBoard(10);
            Output.Print2DArray(gameBoard,10);
            Console.ReadLine();
            



        }

        public static void initializeGame()
        {
            int numberOfPlayers = Input.numberOfPlayers();
            string namePlayer1 = Input.getPlayerName();
            string namePlayer2 = Input.getPlayerName();
            
            int boardSize = Input.boardSize();
            Player player1 = new Player(namePlayer1, boardSize);

            Player player2 = new Player(namePlayer2, boardSize);
            //initializeBoard();


        }

        public static char[,] initializeBoard(int i_boardSize)
        {
            int numOfCoinRows = (i_boardSize / 2) - 1;
            // add 2 rows and 2 colums for padding
            i_boardSize = i_boardSize + 2;

            char[,] gameBoard = new char[i_boardSize, i_boardSize];

            //initialize O Coins
            for (int i = 1; i < numOfCoinRows + 1; i++)
            {
                for (int j = 1; j < i_boardSize - 1; j++)
                {
                    // odd row & even column
                    if (i % 2 != 0 && j % 2 == 0)
                    {
                        gameBoard[i, j] = 'O';
                    }

                    // even row & odd column
                    if (i % 2 == 0 && j % 2 != 0)
                    { 
                        gameBoard[i, j] = 'O';
                    }

                }
            }
            //initialize X Coins
            for (int i = i_boardSize - 2; i > numOfCoinRows + 2; i--)
            {
                for (int j = 1; j < i_boardSize - 1; j++)
                {
                    // odd row & even column
                    if (i % 2 != 0 && j % 2 == 0)
                    {
                        gameBoard[i, j] = 'X';
                    }

                    // even row & odd column
                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        gameBoard[i, j] = 'X';
                    }

                }
            }

            return gameBoard;
        }
    }
}