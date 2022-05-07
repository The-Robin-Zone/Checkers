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

            while (!HasGameWon)
            {
                StartTurn(player1);
                Output.Print2DArray(gameBoard);
                StartTurn(player2);
                Output.Print2DArray(gameBoard);
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
            string PlayerMove = string.Empty;
            bool isMoveSyntaxIllegal = true;
            bool isMoveLogicIllegal = true;
            bool isMoveJump = true;

            // Checks that move is syntactically & logically legal
            while (isMoveSyntaxIllegal && isMoveLogicIllegal)
            {
                PlayerMove = Input.ReadMoveString(CurrPlayerTurn);
                isMoveSyntaxIllegal = !Input.IsMoveLegal(PlayerMove);
                isMoveLogicIllegal = !Logic.MoveIsValid(this.gameBoard, PlayerMove, CurrPlayerTurn);

                if (isMoveSyntaxIllegal && isMoveLogicIllegal)
                {
                    Output.InvalidinputPrompt();
                } 
            }


            // Calculates starting and end tiles for the current move
            int xStart = PlayerMove[1] - 'a' + 1;
            int yStart = PlayerMove[0] - 'A' + 1;
            int xEnd = PlayerMove[4] - 'a' + 1;
            int yEnd = PlayerMove[3] - 'A' + 1;

            // Move Coin
            this.gameBoard.Board[xEnd,yEnd] = this.gameBoard.Board[xStart,yStart];
            this.gameBoard.Board[xStart, yStart] = null;

            // Checks if jump
            isMoveJump = Logic.IsJump(gameBoard, CurrPlayerTurn.Color, xStart, yStart, xEnd, yEnd);

            if (isMoveJump)
            {
                this.gameBoard.Board[(xStart + xEnd)/2, (yStart + yEnd)/2] = null;
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
