using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Program
    {
        public static void Main()
        {
            //initializeGame();
            GameBoard gameBoard = new GameBoard(10);
            gameBoard.initializeBoard();
            Output.Print2DArray(gameBoard);
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

        
    }
}