using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Program
    {
        public static void Main()
        {
            //initializeGame();
            char[,] board = initializeBoard(10);
            Output.Print2DArray(board);
            Console.WriteLine("shaked");


        }

    public static void initializeGame()
        {
            int numberOfPlayers = Input.numberOfPlayers();
            string namePlayer1 = Input.getPlayerName();
            Player player1 = new Player(namePlayer1);
            string namePlayer2 = Input.getPlayerName();

            Player player2 = new Player(namePlayer1);
            int boardSize = Input.boardSize();
            //initializeBoard();


        }

        public static char[,] initializeBoard(int i_boardSize)
        {

            // add 2 rows and 2 colums for padding
            int numOfCoinRows = (i_boardSize / 2) - 1;
            i_boardSize = i_boardSize + 3;

            char[,] gameBoard = new char[i_boardSize, i_boardSize];

            // initialize O Coins
            for (int i = 1; i < numOfCoinRows; i++)
            {
                for (int j = 1; j < i_boardSize - 1; j++)
                {
                    // odd row
                    if (i % 2 != 0)
                    {
                        // even column
                        if ( j % 2 == 0)
                        {
                            gameBoard[i, j] = 'O';
                        }
                        
                    }

                    // even row
                    if (i % 2 == 0)
                    {
                        // odd column
                        if ( j % 2 != 0)
                        {
                            gameBoard[i, j] = 'O';
                        }
                    }

                }
            }
            // initialize X Coins
            for (int i = i_boardSize - 2; i > numOfCoinRows + 2; i--)
            {
                for (int j = 1; j < i_boardSize - 1; j++)
                {
                    // odd row
                    if (i % 2 != 0)
                    {
                        // even column
                        if (j % 2 == 0)
                        {
                            gameBoard[i, j] = 'X';
                        }

                    }

                    // even row
                    if (i % 2 == 0)
                    {
                        // odd column
                        if (j % 2 != 0)
                        {
                            gameBoard[i, j] = 'X';
                        }
                    }

                }
            }

            return gameBoard;
        }
    }
}
