using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Program
    {
        public static void Main()
        {
            initializeGame();
        }

    public static void initializeGame()
        {
            Console.WriteLine("Welcome to Checkers!");
            Console.WriteLine("Please choose number of players: 1/2");
            int numberOfPlayers = input.numberOfPlayers;
            if ( numberOfPlayers == 2)
            {
                Console.WriteLine("Not supported yet");
                initializeGame();
            }
            
            input.enterName();

        }
    }
}
