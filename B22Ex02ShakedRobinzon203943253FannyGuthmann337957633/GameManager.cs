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
        private int numOfPlayers;

        public void InitializeGame()
        {
            numOfPlayers = Input.NumberOfPlayers();
            int boardSize = Input.BoardSize();
            string namePlayer1 = Input.GetPlayerName(1);
            this.player1 = new Player(namePlayer1, boardSize, 'O');

            string namePlayer2 = "Computer";

            if (numOfPlayers == 2)
            {
                namePlayer2 = Input.GetPlayerName(2);
            }

            this.player2 = new Player(namePlayer2, boardSize, 'X');
            this.gameBoard = new GameBoard(boardSize);
            this.gameBoard.InitializeBoard();
            this.hasRoundEnded = false;
            this.isRoundDraw = false;
            Output.PrintInstructions();
            //Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Screen was cleared");
            StartGame();

        }

        public void StartGame()
        {
            Output.MoveSyntaxPrompt();
            Output.CurrentGameStatus(player1, player2);
            Output.Print2DArray(gameBoard);
            Output.PressToContinue();

            //Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Screen was cleared");

            while (!hasRoundEnded)
            {
                if (Logic.AllMovePossible(gameBoard,player1).Count != 0)
                {
                    Output.Print2DArray(gameBoard);
                    StartTurn(player1, player2);
                }

                if (Logic.AllMovePossible(gameBoard,player2).Count != 0)
                {
                    // if second player is human we also print board
                    if (numOfPlayers == 2)
                    {
                        Output.Print2DArray(gameBoard);
                    }

                    StartTurn(player2, player1);
                }

                if (Logic.AllMovePossible(gameBoard,player1).Count == 0 && Logic.AllMovePossible(gameBoard,player2).Count == 0)
                {
                    EndRound();
                }
            }
            EndRound();

        }

        public void StartTurn(Player CurrPlayerTurn, Player currEnemyPlayer)
        {
            bool isMoveJump = false;
            string PlayerMove = String.Empty;

            if (numOfPlayers == 1 && string.Equals(CurrPlayerTurn.PlayerName, "Computer"))
            {
                PlayerMove = Logic.NextMoveComputer(gameBoard, player2);
            }
            else
            {
                PlayerMove = GetPlayerMove(CurrPlayerTurn);
            }

            // Calculates starting and end tiles for the current move
            int xStart = PlayerMove[1] - 'a' + 1;
            int yStart = PlayerMove[0] - 'A' + 1;
            int xEnd = PlayerMove[4] - 'a' + 1;
            int yEnd = PlayerMove[3] - 'A' + 1;

            // Check if move is jump
            isMoveJump = Logic.IsJump(gameBoard, CurrPlayerTurn.Color, xStart, yStart, xEnd, yEnd);

            // Move Coin
            MoveCoin(xStart, yStart, xEnd, yEnd);

            // Turn coin to king if needed
            if (Logic.ShouldTurnKing(this.gameBoard, xEnd, yEnd))
            {
                TurnToKing(xEnd, yEnd);
            }

            if (isMoveJump)
            {
                MakeCoinCapture(CurrPlayerTurn, currEnemyPlayer, xStart, yStart, xEnd, yEnd);
            }

            //Check for draw before ending players turn
            if (Logic.IsDraw(this.gameBoard, CurrPlayerTurn) && Logic.IsDraw(this.gameBoard, currEnemyPlayer))
            {
                this.hasRoundEnded = true;
                this.isRoundDraw = true;
                EndRound();
            }

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

            if (numOfPlayers == 2)
            {
                Output.LimitedTurnPrompt();
                Output.Print2DArray(gameBoard);
            }


            while (isLimitedMoveIllegal)
            {
                if (numOfPlayers == 1 && string.Equals(CurrPlayerTurn.PlayerName, "Computer"))
                {
                    playerLimitedMove = Logic.NextMoveComputer(gameBoard, player2);
                }
                else
                {
                    playerLimitedMove = GetPlayerMove(CurrPlayerTurn);
                }

            xStart = playerLimitedMove[1] - 'a' + 1;
            yStart = playerLimitedMove[0] - 'A' + 1;
            xEnd = playerLimitedMove[4] - 'a' + 1;
            yEnd = playerLimitedMove[3] - 'A' + 1;   


                if (xStart == xActuallPoint && yStart == yActuallPoint)
                {
                    isLimitedMoveIllegal = false;
                }
            }

            // Move Coin
            MoveCoin(xStart, yStart, xEnd, yEnd);

            // Turn coin to king if needed
            if (Logic.ShouldTurnKing(this.gameBoard, xEnd, yEnd))
            {
                TurnToKing(xEnd, yEnd);
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
                        Output.CurrentGameStatus(player1, player2);
                        Output.EndRoundPrompt(player1.PlayerName);
                    }

                    if (player1score < player2score)
                    {
                        player2.Score = player2score - player1score;
                        Output.CurrentGameStatus(player1, player2);
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
                    this.gameBoard.InitializeBoard();
                    this.hasRoundEnded = false;
                    StartGame();
                }
                else
                {
                    Output.InvalidInputPrompt();
                }
            }
        }

        public static void EndGame()
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
                    if (!Logic.NoOpponentToEat(this.gameBoard,CurrPlayerTurn.Color))
                    {
                        Output.MustCapturePromt();
                    }
                    else
                    {
                        Output.InvalidInputPrompt();
                    }
                    Output.MoveSyntaxPrompt();
                }
            }
            return PlayerMove;
        }

        public void MoveCoin(int xStart, int yStart, int xEnd, int yEnd)
        {
            this.gameBoard.Board[xEnd, yEnd] = this.gameBoard.Board[xStart, yStart];
            this.gameBoard.Board[xStart, yStart] = null;
        }

        public void TurnToKing(int xEnd, int yEnd)
        {
            this.gameBoard.Board[xEnd, yEnd].IsKing = true;

            if (this.gameBoard.Board[xEnd, yEnd].CoinColor == 'O')
            {
                this.gameBoard.Board[xEnd, yEnd].CoinColor = 'Q';
                player1.NumberKingsLeft++;
                player1.NumberPawnsLeft--;
            }
            if (this.gameBoard.Board[xEnd, yEnd].CoinColor == 'X')
            {
                this.gameBoard.Board[xEnd, yEnd].CoinColor = 'Z';
                player2.NumberKingsLeft++;
                player2.NumberPawnsLeft--;
            }
        }
    }
}
