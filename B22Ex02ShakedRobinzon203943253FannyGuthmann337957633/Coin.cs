using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Coin
    {
        private char coinColor;  //  black/white (O/X)
        private bool isKing;     //  pawn/king
       
        public Coin(char i_coinColor)
        {
            this.coinColor = i_coinColor;
            this.isKing = false;
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

        public bool CoinType
        {
            set
            {
                this.isKing = value;
            }
            get

            {
                return this.isKing;
            }
        }
    }
}
