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
            //Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Screen was cleared");
            StartGame();

        }

        public void StartGame()
        {
            Output.CurrentGameStatus(player1, player2, gameBoard);
            Output.MoveSyntaxPrompt();

            while (!hasRoundEnded)
            {
                //Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine("Screen was cleared");
                StartTurn(player1, player2);
                Output.Print2DArray(gameBoard);

                //Ex02.ConsoleUtils.Screen.Clear();
                Console.WriteLine("Screen was cleared");
                StartTurn(player2, player1);
                Output.Print2DArray(gameBoard);
            }
            EndRound();

        }

        public void StartTurn(Player CurrPlayerTurn, Player currEnemyPlayer)
        {
            bool isMoveJump = false;

            string PlayerMove = GetPlayerMove(CurrPlayerTurn);
            
            // Calculates starting and end tiles for the current move
            int xStart = PlayerMove[1] - 'a' + 1;
            int yStart = PlayerMove[0] - 'A' + 1;
            int xEnd = PlayerMove[4] - 'a' + 1;
            int yEnd = PlayerMove[3] - 'A' + 1;

            // Move to before making the move 
            // This block handels jump moves
            isMoveJump = Logic.IsJump(gameBoard, CurrPlayerTurn.Color, xStart, yStart, xEnd, yEnd);

            // Move Coin
            this.gameBoard.Board[xEnd,yEnd] = this.gameBoard.Board[xStart,yStart];
            this.gameBoard.Board[xStart, yStart] = null;

            // Turn coin to king if needed
            if (Logic.ShouldTurnKing(this.gameBoard, xEnd, yEnd))
            {
                this.gameBoard.Board[xEnd, yEnd].IsKing = true;

                if (this.gameBoard.Board[xEnd,yEnd].CoinColor == 'O')
                {
                    this.gameBoard.Board[xEnd,yEnd].CoinColor = 'Q';
                }
                if (this.gameBoard.Board[xEnd,yEnd].CoinColor == 'X')
                {
                    this.gameBoard.Board[xEnd,yEnd].CoinColor = 'Z';
                }
            }

           
            
            if (isMoveJump)
            {
                MakeCoinCapture(CurrPlayerTurn, currEnemyPlayer, xStart, yStart, xEnd, yEnd);
            }

            //Check for draw before ending players turn
            //if (Logic.isDraw(this.gameBoard))
            //    {
            //        this.hasRoundEnded = true;
            //        this.isRoundDraw = true;
            //        EndRound();
            //    }

            //Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Screen was cleared");
        }

        public void MakeCoinCapture(Player CurrPlayerTurn, Player currEnemyPlayer, int xStart, int yStart, int xEnd, int yEnd)
        {
            bool wasKingCaptured = this.gameBoard.Board[(xStart + xEnd) / 2, (yStart + yEnd) / 2].IsKing;
            this.gameBoard.Board[(xStart + xEnd) / 2, (yStart + yEnd) / 2] = null;

            // Updates enemy player Coin count
            if (wasKingCaptured)
            {
                currEnemyPlayer.NumberKingsLeft--;
            }
            else
            {
                currEnemyPlayer.NumberPawnsLeft--;
            }

            // Check enemy's amount of coins, if none left current player wins
            if (currEnemyPlayer.NumberPawnsLeft == 0 && currEnemyPlayer.NumberKingsLeft == 0)
            {
                this.hasRoundEnded = true;
                EndRound();
            }

            // Check if another capture is possible
            if (Logic.IsJumpAvalaible(this.gameBoard, CurrPlayerTurn.Color, xEnd, yEnd))
            {
                LimitedTurn(CurrPlayerTurn, currEnemyPlayer, xEnd, yEnd);
            }
        }

        public void LimitedTurn(Player CurrPlayerTurn, Player currEnemyPlayer , int xActuallPoint, int yActuallPoint)
        {
            string playerLimitedMove = string.Empty;
            bool isLimitedMoveIllegal = true;
            int xStart = 0;
            int yStart = 0;
            int xEnd = 0;
            int yEnd = 0;

            Output.LimitedTurnPrompt();

            while (isLimitedMoveIllegal)
            {
                playerLimitedMove = GetPlayerMove(CurrPlayerTurn);
                xStart = playerLimitedMove[1] - 'a' + 1;
                yStart = playerLimitedMove[0] - 'A' + 1;
                xEnd = playerLimitedMove[4] - 'a' + 1;
                yEnd = playerLimitedMove[3] - 'A' + 1;

                if (xStart == xActuallPoint && yStart == yActuallPoint)
                {
                    isLimitedMoveIllegal = false;
                }
            }
            // I added this, I think we should put this in a function and called it here and in turn
            // Move Coin
            this.gameBoard.Board[xEnd, yEnd] = this.gameBoard.Board[xStart, yStart];
            this.gameBoard.Board[xStart, yStart] = null;

            // Turn coin to king if needed
            if (Logic.ShouldTurnKing(this.gameBoard, xEnd, yEnd))
            {
                this.gameBoard.Board[xEnd, yEnd].IsKing = true;

                if (this.gameBoard.Board[xEnd, yEnd].CoinColor == 'O')
                {
                    this.gameBoard.Board[xEnd, yEnd].CoinColor = 'Q';
                }
                if (this.gameBoard.Board[xEnd, yEnd].CoinColor == 'X')
                {
                    this.gameBoard.Board[xEnd, yEnd].CoinColor = 'Z';
                }
            }
            //do actual capture
            MakeCoinCapture(CurrPlayerTurn, currEnemyPlayer, xStart, yStart, xEnd, yEnd);

            // Check if another capure is possible
            if (Logic.IsJumpAvalaible(this.gameBoard, CurrPlayerTurn.Color, xEnd, yEnd))
            {
                LimitedTurn(CurrPlayerTurn, currEnemyPlayer, xEnd, yEnd);
            }
        }

        public void EndRound()
        {
            char userChoice = ' ';

                // Score calculation if round didn't end with a draw
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

        public string GetPlayerMove(Player CurrPlayerTurn)
        {
            string PlayerMove = string.Empty;
            bool isMoveSyntaxIllegal = true;
            bool isMoveLogicIllegal = true;

            // Checks that move is syntactically & logically legal
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
                    Output.MoveSyntaxPrompt();
                }
            }
            return PlayerMove;
        }   
    }
}
