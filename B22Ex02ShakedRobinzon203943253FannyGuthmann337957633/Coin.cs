using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Coin
    {
        private char coinColor;  //  black/white (O/X)
        private string coinType; //  pawn/king
        private string location; // location on board

        // Coin object constructor 
        public Coin(char i_coinColor)
        {
            this.coinColor = i_coinColor;
            this.coinType = "pawn";
            this.location = null;
        }

        public char CoinColor
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

        public string CoinType
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

    }
}
