using System;

namespace RogueLike
{
    class UserInput
    {
        public Coordinate ReadNextPosition(Coordinate currentPosition)
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            int x = currentPosition.x;
            int y = currentPosition.y;

            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    x--;
                    break;
                case ConsoleKey.RightArrow:
                    x++;
                    break;
                case ConsoleKey.UpArrow:
                    y--;
                    break;
                case ConsoleKey.DownArrow:
                    y++;
                    break;
            }

            ClearKeyBuffer();

            return new Coordinate(x, y);
        }

        public int ReadNumberKey()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);
            int num = -1;

            switch(key.Key)
            {
                case ConsoleKey.D1: // The 1 key.
                    num = 1;
                    break;
                case ConsoleKey.D2: // The 2 key.
                    num = 2;
                    break;
            }

            ClearKeyBuffer();

            return num;
        }

        private void ClearKeyBuffer()
        {
            while(Console.KeyAvailable)
            {
                Console.ReadKey(true);
            }
        }
    }
}