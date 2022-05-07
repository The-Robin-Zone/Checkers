using System;
//using Ex02.ConsoleUtils;

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
            this.HasGameWon = false;
            Output.PrintInstructions();
            //Ex02.ConsoleUtils.Screen.Clear();
            StartGame();

        }

        public void StartGame()
        {
            Output.CurrentGameStatus(player1, player2, gameBoard);

            //int currentPlayerTurn = 1;
            
            //EndRound(); // temporarly here for checking - delete after checking

            // Need to add case if you get another turn after captureing

            while (!HasGameWon)
            {
                StartTurn(player1);
                StartTurn(player2);
            }
            EndRound();

        }

        public void EndGame()
        {
            Output.EndGamePrompt();
            Environment.Exit(0);
        }

        public void StartTurn(Player CurrPlayerTurn)
        {
            bool isMoveIllegal = true;

            while (isMoveIllegal)
            {
                string PlayerMove = Input.ReadMoveString(CurrPlayerTurn);
                isMoveIllegal = !Input.IsMoveLegal(PlayerMove, this.gameBoard.BoardSize);

                if( isMoveIllegal == true)
                {
                    Output.InvalidinputPrompt();
                }
                
            }

        }

        public void EndRound()
        {
            char userChoice = ' ';
            Output.EndRoundPrompt();

            while (userChoice != 'q' && userChoice != 'n')
            {
                userChoice = Input.ReadChar();

                if (userChoice == 'q')
                {
                    EndGame();
                }
                if (userChoice == 'n')
                {
                    this.gameBoard.ClearBoard();
                    this.gameBoard.initializeBoard();
                    StartGame();
                }

                Output.InvalidinputPrompt();
            }
           
        }
    }
}
