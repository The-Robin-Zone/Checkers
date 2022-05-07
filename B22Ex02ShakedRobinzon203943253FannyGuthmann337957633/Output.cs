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
                        Console.Write("| " + boardGame.Board[i, j].CoinColor + " ");
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
            Console.WriteLine("Color: " + player1.Color);
            Console.WriteLine("");
            Console.WriteLine("Player 2:");
            Console.WriteLine("Name: " + player2.PlayerName);
            Console.WriteLine("Score: " + player2.Score);
            Console.WriteLine("Color: " + player2.Color);
            Console.WriteLine("");
            Console.WriteLine("Game Board:");
            Console.WriteLine("");
            Print2DArray(gameBoard);
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        public static void PrintInstructions()
        {
            Console.WriteLine("");
            Console.WriteLine("Game instructions:");

            Console.WriteLine("1. Each pawn can move forward only, one square at a time in a diagonal direction, to an unoccupied square.");
            Console.WriteLine("2. Player 1 (O pawns) plays first");
            Console.WriteLine("3. The object of the game is to prevent the opponent from being able to move when it is his turn to do so. \nThis is accomplished either by capturing all of the opponent's pawns, or by blocking those that remain so that none of them can be moved. \nIf neither player can accomplish this, the game is a draw.");
            Console.WriteLine("4. Pawn capture by jumping over an opposing pawn on a diagonally adjacent square to the square immediately beyond, but may do so only if this square is unoccupied.");
            Console.WriteLine("5. Pawn may jump forward only, and may continue jumping as long as they encounter opposing pawns with unoccupied squares immediately beyond them. \nPawn may never jump over a pawn of the same color.");
            Console.WriteLine("6. A pawn which reaches the far side of the board, whether by means of a jump or a simple move, becomes a King,");
            Console.WriteLine("7. Kings can move forward or backward, one square at a time in a diagonal direction to an unoccupied square.");
            Console.WriteLine("8. Whenever a player is able to make a capture he must do so. \nWhen there is more than one way to jump, a player may choose any way he wishes, not necessarily the one which results in the capture of the greatest number of opposing units. \nHowever, once a player chooses asequence of captures, he must make all the captures possible in that sequence.");
            Console.WriteLine("");
            Console.WriteLine("Press any key to continue");
            Console.WriteLine("");
            Console.ReadLine();
        }

        public static void InvalidinputPrompt()
        {
            Console.WriteLine("Please enter a valid input");
        }

        public static void EndGamePrompt()
        {
            Console.WriteLine("Thank you for playing!");
            Console.ReadLine();
        }

        public static void EndRoundPrompt()
        {
            Console.WriteLine("Game has ended!");
            Console.WriteLine("Press 'q' to quit or 'n' for new game:");
        }
    }
}
