using System;

namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    internal class GameManager
    {
        private Player player1;
        private Player player2;
        private GameBoard gameBoard;
        private bool hasRoundEnded;
        private bool isRoundDraw;

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
            this.hasRoundEnded = false;
            this.isRoundDraw = false;
            Output.PrintInstructions();
            // ADD - function that prints move structure - promt it upon illegal input
            //Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Screen was cleared");
            StartGame();

        }

        public void StartGame()
        {
            Output.CurrentGameStatus(player1, player2, gameBoard);

            while (!hasRoundEnded)
            {
                //Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine("Screen was cleared");
                StartTurn(player1);
                Output.Print2DArray(gameBoard);

                //Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine("Screen was cleared");
                StartTurn(player2);
                Output.Print2DArray(gameBoard);
            }
            EndRound();

        }

        public void StartTurn(Player CurrPlayerTurn)
        {
            string PlayerMove = string.Empty;
            bool isMoveSyntaxIllegal = true;
            bool isMoveLogicIllegal = true;
            bool isMoveJump = false;

            // Checks that move is syntactically & logically legal
            // ADD - logic test that you are capturing if you must. - check
            while (isMoveSyntaxIllegal || isMoveLogicIllegal)
            {
                PlayerMove = Input.ReadMoveString(CurrPlayerTurn);
                isMoveSyntaxIllegal = !Input.IsMoveLegal(PlayerMove);
                if (!isMoveSyntaxIllegal)
                {
                    isMoveLogicIllegal = !Logic.MoveIsValid(this.gameBoard, PlayerMove, CurrPlayerTurn);
                }
                

                if (isMoveSyntaxIllegal || isMoveLogicIllegal)
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

            // Checks if move is jump and deletes caputed coin

            isMoveJump = Logic.IsJump(gameBoard, CurrPlayerTurn.Color, xStart, yStart, xEnd, yEnd);


            if (isMoveJump)
            {
                this.gameBoard.Board[(xStart + xEnd)/2, (yStart + yEnd)/2] = null;
                // ADD - need to update amount of coins left and check which type of coin was captured
                // ADD - check if you can eat again than gives you another turn
                // ADD - check if you the amount of coins otherr player has, if zero than currnt player won
            }

            // ADD - check for draw - if yes end round

        }

        public void EndRound()
        {
            char userChoice = ' ';

                // ADD - score calculation if someone won
                if (this.isRoundDraw == false)
                {
                    int player1score = player1.NumberPawnsLeft + (player1.NumberKingsLeft * 4);
                    int player2score = player2.NumberPawnsLeft + (player2.NumberKingsLeft * 4);

                    if (player1score > player2score)
                    {
                        player1.Score = player1score - player2score;
                        Output.EndRoundPrompt(player1.PlayerName);
                    }

                    if (player1score < player2score)
                    {
                        player2.Score = player2score - player1score;
                        Output.EndRoundPrompt(player2.PlayerName);
                    }
                }
                else
                {
                    Output.EndRoundPrompt("Nobody");
                }

            while (userChoice != 'q' || userChoice != 'n')
            {
                userChoice = Input.ReadChar();

                if (userChoice == 'q')
                {
                    EndGame();
                }
                else if (userChoice == 'n')
                {
                    this.gameBoard.ClearBoard();
                    this.gameBoard.initializeBoard();
                    this.hasRoundEnded = false;
                    StartGame();
                }
                else
                {
                    Output.InvalidinputPrompt();
                }

            }
           
        }

        public void EndGame()
        {
            Output.EndGamePrompt();
            Environment.Exit(0);
        }
    }
}
