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
            //Console.WriteLine(boardGame.Length);
            //Console.WriteLine(boardGame[1, 2]);
            //Console.WriteLine(boardGame[1, 4]);
            //Console.WriteLine(boardGame[1, 6]);

            for (int i = 1; i < arrayDimention + 1; i++)
            {
                //Console.WriteLine("i index is: " + i);
                for (int j = 1; j < arrayDimention +1; j++)
                {
                    //Console.WriteLine("j index is: " + j);
                    if (boardGame[i, j] != 'O' && boardGame[i, j] != 'X')
                    {
                        Console.Write("-");
                    }
                    else
                    {
                        Console.Write(boardGame[i,j]);
                    }
                    
               
                }
                Console.WriteLine();
            }
        }
    }
}
