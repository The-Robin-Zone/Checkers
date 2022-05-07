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
            for (int i = 0; i < (boardSize * 3.5); i++)
            {
                Console.Write("=");
                
            }
            Console.WriteLine("");
        }
    }
}
