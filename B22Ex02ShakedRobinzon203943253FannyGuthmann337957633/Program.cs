using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Program
    {
        public static void Main()
        {
            initializeGame();
        }

    public static void initializeGame()
        {
            int numberOfPlayers;
            int boardSize;

            Console.WriteLine("Welcome to Checkers!");
            Console.WriteLine("Please choose number of players: 1/2");
            numberOfPlayers = input.numberOfPlayers;
            if ( numberOfPlayers == 2)
            {
                Console.WriteLine("Not supported yet");
                initializeGame();
            }
            Player player1 = input.playerInitialize();
            Player player2 = input.playerInitialize();

            Console.WriteLine("Please choose board size: 6/8/10");
            boardSize = input.boardSize();

            initializeBoard();


        }

    public static void initializeBoard()
        {
            Coin[,] gameBoard = new Coin[,];
        }
    }
}
