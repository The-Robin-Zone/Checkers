using System;

namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    internal class GameManager
    {
        private Player m_Player1;
        private Player m_Player2;
        private GameBoard m_GameBoard;
        private bool m_HasRoundEnded;
        private bool m_IsRoundDraw;
        private int m_NumOfPlayers;

        public void InitializeGame()
        {
            m_NumOfPlayers = Input.NumberOfPlayers();
            int boardSize = Input.BoardSize();
            string namePlayer1 = Input.GetPlayerName(1);
            this.m_Player1 = new Player(namePlayer1, boardSize, 'O');
            string namePlayer2 = "Computer";

            if (m_NumOfPlayers == 2)
            {
                namePlayer2 = Input.GetPlayerName(2);
            }

            this.m_Player2 = new Player(namePlayer2, boardSize, 'X');
            this.m_GameBoard = new GameBoard(boardSize);
            this.m_GameBoard.InitializeBoard();
            this.m_HasRoundEnded = false;
            this.m_IsRoundDraw = false;
            Output.PrintInstructions();
            //Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Screen was cleared");
            startGame();

        }

        private void startGame()
        {
            Output.MoveSyntaxPrompt();
            Output.CurrentGameStatus(m_Player1, m_Player2);
            Output.Print2DArray(m_GameBoard);
            Output.PressToContinuePrompt();

            //Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Screen was cleared");

            while (!m_HasRoundEnded)
            {
                if (Logic.AllMovePossible(m_GameBoard,m_Player1).Count != 0)
                {
                    Output.Print2DArray(m_GameBoard);
                    startTurn(m_Player1, m_Player2);
                }

                if (Logic.AllMovePossible(m_GameBoard,m_Player2).Count != 0)
                {
                    // if second player is human we also print board
                    if (m_NumOfPlayers == 2)
                    {
                        Output.Print2DArray(m_GameBoard);
                    }

                    startTurn(m_Player2, m_Player1);
                }

                if (Logic.AllMovePossible(m_GameBoard,m_Player1).Count == 0 && Logic.AllMovePossible(m_GameBoard,m_Player2).Count == 0)
                {
                    endRound();
                }
            }
            endRound();

        }

        private void startTurn(Player i_CurrPlayerTurn, Player i_CurrEnemyPlayer)
        {
            bool isMoveJump = true;
            string PlayerMove = String.Empty;

            if (m_NumOfPlayers == 1 && string.Equals(i_CurrPlayerTurn.PlayerName, "Computer"))
            {
                PlayerMove = Logic.NextMoveComputer(m_GameBoard, m_Player2);
            }
            else
            {
                PlayerMove = getPlayerMove(i_CurrPlayerTurn);
            }

            // Calculates starting and end tiles for the current move
            int xStart = PlayerMove[1] - 'a' + 1;
            int yStart = PlayerMove[0] - 'A' + 1;
            int xEnd = PlayerMove[4] - 'a' + 1;
            int yEnd = PlayerMove[3] - 'A' + 1;

            // Check if move is jump
            isMoveJump = Logic.IsJump(m_GameBoard, i_CurrPlayerTurn.Color, xStart, yStart, xEnd, yEnd);

            // Move Coin
            moveCoin(xStart, yStart, xEnd, yEnd);

            // Turn coin to king if needed
            if (Logic.ShouldTurnKing(this.m_GameBoard, xEnd, yEnd))
            {
                turnToKing(xEnd, yEnd);
            }

            if (isMoveJump)
            {
                makeCoinCapture(i_CurrPlayerTurn, i_CurrEnemyPlayer, xStart, yStart, xEnd, yEnd);
            }

            //Check for draw before ending players turn
            if (Logic.IsDraw(this.m_GameBoard, i_CurrPlayerTurn) && Logic.IsDraw(this.m_GameBoard, i_CurrEnemyPlayer))
            {
                this.m_HasRoundEnded = true;
                this.m_IsRoundDraw = true;
                endRound();
            }

            //Ex02.ConsoleUtils.Screen.Clear();
            Console.WriteLine("Screen was cleared");
        }

        private void makeCoinCapture(Player i_CurrPlayerTurn, Player i_CurrEnemyPlayer, int i_XStart,
            int i_YStart, int i_XEnd, int i_YEnd)
        {
            bool wasKingCaptured = this.m_GameBoard.Board[(i_XStart + i_XEnd) / 2, (i_YStart + i_YEnd) / 2].IsKing;
            this.m_GameBoard.Board[(i_XStart + i_XEnd) / 2, (i_YStart + i_YEnd) / 2] = null;

            // Updates enemy player Coin count
            if (wasKingCaptured)
            {
                i_CurrEnemyPlayer.NumberKingsLeft--;
            }
            else
            {
                i_CurrEnemyPlayer.NumberPawnsLeft--;
            }

            // Check enemy's amount of coins, if none left current player wins
            if (i_CurrEnemyPlayer.NumberPawnsLeft == 0 && i_CurrEnemyPlayer.NumberKingsLeft == 0)
            {
                this.m_HasRoundEnded = true;
                endRound();
            }

            // Check if another capture is possible
            if (Logic.IsJumpAvalaible(this.m_GameBoard, i_CurrPlayerTurn.Color, i_XEnd, i_YEnd))
            {
                limitedTurn(i_CurrPlayerTurn, i_CurrEnemyPlayer, i_XEnd, i_YEnd);
            }
        }

        private void limitedTurn(Player i_CurrPlayerTurn, Player i_CurrEnemyPlayer , int i_XActuallPoint, int i_YActuallPoint)
        {
            string playerLimitedMove = string.Empty;
            bool isLimitedMoveIllegal = true;
            int xStart = 0;
            int yStart = 0;
            int xEnd = 0;
            int yEnd = 0;

            if (m_NumOfPlayers == 2)
            {
                Output.LimitedTurnPrompt();
                Output.Print2DArray(m_GameBoard);
            }

            while (isLimitedMoveIllegal)
            {
                if (m_NumOfPlayers == 1 && string.Equals(i_CurrPlayerTurn.PlayerName, "Computer"))
                {
                    playerLimitedMove = Logic.NextMoveComputer(m_GameBoard, m_Player2);
                }
                else
                {
                    playerLimitedMove = getPlayerMove(i_CurrPlayerTurn);
                }

                xStart = playerLimitedMove[1] - 'a' + 1;
                yStart = playerLimitedMove[0] - 'A' + 1;
                xEnd = playerLimitedMove[4] - 'a' + 1;
                yEnd = playerLimitedMove[3] - 'A' + 1;   

                if (xStart == i_XActuallPoint && yStart == i_YActuallPoint)
                {
                    isLimitedMoveIllegal = false;
                }
            }

            // Move Coin
            moveCoin(xStart, yStart, xEnd, yEnd);

            // Turn coin to king if needed
            if (Logic.ShouldTurnKing(this.m_GameBoard, xEnd, yEnd))
            {
                turnToKing(xEnd, yEnd);
            }

            //do actual capture
            makeCoinCapture(i_CurrPlayerTurn, i_CurrEnemyPlayer, xStart, yStart, xEnd, yEnd);

            // Check if another capure is possible
            if (Logic.IsJumpAvalaible(this.m_GameBoard, i_CurrPlayerTurn.Color, xEnd, yEnd))
            {
                limitedTurn(i_CurrPlayerTurn, i_CurrEnemyPlayer, xEnd, yEnd);
            }
        }

        private void endRound()
        {
            char userChoice = ' ';

                // Score calculation if round didn't end with a draw
                if (this.m_IsRoundDraw == false)
                {
                    int player1score = m_Player1.NumberPawnsLeft + (m_Player1.NumberKingsLeft * 4);
                    int player2score = m_Player2.NumberPawnsLeft + (m_Player2.NumberKingsLeft * 4);

                    if (player1score > player2score)
                    {
                        m_Player1.Score = player1score - player2score;
                        Output.CurrentGameStatus(m_Player1, m_Player2);
                        Output.EndRoundPrompt(m_Player1.PlayerName);
                    }

                    if (player1score < player2score)
                    {
                        m_Player2.Score = player2score - player1score;
                        Output.CurrentGameStatus(m_Player1, m_Player2);
                        Output.EndRoundPrompt(m_Player2.PlayerName);
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
                    this.m_GameBoard.ClearBoard();
                    this.m_GameBoard.InitializeBoard();
                    this.m_HasRoundEnded = false;
                    startGame();
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

        private string getPlayerMove(Player i_CurrPlayerTurn)
        {
            string o_PlayerMove = string.Empty;
            bool isMoveSyntaxIllegal = true;
            bool isMoveLogicIllegal = true;

            // Checks that move is syntactically & logically legal
            while (isMoveSyntaxIllegal || isMoveLogicIllegal)
            {

                o_PlayerMove = Input.ReadMoveString(i_CurrPlayerTurn);
                isMoveSyntaxIllegal = !Input.IsMoveLegal(o_PlayerMove);
                if (!isMoveSyntaxIllegal)
                {
                    isMoveLogicIllegal = !Logic.MoveIsValid(this.m_GameBoard, o_PlayerMove, i_CurrPlayerTurn);
                }

                if (isMoveSyntaxIllegal || isMoveLogicIllegal)
                {
                    if (!Logic.NoOpponentToEat(this.m_GameBoard,i_CurrPlayerTurn.Color))
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
            return o_PlayerMove;
        }

        private void moveCoin(int i_XStart, int i_YStart, int i_XEnd, int i_YEnd)
        {
            this.m_GameBoard.Board[i_XEnd, i_YEnd] = this.m_GameBoard.Board[i_XStart, i_YStart];
            this.m_GameBoard.Board[i_XStart, i_YStart] = null;
        }

        private void turnToKing(int i_XEnd, int i_YEnd)
        {
            this.m_GameBoard.Board[i_XEnd, i_YEnd].IsKing = true;

            if (this.m_GameBoard.Board[i_XEnd, i_YEnd].CoinColor == 'O')
            {
                this.m_GameBoard.Board[i_XEnd, i_YEnd].CoinColor = 'Q';
                m_Player1.NumberKingsLeft++;
                m_Player1.NumberPawnsLeft--;
            }
            if (this.m_GameBoard.Board[i_XEnd, i_YEnd].CoinColor == 'X')
            {
                this.m_GameBoard.Board[i_XEnd, i_YEnd].CoinColor = 'Z';
                m_Player2.NumberKingsLeft++;
                m_Player2.NumberPawnsLeft--;
            }
        }
    }
}
