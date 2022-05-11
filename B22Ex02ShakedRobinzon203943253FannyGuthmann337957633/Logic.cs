using System;
using System.Collections;

namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Logic
    {
        public static bool MoveIsValid(GameBoard i_GameBoard, string i_MoveString, Player i_CurrPlayer)
        {
            bool o_IsMoveValid = true;
            int xStart = i_MoveString[1] - 'a' + 1;
            int yStart = i_MoveString[0] - 'A' + 1;
            int xEnd = i_MoveString[4] - 'a' + 1;
            int yEnd = i_MoveString[3] - 'A' + 1;

            // Check move is in bound of the board
            if (!MoveIsInbound(i_GameBoard, xStart, yStart, xEnd, yEnd))
            {
                o_IsMoveValid = false;
            }
            else if (IsTileFree(i_GameBoard, xStart, yStart))
            {
                o_IsMoveValid = false;
            }
            else if (!CoinExistAtLocation(i_GameBoard, xStart, yStart, i_CurrPlayer.Color))
            {
                o_IsMoveValid = false;
            }
            else if (!IsTileFree(i_GameBoard, xEnd, yEnd))
            {
                o_IsMoveValid = false;
            }
            else
            {
                // Player move is not check
                o_IsMoveValid = false;

                // Check that player is doing a simple move
                if (IsSimpleMove(i_GameBoard, i_CurrPlayer.Color, xStart, yStart, xEnd, yEnd))
                {
                    o_IsMoveValid = true;
                    if (!NoOpponentToEat(i_GameBoard, i_CurrPlayer.Color))
                    {
                        o_IsMoveValid = false;
                    }
                }
                else if (IsJump(i_GameBoard, i_CurrPlayer.Color, xStart, yStart, xEnd, yEnd))
                {
                    o_IsMoveValid = true;
                }
            }

            return o_IsMoveValid;
        }

        // Check if a coin exist at the location of the right color
        public static bool CoinExistAtLocation(GameBoard i_GameBoard, int i_XPoint, int i_YPoint, char i_PlayerColor)
        {
            bool o_CoinExistAtLocation = true;

            if (i_PlayerColor.CompareTo('O') == 0 && i_GameBoard.Board[i_XPoint, i_YPoint].IsKing)
            {
                i_PlayerColor = 'Q';
            }
            else if (i_PlayerColor.CompareTo('X') == 0 && i_GameBoard.Board[i_XPoint, i_YPoint].IsKing)
            {
                i_PlayerColor = 'Z';
            }

            if (i_GameBoard.Board[i_XPoint, i_YPoint].CoinColor.CompareTo(i_PlayerColor) != 0)
            {
                o_CoinExistAtLocation = false;
            }

            return o_CoinExistAtLocation;
        }

        // Check if the square is empty
        public static bool IsTileFree(GameBoard i_GameBoard, int i_XPoint, int i_YPoint)
        {
            bool o_IsTileDestinationFree = true;

            if (i_GameBoard.Board[i_XPoint, i_YPoint] != null)
            {
                o_IsTileDestinationFree = false;
            }

            return o_IsTileDestinationFree;
        }

        // Check if the tile is occupied by the given color
        private static bool isTileOccupiedByRightColor(GameBoard i_GameBoard, int i_XPoint, int i_YPoint, char i_PlayerColor)
        {
            bool o_IsTileOccupiedByRightColor = true;

            if (IsTileFree(i_GameBoard, i_XPoint, i_YPoint))
            {
                o_IsTileOccupiedByRightColor = false;
            }
            else if (!CoinExistAtLocation(i_GameBoard, i_XPoint, i_YPoint, i_PlayerColor))
            {
                o_IsTileOccupiedByRightColor = false;
            }

            return o_IsTileOccupiedByRightColor;
        }

        // Check that the move is a simple legal move
        public static bool IsSimpleMove(GameBoard i_GameBoard, char i_PlayerColor, int i_XStart, int i_YStart, int i_XEnd, int i_YEnd)
        {
            bool o_IsSimpleMove = true;

            if (Math.Abs(i_XEnd - i_XStart) == 1 && Math.Abs(i_YEnd - i_YStart) == 1)
            {
                if (i_PlayerColor.CompareTo('O') == 0 && !i_GameBoard.Board[i_XStart, i_YStart].IsKing)
                {
                    if (i_XEnd < i_XStart)
                    {
                        o_IsSimpleMove = false;
                    }
                    else if (!IsTileFree(i_GameBoard, i_XEnd, i_YEnd))
                    {
                        o_IsSimpleMove = false;
                    }
                }
                else if (i_PlayerColor.CompareTo('X') == 0 && !i_GameBoard.Board[i_XStart, i_YStart].IsKing)
                {
                    if (i_XEnd > i_XStart)
                    {
                        o_IsSimpleMove = false;
                    }
                    else if (!IsTileFree(i_GameBoard, i_XEnd, i_YEnd))
                    {
                        o_IsSimpleMove = false;
                    }
                }
            }
            else
            {
                o_IsSimpleMove = false;
            }

            return o_IsSimpleMove;
        }

        // Check if the move is a jump legal
        public static bool IsJump(GameBoard i_GameBoard, char i_PlayerColor, int i_XStart, int i_YStart, int i_XEnd, int I_YEnd)
        {
            bool o_IsJump = true;

            if (Math.Abs(i_XEnd - i_XStart) == 2 && Math.Abs(I_YEnd - i_YStart) == 2)
            {
                int xMidlle = (i_XStart + i_XEnd) / 2;
                int yMidlle = (i_YStart + I_YEnd) / 2;

                if (!MoveIsInbound(i_GameBoard, i_XStart, i_YStart, i_XEnd, I_YEnd))
                {
                    o_IsJump = false;
                }
                else if (i_PlayerColor.CompareTo('O') == 0)
                {
                    if (i_XEnd < i_XStart && !i_GameBoard.Board[i_XStart, i_YStart].IsKing)
                    {
                        o_IsJump = false;
                    }
                    else if (!IsTileFree(i_GameBoard, i_XEnd, I_YEnd) || IsTileFree(i_GameBoard, xMidlle, yMidlle) || CoinExistAtLocation(i_GameBoard, xMidlle, yMidlle, i_PlayerColor))
                    {
                        o_IsJump = false;
                    }
                }
                else if (i_PlayerColor.CompareTo('X') == 0)
                {
                    if (i_XEnd > i_XStart && !i_GameBoard.Board[i_XStart, i_YStart].IsKing)
                    {
                        o_IsJump = false;
                    }
                    else if (!IsTileFree(i_GameBoard, i_XEnd, I_YEnd) || IsTileFree(i_GameBoard, xMidlle, yMidlle) || CoinExistAtLocation(i_GameBoard, xMidlle, yMidlle, i_PlayerColor))
                    {
                        o_IsJump = false;
                    }
                }
            }
            else
            {
                o_IsJump = false;
            }

            return o_IsJump;
        }

        // Check if the player can eat an opponent
        public static bool NoOpponentToEat(GameBoard i_GameBoard, char i_PlayerColor)
        {
            bool o_NoOpponentToEat = true;
            char opponentColor = 'O';

            if (i_PlayerColor.CompareTo('O') == 0)
            {
                opponentColor = 'X';
            }

            for (int i = 1; i < i_GameBoard.BoardSize - 1; i++)
            {
                for (int j = 1; j < i_GameBoard.BoardSize - 1; j++)
                {
                    if (isTileOccupiedByRightColor(i_GameBoard, i, j, i_PlayerColor))
                    {
                        // Check if element need to go up or down
                        if (i_PlayerColor.CompareTo('X') == 0 || i_GameBoard.Board[i, j].IsKing)
                        {
                            if (isNeighborOccupyByOpponent(i_GameBoard, i, j, i - 2, j + 2, i - 1, j + 1, i_PlayerColor, opponentColor))
                            {
                                o_NoOpponentToEat = false;
                                goto end;
                            }

                            if (isNeighborOccupyByOpponent(i_GameBoard, i, j, i - 2, j - 2, i - 1, j - 1, i_PlayerColor, opponentColor))
                            {
                                o_NoOpponentToEat = false;
                                goto end;
                            }
                        }

                        if (i_PlayerColor.CompareTo('O') == 0 || i_GameBoard.Board[i, j].IsKing)
                        {
                            if (isNeighborOccupyByOpponent(i_GameBoard, i, j, i + 2, j + 2, i + 1, j + 1, i_PlayerColor, opponentColor))
                            {
                                o_NoOpponentToEat = false;
                                goto end;
                            }

                            if (isNeighborOccupyByOpponent(i_GameBoard, i, j, i + 2, j - 2, i + 1, j - 1, i_PlayerColor, opponentColor))
                            {
                                o_NoOpponentToEat = false;
                                goto end;
                            }
                        }
                    }
                }
            }

        end:
            return o_NoOpponentToEat;
        }

        // Check if the neighbor of the coin is occupied by opponent
        private static bool isNeighborOccupyByOpponent(GameBoard i_GameBoard, int i_XStart, int i_YStart, int i_XEnd, int i_YEnd, int i_XMiddle, int i_YMiddle, char i_PlayerColor, char i_OpponentColor)
        {
            bool o_IsNeighborOccupyByOpponent = true;

            if (isTileOccupiedByRightColor(i_GameBoard, i_XMiddle, i_YMiddle, i_OpponentColor) && !coinIsAtBorderOfBoard(i_GameBoard, i_XMiddle, i_YMiddle) && IsTileFree(i_GameBoard, i_XEnd, i_YEnd))
            {
                if (IsJump(i_GameBoard, i_PlayerColor, i_XStart, i_YStart, i_XEnd, i_YEnd))
                {
                    o_IsNeighborOccupyByOpponent = false;
                }
            }

            return !o_IsNeighborOccupyByOpponent;
        }

        // Check if the coin is at one of the extremity of the board
        private static bool coinIsAtBorderOfBoard(GameBoard i_GameBoard, int i_XPoint, int i_YPoint)
        {
            bool o_CoinIsAtBorderOfBoard = true;

            if ((i_XPoint <= 1) || (i_YPoint <= 1) || (i_XPoint >= (i_GameBoard.BoardSize - 2)) || (i_YPoint >= (i_GameBoard.BoardSize - 2)))
            {
                o_CoinIsAtBorderOfBoard = false;
            }

            return !o_CoinIsAtBorderOfBoard;
        }

        // Check that the move are in the bound of board game 
        public static bool MoveIsInbound(GameBoard i_GameBoard, int i_XStart, int i_YStart, int i_XEnd, int i_YEnd)
        {
            bool o_IsMoveInBound = true;

            if (i_XStart > i_GameBoard.BoardSize - 2 || i_XStart <= 0)
            {
                o_IsMoveInBound = false;
            }
            else if (i_YStart > i_GameBoard.BoardSize - 2 || i_YStart <= 0)
            {
                o_IsMoveInBound = false;
            }
            else if (i_XEnd > i_GameBoard.BoardSize - 2 || i_XEnd <= 0)
            {
                o_IsMoveInBound = false;
            }
            else if (i_YEnd > i_GameBoard.BoardSize - 2 || i_YEnd <= 0)
            {
                o_IsMoveInBound = false;
            }

            return o_IsMoveInBound;
        }

        // Check if another jump is possible
        public static bool IsJumpAvalaible(GameBoard i_GameBoard, char i_PlayerColor, int i_XPoint, int i_YPoint)
        {
            bool o_IsJumpAvailable = true;

            // Check if the coin is a king
            bool isKing = i_GameBoard.Board[i_XPoint, i_YPoint].IsKing;
            bool isColorX = true;

            // Check the color of the coin
            if (i_GameBoard.Board[i_XPoint, i_YPoint].CoinColor.CompareTo('O') == 0)
            {
                isColorX = false;
            }

            // If the element is a king enter the two if and check 4 options if not check the only two option available for it
            if (isKing || isColorX)
            {
                if (MoveIsInbound(i_GameBoard, i_XPoint, i_YPoint, i_XPoint - 2, i_YPoint - 2))
                {
                    if (IsJump(i_GameBoard, i_PlayerColor, i_XPoint, i_YPoint, i_XPoint - 2, i_YPoint - 2))
                    {
                        o_IsJumpAvailable = false;
                    }
                }

                if (MoveIsInbound(i_GameBoard, i_XPoint, i_YPoint, i_XPoint - 2, i_YPoint + 2))
                {
                    if (IsJump(i_GameBoard, i_PlayerColor, i_XPoint, i_YPoint, i_XPoint - 2, i_YPoint + 2))
                    {
                        o_IsJumpAvailable = false;
                    }
                }
            }

            if (isKing || !isColorX)
            {
                if (MoveIsInbound(i_GameBoard, i_XPoint, i_YPoint, i_XPoint + 2, i_YPoint - 2))
                {
                    if (IsJump(i_GameBoard, i_PlayerColor, i_XPoint, i_YPoint, i_XPoint + 2, i_YPoint - 2))
                    {
                        o_IsJumpAvailable = false;
                    }
                }

                if (MoveIsInbound(i_GameBoard, i_XPoint, i_YPoint, i_XPoint + 2, i_YPoint + 2))
                {
                    if (IsJump(i_GameBoard, i_PlayerColor, i_XPoint, i_YPoint, i_XPoint + 2, i_YPoint + 2))
                    {
                        o_IsJumpAvailable = false;
                    }
                }
            }

            return !o_IsJumpAvailable;
        }

        // Check if pawn become king
        public static bool ShouldTurnKing(GameBoard i_GameBoard, int i_XPoint, int i_YPoint)
        {
            bool o_ShouldTurnKing = true;

            // Check if already king
            if (i_GameBoard.Board[i_XPoint, i_YPoint].IsKing)
            {
                o_ShouldTurnKing = false;
            }

            // Check if color O is go to the last row
            else if (i_GameBoard.Board[i_XPoint, i_YPoint].CoinColor.CompareTo('O') == 0)
            {
                if (i_XPoint != i_GameBoard.BoardSize - 2)
                {
                    o_ShouldTurnKing = false;
                }

                // Check if color X is go to the first row
            }
            else
            {
                if (i_XPoint != 1)
                {
                    o_ShouldTurnKing = false;
                }
            }

            return o_ShouldTurnKing;
        }

        // Randomly choose the next move of the computer
        public static string NextMoveComputer(GameBoard i_GameBoard, Player i_CurrentPlayer)
        {
            string o_NextMove = string.Empty;
            Random random = new Random();
            ArrayList allMovePossible = AllMovePossible(i_GameBoard, i_CurrentPlayer);
            int numberMovePossible = allMovePossible.Count;
            int indexMove = random.Next(numberMovePossible);
            o_NextMove = (string)allMovePossible[indexMove];
            return o_NextMove;
        }

        // Send all the possible move possible
        public static ArrayList AllMovePossible(GameBoard i_GameBoard, Player i_CurrentPlayer)
        {
            ArrayList o_AllMovePossible = new ArrayList();
            bool isJumpPossible = !NoOpponentToEat(i_GameBoard, i_CurrentPlayer.Color);

            if (isJumpPossible)
            {
                o_AllMovePossible = allJumpAvailable(i_GameBoard, i_CurrentPlayer);
            }
            else
            {
                o_AllMovePossible = allSimpleMoveAvailable(i_GameBoard, i_CurrentPlayer);
            }

            return o_AllMovePossible;
        }

        // A case a jump can happen, send all the jump possible
        private static ArrayList allJumpAvailable(GameBoard i_GameBoard, Player i_CurrentPlayer)
        {
            ArrayList o_AllJumpAvailable = new ArrayList();
            bool isKing = true;

            for (int i = 1; i < i_GameBoard.BoardSize - 1; i++)
            {
                for (int j = 1; j < i_GameBoard.BoardSize - 1; j++)
                {
                    if (isTileOccupiedByRightColor(i_GameBoard, i, j, i_CurrentPlayer.Color))
                    {
                        isKing = i_GameBoard.Board[i, j].IsKing;

                        if (isKing || (i_GameBoard.Board[i, j].CoinColor.CompareTo('X') == 0))
                        {
                            if (MoveIsInbound(i_GameBoard, i, j, i - 2, j - 2) && IsJump(i_GameBoard, i_CurrentPlayer.Color, i, j, i - 2, j - 2))
                            {
                                o_AllJumpAvailable.Add(getStringMove(i, j, i - 2, j - 2));
                            }

                            if (MoveIsInbound(i_GameBoard, i, j, i - 2, j + 2) && IsJump(i_GameBoard, i_CurrentPlayer.Color, i, j, i - 2, j + 2))
                            {
                                o_AllJumpAvailable.Add(getStringMove(i, j, i - 2, j + 2));
                            }
                        }

                        if (isKing || (i_GameBoard.Board[i, j].CoinColor.CompareTo('O') == 0))
                        {
                            if (MoveIsInbound(i_GameBoard, i, j, i + 2, j - 2) && IsJump(i_GameBoard, i_CurrentPlayer.Color, i, j, i + 2, j - 2))
                            {
                                o_AllJumpAvailable.Add(getStringMove(i, j, i + 2, j - 2));
                            }

                            if (MoveIsInbound(i_GameBoard, i, j, i + 2, j + 2) && IsJump(i_GameBoard, i_CurrentPlayer.Color, i, j, i + 2, j + 2))
                            {
                                o_AllJumpAvailable.Add(getStringMove(i, j, i + 2, j + 2));
                            }
                        }
                    }
                }
            }

            return o_AllJumpAvailable;
        }

         // Check all possible single move possible, and return all of the
         private static ArrayList allSimpleMoveAvailable(GameBoard i_GameBoard, Player i_CurrentPlayer) 
        {
            ArrayList o_AllSimpleMoveAvailable = new ArrayList();

            for (int i = 1; i < i_GameBoard.BoardSize - 1; i++)
            {
                for (int j = 1; j < i_GameBoard.BoardSize - 1; j++)
                {
                    if (isTileOccupiedByRightColor(i_GameBoard, i, j, i_CurrentPlayer.Color))
                    {
                        bool isKing = i_GameBoard.Board[i, j].IsKing;

                        if (isKing || (i_GameBoard.Board[i, j].CoinColor.CompareTo('X') == 0))
                        {
                            if (MoveIsInbound(i_GameBoard, i, j, i - 1, j - 1) && IsSimpleMove(i_GameBoard, i_CurrentPlayer.Color, i, j, i - 1, j - 1))
                            {
                                o_AllSimpleMoveAvailable.Add(getStringMove(i, j, i - 1, j - 1));
                            }

                            if (MoveIsInbound(i_GameBoard, i, j, i - 1, j + 1) && IsSimpleMove(i_GameBoard, i_CurrentPlayer.Color, i, j, i - 1, j + 1))
                            {
                                o_AllSimpleMoveAvailable.Add(getStringMove(i, j, i - 1, j + 1));
                            }
                        }

                        if (isKing || (i_GameBoard.Board[i, j].CoinColor.CompareTo('O') == 0))
                        {
                            if (MoveIsInbound(i_GameBoard, i, j, i + 1, j - 1) && IsSimpleMove(i_GameBoard, i_CurrentPlayer.Color, i, j, i + 1, j - 1))
                            {
                                o_AllSimpleMoveAvailable.Add(getStringMove(i, j, i + 1, j - 1));
                            }

                            if (MoveIsInbound(i_GameBoard, i, j, i + 1, j + 1) && IsSimpleMove(i_GameBoard, i_CurrentPlayer.Color, i, j, i + 1, j + 1))
                            {
                                o_AllSimpleMoveAvailable.Add(getStringMove(i, j, i + 1, j + 1));
                            }
                        }
                    }
                }
            }

            return o_AllSimpleMoveAvailable;
        }

        private static string getStringMove(int i_XStart, int i_Start, int i_XEnd, int i_YEnd)
        {
            string o_StringMove = string.Empty;
            char xStartLetter = (char)(i_XStart + 'a' - 1);
            char yStartLetter = (char)(i_Start + 'A' - 1);
            char xEndLetter = (char)(i_XEnd + 'a' - 1);
            char yEndLetter = (char)(i_YEnd + 'A' - 1);
            o_StringMove = string.Empty + yStartLetter + xStartLetter + ">" + yEndLetter + xEndLetter;
            return o_StringMove;
        }

        // Check if the next has a move possible if not return draw
        public static bool IsDraw(GameBoard i_GameBoard, Player i_CurrentPlayer)
        {
            bool o_IsDraw = true;
            ArrayList allMovePossible = AllMovePossible(i_GameBoard, i_CurrentPlayer);

            if (allMovePossible.Count != 0)
            {
                o_IsDraw = false;
            }

            return o_IsDraw;
        }
    }
}