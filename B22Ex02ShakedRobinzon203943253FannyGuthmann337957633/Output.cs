using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Output
    {
        public Output()
        {

        }

        public static void Print2DArray(char[,] boardGame, int arrayDimention)
        {
            
            char columnPrint = 'A';
            char rowPrint = 'a';
            // Print Column letters
            Console.Write("  ");
            for (int i = 0; i < arrayDimention; i++)
            {

                Console.Write(" " + (char)(columnPrint+i) + "  ");
            }

        Console.WriteLine("");
        PrintRowSeperator(arrayDimention);

            for (int i = 1; i < arrayDimention + 1; i++)
            {
            Console.Write((char)(rowPrint + i - 1));
                for (int j = 1; j < arrayDimention +1; j++)
                {
                    if (boardGame[i, j] != 'O' && boardGame[i, j] != 'X')
                    {
                        Console.Write("|   ");
                    }
                    else
                    {
                        Console.Write("| " + boardGame[i,j] + " ");
                    }
                    
               
                }
                Console.WriteLine("|");
                PrintRowSeperator(arrayDimention);
            }
            
        }
        public static void PrintRowSeperator(int boardSize)
        {
            Console.Write(" ");
            for (int i = 0; i < (boardSize * 4); i++)
            {
                Console.Write("=");
                
            }
            Console.WriteLine("");
        }
    }
}
