using System;

namespace RogueLike
{
    class Actor
    {
        public Actor(int damage, int hearts, char symbol, ConsoleColor color)
        {
            this.damage      = damage;
            this.hearts      = hearts;
            this.symbol      = symbol;
            this.color       = color;
        }

        public int Damage
        {
            get { return damage; }
        }

        public int Hearts
        {
            get { return hearts;  }
            set { hearts = value; }
        }

        public char Symbol
        {
            get { return symbol; }
        }

        public ConsoleColor Color
        {
            get { return color; }
        }

        public Coordinate Position
        {
            get { return position;  }
            set { position = value; }
        }

        private int          damage;
        private int          hearts;
        private char         symbol;
        private ConsoleColor color;

        private Coordinate position;
    }
}
