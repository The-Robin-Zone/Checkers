using System;
using System.Collections.Generic;

namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Player
    {
        private string m_PlayerName;
        private int m_Score;
        private int m_NumberPawnsLeft;
        private int m_NumberKingsLeft;
        private char m_CoinColor;

        public Player(string i_playerName, int i_boardSize ,char i_coinColor)
        {
            this.m_PlayerName = i_playerName;
            this.m_Score = 0;
            this.m_NumberPawnsLeft = ((i_boardSize - 2) * i_boardSize) / 4;
            this.m_CoinColor = i_coinColor;
        }

        public string PlayerName
        {
            get
            {
                return this.m_PlayerName;
            }
        }

        public int Score
        {
            set
            {
                this.m_Score = value;
            }

            get
            {
                return this.m_Score;
            }
        }

        public int NumberPawnsLeft
        {
            set
            {
                this.m_NumberPawnsLeft = value;
            }

            get
            {
                return this.m_NumberPawnsLeft;
            }
        }

        public int NumberKingsLeft
        {
            set
            {
                this.m_NumberKingsLeft = value;
            }

            get
            {
                return this.m_NumberKingsLeft;
            }
        }

        public char Color
        {
            get
            {
                return this.m_CoinColor;
            }
        }

    }
}
