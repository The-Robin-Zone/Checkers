using System;
using System.Collections.Generic;

namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Player
    {
        private string playerName;
        private int score;
        private int numberCoinsLeft;
        private char coinColor;

        // Player object constructor 
        public Player(string i_playerName, int i_boardSize ,char i_coinColor)
        {
            this.playerName = i_playerName;
            this.score = 0;
            this.numberCoinsLeft = ((i_boardSize - 2) * i_boardSize) / 4;
            this.coinColor = i_coinColor;
        }

        public string PlayerName
        {
            get
            {
                return this.playerName;
            }
        }

        public int Score
        {
            set
            {
                this.score = value;
            }

            get
            {
                return this.score;
            }
        }

        public int NumberCoinsLeft
        {
            set
            {
                this.numberCoinsLeft = value;
            }

            get
            {
                return this.numberCoinsLeft;
            }
        }

        public int Color
        {
            get
            {
                return this.coinColor;
            }
        }

    }
}
