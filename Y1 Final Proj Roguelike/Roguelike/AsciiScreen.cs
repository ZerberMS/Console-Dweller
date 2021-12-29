namespace RogueLike
{
    class AsciiScreen
    {
        public AsciiScreen()
        {
            asciiArt =
                "+--------------------------------+\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|             Defeat             |\n" +
                "|     We'll get em next time     |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n\n\n\n\n\n\n\n\n\n\n";
        }

        public void SetVictoryScreen()
        {
            asciiArt =
                "+--------------------------------+\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|            Victory!            |\n" +
                "|     You Escaped The Dungeon    |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n" +
                "|                                |\n\n\n\n\n\n\n\n\n\n\n";
        }

        public string AsciiArt
        {
            get { return asciiArt; }
        }

        private string asciiArt;
    }
}