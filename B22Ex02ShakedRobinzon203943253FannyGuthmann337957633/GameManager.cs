using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    internal class GameManager
    {
        private Player player1;
        private Player player2;
        private GameBoard gameBoard;
        private bool HasGameWon;

        public void InitializeGame()
        {
            int numberOfPlayers = Input.numberOfPlayers();
            string namePlayer1 = Input.getPlayerName(1);
            string namePlayer2 = Input.getPlayerName(2);
            int boardSize = Input.boardSize();

            this.player1 = new Player(namePlayer1, boardSize, 'O');
            this.player2 = new Player(namePlayer2, boardSize, 'X');
            this.gameBoard = new GameBoard(boardSize);

            this.gameBoard.initializeBoard();

            StartGame();

            Console.ReadLine();

        }

        public void StartGame()
        {
            Output.PrintInstructions();

            Output.CurrentGameStatus(player1, player2, gameBoard);

            Console.ReadLine();
        }

        public void EndGame()
        {
            Console.WriteLine("Thank you for playing!");
            Console.ReadLine();
        }
    }
}
