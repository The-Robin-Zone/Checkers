using System;

namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Coin
    {
        private char m_CoinColor;
        private bool m_IsKing;     
       
        public Coin(char i_coinColor)
        {
            this.m_CoinColor = i_coinColor;
            this.m_IsKing = false;
        }

        public char CoinColor
        {
            get
            {
                return this.m_CoinColor;
            }

            set
            {
                this.m_CoinColor = value;
            }
        }

        public bool IsKing
        {
            get
            {
                return this.m_IsKing;
            }

            set
            {
                this.m_IsKing = value;
            }
        }
    }
}
