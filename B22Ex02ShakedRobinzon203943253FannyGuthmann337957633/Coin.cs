using System;
namespace B22Ex02ShakedRobinzon203943253FannyGuthmann337957633
{
    public class Coin
    {
        public char coinColor;  //  black/white (O/X)
        public string coinType; //  pawn/queen
        public string location; // location on board

        // Coin object constructor 
        public Coin(char i_coinColor, string i_coinType)
        {
            coinColor = i_coinColor;
            coinType = i_coinType;
            location = null;
        }
    }
}
