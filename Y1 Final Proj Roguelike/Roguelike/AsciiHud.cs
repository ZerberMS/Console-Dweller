namespace RogueLike
{
    class AsciiHud
    {
        public AsciiHud(int health, int coins)
        {
            asciiArt = ("+--------------------------------+\n" +
                        "|    HEALTH:        COINS:       |\n" +
                        "+--------------------------------+").ToCharArray();

            Health = health;
            Coins  = coins;
        }

        public int Health
        {
            set
            {
                int health = value;

                const int hudWidth = 35;
                const int healthX  = 12;
                const int healthY  = 1;

                asciiArt[healthX + healthY * hudWidth] = (char)('0' + health);
            }
        }

        public int Coins
        {
            set
            {
                int coins = value;

                const int hudWidth = 35;
                const int coinX    = 26;
                const int coinY    = 1;

                asciiArt[coinX + coinY * hudWidth] = (char)('0' + coins);
            }
        }
        
        public char[] AsciiArt
        {
            get { return asciiArt; }
        }

        private char[] asciiArt;
    }
}