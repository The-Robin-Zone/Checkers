using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class GameBoard
    {

    private Coin[,] board;
    private int boardSize;

        public GameBoard(int i_boardSize)
        {
            this.boardSize = i_boardSize + 2;
            this.board = new Coin[this.boardSize, this.boardSize];
        }

        public Coin[,] Board
        {
            get
            {
                return this.board;
            }

            set
            {
                this.board = value;
            }
        }

        public int BoardSize
        {
            get
            {
                return this.boardSize;
            }

            set
            {
                this.boardSize = value;
            }
        }

        public Coin[,] initializeBoard()
        {
            int numOfCoinRows = ((this.boardSize - 2) / 2) - 1;
     

            //initialize O Coins
            for (int i = 1; i < numOfCoinRows + 1; i++)
            {
                for (int j = 1; j < this.boardSize - 1; j++)
                {
                    // odd row & even column
                    if (i % 2 != 0 && j % 2 == 0)
                    {
                        this.board[i, j] = new Coin('O');
                    }

                    // even row & odd column
                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        this.board[i, j] = new Coin('O');
                    }

                }
            }
            //initialize X Coins
            for (int i = this.boardSize - 2; i > numOfCoinRows + 2; i--)
            {
                for (int j = 1; j < this.boardSize - 1; j++)
                {
                    // odd row & even column
                    if (i % 2 != 0 && j % 2 == 0)
                    {
                        this.board[i, j] = new Coin('X');
                    }

                    // even row & odd column
                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        this.board[i, j] = new Coin('X');
                    }

                }
            }

            return this.board;
        }
    }
}
