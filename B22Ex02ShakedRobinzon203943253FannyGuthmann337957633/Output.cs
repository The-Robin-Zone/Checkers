using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Output
    {

        public static void Print2DArray(GameBoard i_BoardGame)
        {
            char columnPrint = 'A';
            char rowPrint = 'a';

            // Print column index
            Console.Write("  ");
            for (int i = 0; i < i_BoardGame.BoardSize - 2; i++)
            {
                Console.Write(" " + (char)(columnPrint+i) + "  ");
            }

            Console.WriteLine();
            PrintRowSeperator(i_BoardGame.BoardSize);

            for (int i = 1; i < i_BoardGame.BoardSize - 1; i++)
            {

                // Print row index
                Console.Write((char)(rowPrint + i - 1));

                for (int j = 1; j < i_BoardGame.BoardSize - 1; j++)
                {
                    if (i_BoardGame.Board[i,j] != null)
                    {
                        Console.Write("| " + i_BoardGame.Board[i, j].CoinColor + " ");
                    }
                    else
                    {
                        Console.Write("|   ");
                    }
                }

                Console.WriteLine("|");
                PrintRowSeperator(i_BoardGame.BoardSize);
            }  
        }

        public static void PrintRowSeperator(int i_BoardSize)
        {
            Console.Write(" ");

            if (i_BoardSize == 12)
            {
                Console.Write("=========================================");
            }

            if (i_BoardSize == 10)
            {
                Console.Write("=================================");
            }

            if (i_BoardSize == 8)
            {
                Console.Write("=========================");
            }

            Console.WriteLine();  
        }

        public static void CurrentGameStatus(Player i_Player1, Player i_Player2)
        {
            Console.WriteLine("This is the current game status:");
            Console.WriteLine();
            Console.WriteLine("Player 1:");
            Console.WriteLine("Name: " + i_Player1.PlayerName);
            Console.WriteLine("Score: " + i_Player1.Score);
            Console.WriteLine("Color: " + i_Player1.Color);
            Console.WriteLine();
            Console.WriteLine("Player 2:");
            Console.WriteLine("Name: " + i_Player2.PlayerName);
            Console.WriteLine("Score: " + i_Player2.Score);
            Console.WriteLine("Color: " + i_Player2.Color);
            Console.WriteLine();
        }

        public static void PrintInstructions()
        {
            Console.WriteLine();
            Console.WriteLine("Game instructions:");
            Console.WriteLine();
            Console.WriteLine("1. Each pawn can move forward only, one square at a time in a diagonal direction, to an unoccupied square.");
            Console.WriteLine("2. Player 1 (O pawns) plays first");
            Console.WriteLine("3. The object of the game is to prevent the opponent from being able to move when it is his turn to do so. \nThis is accomplished either by capturing all of the opponent's pawns, or by blocking those that remain so that none of them can be moved. \nIf neither player can accomplish this, the game is a draw.");
            Console.WriteLine("4. Pawn capture by jumping over an opposing pawn on a diagonally adjacent square to the square immediately beyond, but may do so only if this square is unoccupied.");
            Console.WriteLine("5. Pawn may jump forward only, and may continue jumping as long as they encounter opposing pawns with unoccupied squares immediately beyond them. \nPawn may never jump over a pawn of the same color.");
            Console.WriteLine("6. A pawn which reaches the far side of the board, whether by means of a jump or a simple move, becomes a King,");
            Console.WriteLine("7. Kings can move forward or backward, one square at a time in a diagonal direction to an unoccupied square.");
            Console.WriteLine("8. Whenever a player is able to make a capture he must do so. \nWhen there is more than one way to jump, a player may choose any way he wishes, not necessarily the one which results in the capture of the greatest number of opposing units. \nHowever, once a player chooses a sequence of captures, he must make all the captures possible in that sequence.");
            PressToContinuePrompt();
        }

        public static void InvalidInputPrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Please enter a valid input");
            Console.WriteLine();
        }

        public static void MoveSyntaxPrompt()
        {
            Console.WriteLine();
            Console.WriteLine("A Move should be in the following format: COLrow>COLrow");
            Console.WriteLine("for example: Af>Be");
            Console.WriteLine("You can enter q to exit");
            Console.WriteLine();
        }

        public static void EndGamePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Thank you for playing!");
            Console.ReadLine();
        }

        public static void EndRoundPrompt(string i_WinnerName)
        {
            Console.WriteLine();
            Console.WriteLine("Game has ended!");
            Console.WriteLine(i_WinnerName + " won!");
            Console.WriteLine("Press 'q' to quit or 'n' for new game:");
            Console.WriteLine();
        }

        public static void LimitedTurnPrompt()
        {
            Console.WriteLine();
            Console.WriteLine("You must continue capturing! enter another move:");
            Console.WriteLine();
        }

        public static void PressToContinuePrompt()
        {
            Console.WriteLine();
            Console.WriteLine("Press any key to continue");
            Console.ReadLine();
        }

        public static void MustCapturePromt()
        {
            Console.WriteLine();
            Console.WriteLine("You must capture opponent Coin!");
            Console.WriteLine();
        }
    }
}
