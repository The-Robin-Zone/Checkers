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
            int numberOfPlayers = Input.numberOfPlayers();
            string namePlayer1 = Input.getPlayerName();
            Player player1 = new Player(namePlayer1);
            string namePlayer2 = Input.getPlayerName();
           
            Player player2 = new Player(namePlayer1);
            int boardSize = Input.boardSize();
            //initializeBoard();
        }

    //public static void initializeBoard()
    //    {
    //        Coin[,] gameBoard = new Coin[,];
    //    }
    }
}
