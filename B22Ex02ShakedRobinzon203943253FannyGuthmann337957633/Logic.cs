using System;
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
                if (IsSimpleMove(player.Color, xStart, yStart, xEnd, yEnd))
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

        // Check that the move is a simple legal move
        public static bool IsSimpleMove(char playerColor, int xStart,
            int yStart, int xEnd, int yEnd)
        {
            bool isSimpleMove = true;
            if (Math.Abs(xEnd - xStart) == 1 && Math.Abs(yEnd - yStart) == 1)
            {
                if (playerColor.CompareTo('O') == 0)
                {
                    if (xEnd < xStart)
                    {
                        isSimpleMove = false;
                    }
                }
                else if (playerColor.CompareTo('X') == 0)
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
                if (playerColor.CompareTo('O') == 0)
                {
                    if (xEnd < xStart)
                    {
                        isJump = false;
                    } else if (IsTileFree(gameBoard, xMidlle, yMidlle) ||
                        CoinExistAtLocation(gameBoard, xMidlle, yMidlle, playerColor))
                    {
                        isJump = false;
                    }
                }
                else if (playerColor.CompareTo('X') == 0)
                {
                    if (xEnd > xStart)
                    {
                        isJump = false;
                    } else if (IsTileFree(gameBoard, xMidlle, yMidlle) ||
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
                    if (tileOccupiedByRightColor(gameBoard, i, j, opponentColor))
                    {
                        if (playerColor.CompareTo('X') == 0)
                        {
                            
                            // If color is X need to go down
                            if (tileOccupiedByRightColor(gameBoard, i - 1, j + 1, playerColor) ||
                               tileOccupiedByRightColor(gameBoard, i - 1, j - 1, playerColor))
                            {
                                noOpponentToEat = false;
                                goto end;
                            }
                        }
                        else
                        {
                            // If color is O need to go up
                            if (tileOccupiedByRightColor(gameBoard, i + 1, j + 1, playerColor) ||
                                tileOccupiedByRightColor(gameBoard, i + 1, j - 1, playerColor))
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


        private static bool tileOccupiedByRightColor(GameBoard gameBoard, int xPoint, int yPoint, char playerColor)
        {
            bool tileIsnotEmptyAndOccupyByRightColor = true;
            if (IsTileFree(gameBoard, xPoint, yPoint))
            {
                tileIsnotEmptyAndOccupyByRightColor = false;
            }
            else if (CoinExistAtLocation(gameBoard, xPoint, yPoint, playerColor))
            {
                tileIsnotEmptyAndOccupyByRightColor = false;
            }
            return tileIsnotEmptyAndOccupyByRightColor;
        }


        // Check that the move are in the bound of board game 
        public static bool MoveIsInbound(GameBoard gameBoard, int xStart,
            int yStart, int xEnd, int yEnd)
        {
            bool moveIsInBound = true;

            if (xStart > gameBoard.BoardSize - 2)
            {
                moveIsInBound = false;
            }
            else if (yStart > gameBoard.BoardSize - 2)
            {
                moveIsInBound = false;
            }
            else if (xEnd > gameBoard.BoardSize - 2)
            {
                moveIsInBound = false;
            }
            else if (yEnd > gameBoard.BoardSize - 2)
            {
                moveIsInBound = false;
            }
            return moveIsInBound;

        }


    }



}

