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

            // Check starting point is not empty and is the rigth color
            if (!MoveIsInbound(gameBoard, xStart, yStart, xEnd, yEnd))
            {
                o_typeMove = false;
            }
            else if (SquareIsFree(gameBoard, xStart, yStart))
            {
                o_typeMove = false;
                // Check destination tile to be free
            }
            else if (!SquareIsFree(gameBoard, xEnd, yEnd))
            {
                o_typeMove = false;
            }
            else
            {
                o_typeMove = false;
                if (IsSimpleMove(player.Color, xStart, yStart, xEnd, yEnd))
                {
                    o_typeMove = true;
                }
                else if (IsJump(gameBoard, player.Color, xStart, yStart, xEnd, yEnd))
                {
                    o_typeMove = true;
                }
            }
            return o_typeMove;
        }


        public static bool CoinExistAtLocation(GameBoard gameBoard,
            int xPoint, int yPoint, char playerColor)
        {
            bool o_coinExistAtLocation = true;

            if (gameBoard.Board[xPoint, yPoint] == null ||
            gameBoard.Board[xPoint, yPoint].CoinColor.CompareTo(playerColor) == 0)
            {
                o_coinExistAtLocation = false;
            }
            return o_coinExistAtLocation;
        }


        public static bool SquareIsFree(GameBoard gameBoard,
            int xPoint, int yPoint)
        {
            bool o_coinDestinationIsFree = true;

            if (gameBoard.Board[xPoint, yPoint] != null)
            {
                o_coinDestinationIsFree = false;
            }

            return o_coinDestinationIsFree;
        }


        public static bool IsSimpleMove(char playerColor, int xStart,
            int yStart, int xEnd, int yEnd)
        {
            bool isSimpleMove = true;
            if (Math.Abs(xEnd - xStart) == 1 && Math.Abs(yEnd - yStart) == 1)
            {
                if (playerColor.CompareTo('O') == 0)
                {
                    if (yEnd < yStart)
                    {
                        isSimpleMove = false;
                    }
                }
                else if (playerColor.CompareTo('X') == 0)
                {
                    if (yEnd > yStart)
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
                    if (yEnd < yStart)
                    {
                        isJump = false;
                    }
                    else if (!CoinExistAtLocation(gameBoard, xMidlle, yMidlle, playerColor))
                    {
                        isJump = false;
                    }
                }
                else if (playerColor.CompareTo('X') == 0)
                {
                    if (yEnd > yStart)
                    {
                        isJump = false;
                    }
                    else if (!CoinExistAtLocation(gameBoard, xMidlle, yMidlle, playerColor))
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
            for (int i = 1; i < gameBoard.BoardSize - 1; i++)
            {
                for (int j = 1; j < gameBoard.BoardSize - 1; j++)
                {
                    if (CoinExistAtLocation(gameBoard, i, j, playerColor) &&
                        (CoinExistAtLocation(gameBoard, i + 1, j + 1, playerColor)
                        || CoinExistAtLocation(gameBoard, i - 1, j + 1, playerColor)))
                    {
                        noOpponentToEat = false;
                        goto end;
                    }
                }
            }
        end:
            return noOpponentToEat;
        }

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

