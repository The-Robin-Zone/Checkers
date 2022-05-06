using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Output
    {
        public Output()
        {

        }
        public static void Print2DArray(char[,] boardGame)
        {
            for (int i = 1; i < boardGame.Length - 3; i++)
            {
                for (int j = 1; j < boardGame.Length - 3; j++)
                {
                    Console.WriteLine("shaked");
                }
            }
        }
    }
}
