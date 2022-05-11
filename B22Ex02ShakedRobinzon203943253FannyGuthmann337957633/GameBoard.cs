using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class GameBoard
    {
    private Coin[,] m_Board;
    private int m_BoardSize;

        public GameBoard(int i_boardSize)
        {
            this.m_BoardSize = i_boardSize + 2;
            this.m_Board = new Coin[this.m_BoardSize, this.m_BoardSize];
        }

        public Coin[,] Board
        {
            get
            {
                return this.m_Board;
            }

            set
            {
                this.m_Board = value;
            }
        }

        public int BoardSize
        {
            get
            {
                return this.m_BoardSize;
            }

            set
            {
                this.m_BoardSize = value;
            }
        }

        public Coin[,] InitializeBoard()
        {
            int numOfCoinRows = ((this.m_BoardSize - 2) / 2) - 1;
     

            //initialize 'O' Coins
            for (int i = 1; i < numOfCoinRows + 1; i++)
            {
                for (int j = 1; j < this.m_BoardSize - 1; j++)
                {
                    if (i % 2 != 0 && j % 2 == 0)
                    {
                        this.m_Board[i,j] = new Coin('O');
                    }

                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        this.m_Board[i,j] = new Coin('O');
                    }
                }
            }

            //initialize X Coins
            for (int i = this.m_BoardSize - 2; i > numOfCoinRows + 2; i--)
            {
                for (int j = 1; j < this.m_BoardSize - 1; j++)
                {
                    if (i % 2 != 0 && j % 2 == 0)
                    {
                        this.m_Board[i,j] = new Coin('X');
                    }

                    if (i % 2 == 0 && j % 2 != 0)
                    {
                        this.m_Board[i,j] = new Coin('X');
                    }
                }
            }

            return this.m_Board;
        }

        public Coin[,] ClearBoard()
        {
            for (int i = 0; i < this.m_BoardSize; i++)
            {
                for (int j = 0; j < this.m_BoardSize; j++)
                {
                    this.m_Board[i,j] = null;
                }
            }

            return this.m_Board;
        }
    }
}
