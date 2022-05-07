using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Logic
    {
        public static bool MoveIsValid(GameBoard gameBoard, string location, Player player)
        {
            bool o_typeMove = true;
            int xStartingPoint = location[1] - 'A' + 1;
            int yStartingPoint = location[0] - 'a' + 1;
            int xEndingPoint = location[4] - 'A' + 1;
            int yEndingPoint = location[3] - 'a' + 1;

            // Check starting point is not empty and is the rigth color
            if (MoveIsInbound(gameBoard, xStartingPoint, yStartingPoint, xEndingPoint, yEndingPoint))
            {
                o_typeMove = false;

            }
            else if (SquareIsFree(gameBoard, xStartingPoint, yStartingPoint))
            {
                o_typeMove = false;
                // Check destination tile to be free
            }
            else if (!SquareIsFree(gameBoard, xEndingPoint, yEndingPoint))
            {
                o_typeMove = false;
            }
            else
            {

                if (!IsSimpleMove(player.Color, xStartingPoint, yStartingPoint, xEndingPoint, yEndingPoint))
                {
                    o_typeMove = false;
                }
                else if (IsJump(gameBoard, player.Color, xStartingPoint, yStartingPoint, xEndingPoint, yEndingPoint))
                {
                    o_typeMove = false;
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


        public static bool IsSimpleMove(char playerColor, int xStartingPoint,
            int yStartingPoint, int xEndingPoint, int yEndingPoint)
        {
            bool isSimpleMove = true;
            if (Math.Abs(xEndingPoint - xStartingPoint) == 1 &&
                Math.Abs(yEndingPoint - yStartingPoint) == 1)
            {
                if (playerColor.CompareTo('O') == 0)
                {
                    if (yEndingPoint < yStartingPoint)
                    {
                        isSimpleMove = false;
                    }
                }
                else if (playerColor.CompareTo('X') == 0)
                {
                    if (yEndingPoint > yStartingPoint)
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

        public static bool IsJump(GameBoard gameBoard, char playerColor, int xStartingPoint,
            int yStartingPoint, int xEndingPoint, int yEndingPoint)
        {
            bool isJump = true;
            if (Math.Abs(xEndingPoint - xStartingPoint) == 2 &&
                Math.Abs(yEndingPoint - xStartingPoint) == 2)
            {
                int xMidllePoint = (xStartingPoint + xEndingPoint) / 2;
                int yMidllePoint = (yStartingPoint + yEndingPoint) / 2;
                if (playerColor.CompareTo('O') == 0)
                {
                    if (yEndingPoint > yStartingPoint)
                    {
                        isJump = false;
                    }
                    else if (!CoinExistAtLocation(gameBoard, xMidllePoint, yMidllePoint, playerColor))
                    {
                        isJump = false;
                    }
                }
                else if (playerColor.CompareTo('X') == 0)
                {
                    if (yEndingPoint < yStartingPoint)
                    {
                        isJump = false;
                    }
                    else if (!CoinExistAtLocation(gameBoard, xMidllePoint, yMidllePoint, playerColor))
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

        public static bool MoveIsInbound(GameBoard gameBoard, int xStartingPoint,
            int yStartingPoint, int xEndingPoint, int yEndingPoint)
        {
            bool moveIsInBound = true;

            if (xStartingPoint>= 'A' + gameBoard.BoardSize - 2)
            {
                moveIsInBound = false;
            }
            else if (yStartingPoint >= 'a' + gameBoard.BoardSize - 2)
            {
                moveIsInBound = false;
            }
            else if (xEndingPoint >= 'A' + gameBoard.BoardSize - 2)
            {
                moveIsInBound = false;
            }
            else if (yEndingPoint >= 'a' + gameBoard.BoardSize - 2)
            {
                moveIsInBound = false;
            }
            return moveIsInBound;

        }


    }



}

