using System;

namespace RogueLike
{
    class Coin : Actor
    {
        public Coin() : base(/*damage*/ 0, /*hearts*/ 0, /*symbol*/ '$', /*color*/ ConsoleColor.DarkYellow)
        {
            visible = true;
        }

        public bool Visible
        {
            get { return visible;  }
            set { visible = value; }
        }

        private bool visible;
    }
}