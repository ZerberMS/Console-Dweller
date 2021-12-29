using System;

namespace RogueLike
{
    class Player : Actor
    {
        public Player() : base(/*damage*/ 1, /*hearts*/ 5, /*symbol*/ 'X', /*color*/ ConsoleColor.DarkGreen) 
        {
            coins = 0;
        }

        public int Coins
        {
            get { return coins;  }
            set { coins = value; }
        }

        private int coins;
    }
}
