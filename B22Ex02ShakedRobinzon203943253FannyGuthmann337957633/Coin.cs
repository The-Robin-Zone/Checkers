using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public enum eColor
    {
        Black,
        White,
    }

    public enum eCoinType
    {
        Pawn,
        King,
    }
    public class Coin
    {
        private eColor coinColor;  //  black/white (O/X)
        private eCoinType coinType; //  pawn/king
        private string location; // location on board

        // Coin object constructor 
        public Coin(eColor i_coinColor)
        {
            this.coinColor = i_coinColor;
            this.coinType = eCoinType.Pawn;
            this.location = null;
        }

        public eColor CoinColor
        {
            set
            {
                this.coinColor = value;
            }
            get

            {
                return this.coinColor;
            }
        }

        public eCoinType CoinType
        {
            set
            {
                this.coinType = value;
            }
            get

            {
                return this.coinType;
            }
        }

        public string Location
        {
            set
            {
                this.location = value;
            }
            get

            {
                return this.location;
            }
        }

        public void printCoin()
        {
            if (this.coinColor == eColor.Black)
            {
                if (this.coinType == eCoinType.Pawn)
                {
                    Console.Write("X");
                } else
                {
                    Console.Write("Z");
                }
            } else
            {
                if (this.coinColor == eColor.White)
                {
                    if (this.coinType == eCoinType.Pawn)
                    {
                        Console.Write("O");
                    }
                    else
                    {
                        Console.Write("Q");
                    }
                }
            }
        }
    }
}
