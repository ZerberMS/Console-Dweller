namespace RogueLike
{
    class AsciiShop
    {
        public AsciiShop()
        {
            asciiArt = ("+--------------------------------+\n" +
                        "|                                |\n" +
                        "|                                |\n" +
                        "|                                |\n" +
                        "|                                |\n" +
                        "|      (1) coin = (1) heart      |\n" +
                        "|   +------------------------+   |\n" +
                        "|   |                        |   |\n" +
                        "|   +------------------------+   |\n" +
                        "|     Press 1 to buy 1 heart     |\n" +
                        "|     Press 2 to continue        |\n" +
                        "|                                |\n" +
                        "|                                |\n" +
                        "|                                |\n" +
                        "|                                |\n" +
                        "|                                |\n" +
                        "|                                |\n" +
                        "|                                |").ToCharArray();
        }

        public string Message
        {
            set
            {
                string message = value;

                const int shopWidth = 35;
                const int messageX  = 5;
                const int messageY  = 7;

                for (int i = 0; i < message.Length; i++)
                {
                    asciiArt[messageX + messageY * shopWidth + i] = message[i];
                }
            }
        }

        public char[] AsciiArt
        {
            get { return asciiArt; }
        }

        private char[] asciiArt;
    }
}