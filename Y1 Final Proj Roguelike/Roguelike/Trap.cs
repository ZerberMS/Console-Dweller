using System;

namespace RogueLike
{
    class Trap : Actor
    {
        public Trap() : base(/*damage*/ 1, /*hearts*/ 0, /*symbol*/ '#', /*color*/ ConsoleColor.DarkBlue)
        {
            visible = false;
        }

        public bool Visible
        {
            get { return visible;  }
            set { visible = value; }
        }

        private bool visible;
    }
}
