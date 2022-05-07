using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Output
    {
        public Output()
        {

        }

        public static void Print2DArray(GameBoard boardGame)
        {

       
            char columnPrint = 'A';
            char rowPrint = 'a';

            // Print Column letters
            Console.Write("  ");
            for (int i = 0; i < boardGame.BoardSize - 2; i++)
            {
                Console.Write(" " + (char)(columnPrint+i) + "  ");
            }

        Console.WriteLine("");
        PrintRowSeperator(boardGame.BoardSize);

            for (int i = 1; i < boardGame.BoardSize - 1; i++)
            {

            // Print row index
            Console.Write((char)(rowPrint + i - 1));

                for (int j = 1; j < boardGame.BoardSize - 1; j++)
                {
                    if (boardGame.Board[i,j] != null)
                    {
                        Console.Write("| " + (char)boardGame.Board[i, j].CoinColor + " ");
                    }
                    else
                    {
                        Console.Write("|   ");
                    }
                    
               
                }
                Console.WriteLine("|");
                PrintRowSeperator(boardGame.BoardSize);
            }
            
        }
        public static void PrintRowSeperator(int boardSize)
        {
            Console.Write(" ");

            if (boardSize == 12)
            {
                Console.Write("=========================================");
            }

            if (boardSize == 10)
            {
                Console.Write("=================================");
            }

            if (boardSize == 8)
            {
                Console.Write("=========================");
            }

            Console.WriteLine("");  
        }

        public static void CurrentGameStatus(Player player1, Player player2, GameBoard gameBoard)
        {
            Console.WriteLine("This is the current game status:");

            Console.WriteLine("Player 1:");
            Console.WriteLine("Name: " + player1.PlayerName);
            Console.WriteLine("Score: " + player1.Score);
            Console.WriteLine("");
            Console.WriteLine("Player 2:");
            Console.WriteLine("Name: " + player2.PlayerName);
            Console.WriteLine("Score: " + player2.Score);
            Console.WriteLine("");

            Print2DArray(gameBoard);
        }

        public static void PrintInstructions()
        {
            Console.WriteLine("");
            Console.WriteLine("These are in instructions:");
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }
    }
}
