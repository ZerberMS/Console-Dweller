using System;

namespace RogueLike
{
    class Enemy : Actor
    {
        public Enemy() : base(/*damage*/ 1, /*hearts*/ 2, /*symbol*/ 'M', /*color*/ ConsoleColor.Red)
        { }
    }
}