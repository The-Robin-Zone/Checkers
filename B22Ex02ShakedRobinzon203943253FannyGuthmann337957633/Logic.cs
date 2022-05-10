
using System;
using System.Collections;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Logic
    {
        public static bool MoveIsValid(GameBoard gameBoard, string location, Player player)
        {
            bool o_typeMove = true;

            int xStart = location[1] - 'a' + 1;
            int yStart = location[0] - 'A' + 1;
            int xEnd = location[4] - 'a' + 1;
            int yEnd = location[3] - 'A' + 1;

            // Check move is in bound of the board
            if (!MoveIsInbound(gameBoard, xStart, yStart, xEnd, yEnd))
            {
                o_typeMove = false;
            }
            // Check if element exist in tile
            else if (IsTileFree(gameBoard, xStart, yStart))
            {
                o_typeMove = false;
            }
            // Check if the tile is occupy by the right coin
            else if (!CoinExistAtLocation(gameBoard, xStart, yStart, player.Color))
            {
                o_typeMove = false;
            }
            // Check destination tile to be free
            else if (!IsTileFree(gameBoard, xEnd, yEnd))
            {
                o_typeMove = false;
            }
            else
            {
                // Player move is not check
                o_typeMove = false;
                // Check that player is doing a simple move
                if (IsSimpleMove(gameBoard, player.Color, xStart, yStart, xEnd, yEnd))
                {
                    o_typeMove = true;
                    if (!NoOpponentToEat(gameBoard, player.Color))
                    {
                        o_typeMove = false;
                    }
                }
                // Check if the player is doing jump
                else if (IsJump(gameBoard, player.Color, xStart, yStart, xEnd, yEnd))
                {
                    o_typeMove = true;
                }
            }
            return o_typeMove;
        }

        // Check if a coin exist at the location of the right color
        public static bool CoinExistAtLocation(GameBoard gameBoard,
            int xPoint, int yPoint, char playerColor)
        {
            bool o_coinExistAtLocation = true;
            if (playerColor.CompareTo('O') == 0 && gameBoard.Board[xPoint, yPoint].IsKing)
            {
                playerColor = 'Q';
            } else if (playerColor.CompareTo('X') == 0 && gameBoard.Board[xPoint, yPoint].IsKing)
            {
                playerColor = 'Z';
            }

            if (gameBoard.Board[xPoint, yPoint].CoinColor.CompareTo(playerColor) != 0)
            {
                o_coinExistAtLocation = false;
            }
            return o_coinExistAtLocation;
        }

        // Check if the square is empty
        public static bool IsTileFree(GameBoard gameBoard,
            int xPoint, int yPoint)
        {
            bool o_coinDestinationIsFree = true;

            if (gameBoard.Board[xPoint, yPoint] != null)
            {
                o_coinDestinationIsFree = false;
            }

            return o_coinDestinationIsFree;
        }

        // Check if the tile is occupied by the given color
        private static bool tileOccupiedByColor(GameBoard gameBoard, int xPoint, int yPoint,
            char playerColor)
        {
            bool tileIsnotEmptyAndOccupyByRightColor = true;
            if (IsTileFree(gameBoard, xPoint, yPoint))
            {
                tileIsnotEmptyAndOccupyByRightColor = false;
            }
            else if (!CoinExistAtLocation(gameBoard, xPoint, yPoint, playerColor))
            {
                tileIsnotEmptyAndOccupyByRightColor = false;
            }
            return tileIsnotEmptyAndOccupyByRightColor;
        }

        // Check that the move is a simple legal move
        public static bool IsSimpleMove(GameBoard gameBoard, char playerColor, int xStart,
            int yStart, int xEnd, int yEnd)
        {
            bool isSimpleMove = true;
            if (Math.Abs(xEnd - xStart) == 1 && Math.Abs(yEnd - yStart) == 1)
            {
                if (playerColor.CompareTo('O') == 0 && !gameBoard.Board[xStart, yStart].IsKing)
                {
                    if (xEnd < xStart)
                    {
                        isSimpleMove = false;
                    }
                }
                else if (playerColor.CompareTo('X') == 0 && !gameBoard.Board[xStart, yStart].IsKing)
                {
                    if (xEnd > xStart)
                    {
                        isSimpleMove = false;
                    }
                }
            }
            else
            {
                isSimpleMove = false;
            }
            return isSimpleMove;
        }

        // Check if the move is a jump legal
        public static bool IsJump(GameBoard gameBoard, char playerColor, int xStart,
            int yStart, int xEnd, int yEnd)
        {
            bool isJump = true;
            if (Math.Abs(xEnd - xStart) == 2 && Math.Abs(yEnd - yStart) == 2)
            {
                int xMidlle = (xStart + xEnd) / 2;
                int yMidlle = (yStart + yEnd) / 2;
                if (!MoveIsInbound(gameBoard, xStart, yStart, xEnd, yEnd))
                {
                    isJump = false;
                }
                else if (playerColor.CompareTo('O') == 0)
                {
                    if (xEnd < xStart && !gameBoard.Board[xStart, yStart].IsKing)
                    {
                        isJump = false;
                    } else if (!IsTileFree(gameBoard, xEnd, yEnd)
                        || IsTileFree(gameBoard, xMidlle, yMidlle) ||
                        CoinExistAtLocation(gameBoard, xMidlle, yMidlle, playerColor))
                    {
                        isJump = false;
                    }
                }
                else if (playerColor.CompareTo('X') == 0)
                {
                    if (xEnd > xStart && !gameBoard.Board[xStart, yStart].IsKing)
                    {
                        isJump = false;
                    } else if (!IsTileFree(gameBoard, xEnd, yEnd)
                        || IsTileFree(gameBoard, xMidlle, yMidlle) ||
                        CoinExistAtLocation(gameBoard, xMidlle, yMidlle, playerColor))
                    {
                        isJump = false;
                    }
                } 
            }
            else
            {
                isJump = false;
            }
            return isJump;
        }

        // Check if the player can eat an opponent
        public static bool NoOpponentToEat(GameBoard gameBoard, char playerColor)
        {
            bool noOpponentToEat = true;
            char opponentColor = 'O';
            if (playerColor.CompareTo('O') == 0)
            {
                opponentColor = 'X';
            }

            for (int i = 1; i < gameBoard.BoardSize - 1; i++)
            {
                for (int j = 1; j < gameBoard.BoardSize - 1; j++)
                {
                    if (tileOccupiedByColor(gameBoard, i, j, playerColor))
                    {

                        // Check if element need to go up or down
                        if (playerColor.CompareTo('X') == 0 || gameBoard.Board[i, j].IsKing)

                        {
                            if (isNeighborOccupyByOpponent(gameBoard, i, j, i - 2, j + 2, i - 1, j + 1,
                                playerColor, opponentColor))
                            {
                                noOpponentToEat = false;
                                goto end;
                            }
                            if (isNeighborOccupyByOpponent(gameBoard, i, j, i - 2, j - 2, i - 1, j - 1,
                                playerColor, opponentColor))
                            {
                                noOpponentToEat = false;
                                goto end;
                            }
                        }
                        if (playerColor.CompareTo('O') == 0|| gameBoard.Board[i, j].IsKing)

                        {
                            if (isNeighborOccupyByOpponent(gameBoard, i, j, i + 2, j + 2, i + 1, j + 1,
                                playerColor, opponentColor))
                            {
                                noOpponentToEat = false;
                                goto end;
                            }
                            if (isNeighborOccupyByOpponent(gameBoard, i, j, i + 2, j - 2, i + 1, j - 1,
                                playerColor, opponentColor))
                            {
                                noOpponentToEat = false;
                                goto end;
                            }
                        }
                    }
                }
            }
        end:
            return noOpponentToEat;
        }

        // Check if the neighbor of the coin is occupied by opponent
        private static bool isNeighborOccupyByOpponent(GameBoard gameBoard, int xStart, int yStart,
            int xEnd, int yEnd, int xMiddle, int yMiddle, char playerColor, char opponentColor)
        {
            bool o_isNeighborOccupyByOpponent = false;
            if (tileOccupiedByColor(gameBoard, xMiddle, yMiddle, opponentColor)
                && !coinIsAtBorderOfBoard(gameBoard, xMiddle, yMiddle)
                && IsTileFree(gameBoard, xEnd, yEnd))
            {
                if (IsJump(gameBoard, playerColor, xStart, yStart, xEnd, yEnd))
                {
                    o_isNeighborOccupyByOpponent = true;

                }
            }

                return o_isNeighborOccupyByOpponent;
        }

        // Check if the coin is at one of the extremity of the board
        private static bool coinIsAtBorderOfBoard(GameBoard gameBoard, int xPoint, int yPoint)
        {
            bool coinIsAtBorderOfBoard = false;
            if ((xPoint <= 1) || (yPoint <= 1) || (xPoint >= (gameBoard.BoardSize - 2)) || (yPoint >= (gameBoard.BoardSize - 2)))
            {
                coinIsAtBorderOfBoard = true;
            }

            return coinIsAtBorderOfBoard;
        }

        // Check that the move are in the bound of board game 
        public static bool MoveIsInbound(GameBoard gameBoard, int xStart,
            int yStart, int xEnd, int yEnd)
        {
            bool moveIsInBound = true;

            if (xStart > gameBoard.BoardSize - 2 || xStart <= 0)
            {
                moveIsInBound = false;
            }
            else if (yStart > gameBoard.BoardSize - 2 || yStart <= 0)
            {
                moveIsInBound = false;
            }
            else if (xEnd > gameBoard.BoardSize - 2 || xEnd <= 0)
            {
                moveIsInBound = false;
            }
            else if (yEnd > gameBoard.BoardSize - 2 || yEnd <= 0)
            {
                moveIsInBound = false;
            }
            return moveIsInBound;

        }

        // Check if another jump is possible
        public static bool IsJumpAvalaible(GameBoard gameBoard, char playerColor,
            int xPoint, int yPoint)
        {
            bool o_isJumpAvailable = false;
            // Check if the coin is a king
            bool isKing = gameBoard.Board[xPoint, yPoint].IsKing;
            bool isX = true;
            // Check the color of the coin
            if (gameBoard.Board[xPoint, yPoint].CoinColor.CompareTo('O') == 0)
            {
                isX = false;
            }
            // If the element is a king enter the two if and check 4 options if not check the only two option available for it
            if (isKing || isX)
            {
                if (MoveIsInbound(gameBoard, xPoint, yPoint, xPoint - 2, yPoint - 2))
                { 
                    if ( IsJump(gameBoard, playerColor, xPoint, yPoint, xPoint - 2, yPoint - 2))
                    {
                        o_isJumpAvailable = true;
                    }
                }
                if (MoveIsInbound(gameBoard, xPoint, yPoint, xPoint - 2, yPoint + 2))
                {
                    if (IsJump(gameBoard, playerColor, xPoint, yPoint, xPoint - 2, yPoint + 2))
                    {
                        o_isJumpAvailable = true;

                    }
                }
                
            }
            if (isKing || !isX)
            {
                if (MoveIsInbound(gameBoard, xPoint, yPoint, xPoint + 2, yPoint - 2))
                {
                    if (IsJump(gameBoard, playerColor, xPoint, yPoint, xPoint + 2, yPoint - 2))
                    {
                        o_isJumpAvailable = true;
                    }
                }
                if (MoveIsInbound(gameBoard, xPoint, yPoint, xPoint + 2, yPoint + 2))
                {
                    if (IsJump(gameBoard, playerColor, xPoint, yPoint, xPoint + 2, yPoint + 2))
                    {
                        o_isJumpAvailable = true;

                    }
                }
            }
            return o_isJumpAvailable;
        }

        // Check if pawn become king
        public static bool ShouldTurnKing(GameBoard gameBoard, int xPoint, int yPoint)
        {
            bool o_shouldTurnKing = true;
            // Check if already king
            if (gameBoard.Board[xPoint, yPoint].IsKing)
            {
                o_shouldTurnKing = false;
                // Check if color O is go to the last row
            } else if (gameBoard.Board[xPoint, yPoint].CoinColor.CompareTo('O') == 0)
            {
                if (xPoint != gameBoard.BoardSize - 2)
                {
                    o_shouldTurnKing = false;
                }
                // Check if color X is go to the first row
            }
            else
            {
                if (xPoint != 1)
                {
                    o_shouldTurnKing = false;
                }
            }
            return o_shouldTurnKing;
        }

        //Computer part

        // Randomly choose the next move of the computer
        public static int[] NextMoveComputer(GameBoard gameBoard, Player player)
        {
            int[] o_nextMove = new int[2];
            Random random = new Random();
            ArrayList allMovePossible = AllMovePossible(gameBoard, player);
            // Do the random selection
            int numberMovePossible = allMovePossible.Count;
            int indexMove = random.Next(numberMovePossible);
            o_nextMove = (int[])allMovePossible[indexMove];
            return o_nextMove;
        }

        // Send all the possible move possible
        public static ArrayList AllMovePossible(GameBoard gameBoard, Player player)
        {
            ArrayList o_allMovePossible = new ArrayList(new ArrayList());
            bool isJumpPossible = NoOpponentToEat(gameBoard, player.Color);
            if (isJumpPossible)
            {
                o_allMovePossible = allJumpAvailable(gameBoard, player);
            } else
            {
                o_allMovePossible = allSimpleMoveAvailable(gameBoard, player);
            }         
            return o_allMovePossible;
        }

        // A case a jump can happen, send all the jump possible
        private static ArrayList allJumpAvailable(GameBoard gameBoard, Player player)
        {
            ArrayList o_allJumpAvailable = new ArrayList();

            for (int i = 1; i < gameBoard.BoardSize - 1; i++)
            {
                for (int j = 1; j < gameBoard.BoardSize - 1; j++)
                {
                    if (tileOccupiedByColor(gameBoard, i, j, player.Color))
                    {
                        bool isKing = gameBoard.Board[i, j].IsKing;
                       
                        if (isKing || (gameBoard.Board[i, j].CoinColor.CompareTo('X') == 0))
                        {
                            if (MoveIsInbound(gameBoard, i, j, i - 2, j - 2) &&
                                IsJump(gameBoard, player.Color, i, j, i - 2, j - 2))
                            {
                                o_allJumpAvailable.Add(new ArrayList() { i - 2, j - 2 });
                            }
                              if (MoveIsInbound(gameBoard, i, j, i - 2, j + 2) &&
                                IsJump(gameBoard, player.Color, i, j, i - 2, j + 2))
                            {
                                o_allJumpAvailable.Add(new ArrayList() { i - 2, j + 2 });

                            }
                        }
                        if (isKing || (gameBoard.Board[i, j].CoinColor.CompareTo('O') == 0))
                        {
                            if (MoveIsInbound(gameBoard, i, j, i + 2, j - 2) &&
                                IsJump(gameBoard, player.Color, i, j, i + 2, j - 2))
                            {
                                o_allJumpAvailable.Add(new ArrayList() { i + 2, j - 2 });
                            }
                            if (MoveIsInbound(gameBoard, i, j, i + 2, j + 2) &&
                                IsJump(gameBoard, player.Color, i, j, i + 2, j + 2))
                            {
                                o_allJumpAvailable.Add(new ArrayList() { i + 2, j + 2 });

                            }
                        }

                    }
                }
            }
            return o_allJumpAvailable;
        }

        // Check all possible single move possible, and return all of them
        private static ArrayList allSimpleMoveAvailable(GameBoard gameBoard, Player player)
        {
            ArrayList o_allSimpleMoveAvailable = new ArrayList();

            for (int i = 1; i < gameBoard.BoardSize - 1; i++)
            {
                for (int j = 1; j < gameBoard.BoardSize - 1; j++)
                {
                    if (tileOccupiedByColor(gameBoard, i, j, player.Color))
                    {
                        bool isKing = gameBoard.Board[i, j].IsKing;

                        if (isKing || (gameBoard.Board[i, j].CoinColor.CompareTo('X') == 0))
                        {
                            if (MoveIsInbound(gameBoard, i, j, i - 1, j - 1) &&
                                IsSimpleMove(gameBoard,player.Color, i, j, i - 1, j - 1))
                            {
                                o_allSimpleMoveAvailable.Add(new ArrayList() { i - 1, j - 1 });
                            }
                            if (MoveIsInbound(gameBoard, i, j, i - 1, j + 1) &&
                              IsSimpleMove(gameBoard, player.Color, i, j, i - 1, j + 1))
                            {
                                o_allSimpleMoveAvailable.Add(new ArrayList() { i - 1, j + 1 });

                            }
                        }
                        if (isKing || (gameBoard.Board[i, j].CoinColor.CompareTo('O') == 0))
                        {
                            if (MoveIsInbound(gameBoard, i, j, i + 1, j - 1) &&
                                IsSimpleMove(gameBoard, player.Color, i, j, i + 1, j - 1))
                            {
                                o_allSimpleMoveAvailable.Add(new ArrayList() { i + 1, j - 1 });
                            }
                            if (MoveIsInbound(gameBoard, i, j, i + 1, j + 1) &&
                                IsSimpleMove(gameBoard, player.Color, i, j, i + 1, j + 1))
                            {
                                o_allSimpleMoveAvailable.Add(new ArrayList() { i + 1, j + 1 });

                            }
                        }

                    }
                }
            }
            return o_allSimpleMoveAvailable;
        }

        // Check if the next has a move possible if not return draw
        public static bool IsDraw(GameBoard gameBoard, Player player)
        {
            bool o_isDraw = true;
            ArrayList allMovePossible = AllMovePossible(gameBoard, player);
            if (allMovePossible.Count != 0)
            {
                o_isDraw = false;
            }
            return o_isDraw;
        }
    }
}

