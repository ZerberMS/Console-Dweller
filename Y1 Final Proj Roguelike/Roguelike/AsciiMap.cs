namespace RogueLike
{
    class AsciiMap
    {
        public AsciiMap()
        {
            currentMapIndex = 0;
            currentMap = maps[currentMapIndex];
        }

        public void NextMap()
        {
            if (currentMapIndex < 9)
            {
                ++currentMapIndex;
                currentMap = maps[currentMapIndex];
            }
        }

        public string AsciiArt
        {
            get { return currentMap.asciiArt; }
        }

        public Coordinate PlayerSpawn
        {
            get { return currentMap.playerSpawn; }
        }

        public Coordinate EnemySpawn
        {
            get { return currentMap.enemySpawn; }
        }

        public Coordinate CoinSpawn
        {
            get { return currentMap.coinSpawn; }
        }

        public Coordinate TrapSpawn
        {
            get { return currentMap.trapSpawn; }
        }

        public int CurrentMapIndex
        {
            get { return currentMapIndex; }
        }

        private class RogueLikeMap
        {
            public RogueLikeMap(string asciiArt, Coordinate playerSpawn, Coordinate enemySpawn,
                Coordinate coinSpawn, Coordinate trapSpawn)
            {
                this.asciiArt    = asciiArt;
                this.playerSpawn = playerSpawn;
                this.enemySpawn  = enemySpawn;
                this.coinSpawn   = coinSpawn;
                this.trapSpawn   = trapSpawn;
            }

            public string     asciiArt;
            public Coordinate playerSpawn;
            public Coordinate enemySpawn;
            public Coordinate coinSpawn;
            public Coordinate trapSpawn;
        }

        private int currentMapIndex;

        private RogueLikeMap currentMap;
        
        private RogueLikeMap[] maps = new RogueLikeMap[]
        {
            new RogueLikeMap
            (
               //Map 1
                "             █████                \n" +
                "             █   █                \n" +
                "             █   █                \n" +
                "             █   █                \n" +
                "             █   █                \n" +
                "██████████████   ████████         \n" +
                "█                       █         \n" +
                "█       ███████         █         \n" +
                "█ ████  █     █   █     █         \n" +
                "█ █  █  █     █   █     █         \n" +
                "█ ████  ███████   █     █         \n" +
                "█                 █ █████         \n" +
                "███████████████████     █         \n" +
                "                  █     █         \n" +
                "                  █     █         \n" +
                "                  █     █         \n" +
                "                  █     █         \n" +
                "                  █FFFFF█         ",
                new Coordinate(14 ,  1), /* playerSpawn */
                new Coordinate(23 , 12), /* enemySpawn  */
                new Coordinate( 1 , 11), /* coinSpawn   */ 
                new Coordinate( 1 ,  8)  /* trapSpawn   */
            ),
            new RogueLikeMap
            (
                //Map 2
                "    █████████████████████         \n" +
                "    █                   ██        \n" +
                "    ███████      █████   ██       \n" +
                "     █    █      █   █    F       \n" +
                "     █    █      █   █    F       \n" +
                "     █    █ ████ █   █    F       \n" +
                "     █    █ █  █ █████   ██       \n" +
                "     █    █ █  █        ██        \n" +
                "    ███████ █  █ ████████         \n" +
                "    █       █  █ █                \n" +
                "    █       ████ █                \n" +
                "    █            █                \n" +
                "    █     █      █                \n" +
                "    █     █      █                \n" +
                "    █     █      █                \n" +
                "    █     █      █                \n" +
                "    █     █      █                \n" +
                "    ██████████████                ",
                new Coordinate( 5, 16), /* playerSpawn */
                new Coordinate(13, 16), /* enemySpawn  */
                new Coordinate(18,  1), /* coinSpawn   */ 
                new Coordinate(17,  1)  /* trapSpawn   */
            ),
            new RogueLikeMap
            (
                //Map 3
                "              █████████           \n" +
                "              █       █           \n" +
                "              █       █           \n" +
                "              █       █           \n" +
                "███████████████       █           \n" +
                "█                     █           \n" +
                "█            ███      █           \n" +
                "█ ██████████ █ █      █           \n" +
                "█ █        █ ███      ██████████  \n" +
                "█ █        █                   ███\n" +
                "█ █        █  █                  F\n" +
                "█ █        █  █                ███\n" +
                "█ █        █  █       ██████████  \n" +
                "█ █        █  █       █           \n" +
                "█ ██████████  █████████           \n" +
                "█             █                   \n" +
                "█             █                   \n" +
                "███████████████                   ",
                new Coordinate(13, 16), /* playerSpawn */
                new Coordinate(18, 13), /* enemySpawn  */
                new Coordinate(15,  1), /* coinSpawn   */ 
                new Coordinate(14,  9)  /* trapSpawn   */
            ),
            new RogueLikeMap
            (
                //Map 4
                "██████████████████                \n" +
                "█                █                \n" +
                "█                ████████         \n" +
                "██████                  █         \n" +
                "F                █      █         \n" +
                "F                █      █         \n" +
                "██████           ██████ █         \n" +
                "█                █    █ ██████████\n" +
                "█                █    █          █\n" +
                "█                █    █          █\n" +
                "█                █    █ ██████████\n" +
                "████████████     ██████ █         \n" +
                "           █     █      █         \n" +
                "           █     █      █         \n" +
                "           █            █         \n" +
                "           █     ████████         \n" +
                "           █     █                \n" +
                "           ███████                ",
                new Coordinate(32,  8), /* playerSpawn */
                new Coordinate(20,  4), /* enemySpawn  */
                new Coordinate(16, 16), /* coinSpawn   */ 
                new Coordinate(17, 14)  /* trapSpawn   */
            ),
            new RogueLikeMap
            (
                //Map 5
                "     █████████████████████████████\n" +
                "     █                           █\n" +
                "     █  ██████ ██████ ████████   █\n" +
                "██████  █    █ █    █ █      █   █\n" +
                "█       █    █ █    █ █      █FFF█\n" +
                "█       █    █ █    █ █           \n" +
                "█    █  ██████ ██████ █           \n" +
                "█    █                █           \n" +
                "█    █    ██████████  █           \n" +
                "█    █    █        █  █           \n" +
                "█    █    █        █  █           \n" +
                "█    ████ █        █  █           \n" +
                "█       █ ██████████  █           \n" +
                "█       █             █           \n" +
                "█████████████████████ █           \n" +
                "                    █ █           \n" +
                "                    █ █           \n" +
                "                    ███           ",
                new Coordinate(21, 16), /* playerSpawn */
                new Coordinate(26,  1), /* enemySpawn  */
                new Coordinate(14,  7), /* coinSpawn   */ 
                new Coordinate(14,  6)  /* trapSpawn   */
            ),
            new RogueLikeMap
            (
                //Map 6
                "                  █FF█            \n" +
                "                  █  █            \n" +
                "                  █  █            \n" +
                "                  █  █            \n" +
                "       ████████████  █            \n" +
                "       █         █   █            \n" +
                "       █  █████  █   █            \n" +
                "████████  █   █  █   █            \n" +
                "█         █████  █  ██            \n" +
                "█      █            █             \n" +
                "█      ███████████ ██             \n" +
                "█          █     █ █              \n" +
                "█          █     █ █              \n" +
                "█          █     █ █              \n" +
                "█          █     █ ████████       \n" +
                "████████████     █        █       \n" +
                "                 █        █       \n" +
                "                 ██████████       ",
                new Coordinate( 1, 14), /* playerSpawn */
                new Coordinate(20,  2), /* enemySpawn  */
                new Coordinate(25, 16), /* coinSpawn   */ 
                new Coordinate(24, 16)  /* trapSpawn   */
            ),
            new RogueLikeMap
            (
                //Map 7
                "      █████████                   \n" +
                "      █       █                   \n" +
                "      █ █████ █                   \n" +
                "     ██ █   █ █                   \n" +
                "   ███  █   █ ████████████████    \n" +
                "   █    █████                █    \n" +
                "   █ █          ███████████  █    \n" +
                "   █ ██████████ █         █  █    \n" +
                "   █ █        █ █         █  █    \n" +
                "   █ █        █ ███████████  █    \n" +
                "   █ █        █              █    \n" +
                "   █ █        ████████████ ███    \n" +
                "   █ █                   █ █      \n" +
                "   █ █                   █ █      \n" +
                "   █ █                   █ █      \n" +
                "████ █████████████████████ ███████\n" +
                "█                                F\n" +
                "██████████████████████████████████",
                new Coordinate( 1, 16), /* playerSpawn */
                new Coordinate(13,  6), /* enemySpawn  */
                new Coordinate(15,  5), /* coinSpawn   */
                new Coordinate(16, 16)  /* trapSpawn   */
            ),
            new RogueLikeMap
            (
                //Map 8
                "███████████████████████   █FFF█   \n" +
                "█                     █   █   █   \n" +
                "█        ████████████ █   █   █   \n" +
                "█        █          █ █   █   █   \n" +
                "█        █          █ █   █   █   \n" +
                "█        █          █ █   █   █   \n" +
                "██████ ███          █ █   █   █   \n" +
                "     █ █        █████ █████ ███   \n" +
                "     █ ██████████           █     \n" +
                "     █                      █     \n" +
                "     █          ████████ ████     \n" +
                "     █  █    █  █     █  █        \n" +
                "     █          █     █ ██        \n" +
                "     █          ███████  █        \n" +
                "     █            █   ██ █        \n" +
                "     █  █    █  █ █ █ █  █        \n" +
                "     █          █   █    █        \n" +
                "     █████████████████████        ",
                new Coordinate( 1,  1), /* playerSpawn */
                new Coordinate(10, 16), /* enemySpawn  */
                new Coordinate(22,  9), /* coinSpawn   */ 
                new Coordinate( 9,  1)  /* trapSpawn   */
            ),
            new RogueLikeMap
            (
                //Map 9
                "█████████████████████████████     \n" +
                "█                           █     \n" +
                "█ █████  ███████ ██████████ █     \n" +
                "█ █   █  █     █ █        █ █     \n" +
                "█ █   █  █     █ █        █ █     \n" +
                "█ █   █  █     █ █        █ █     \n" +
                "█ █   █  █     █ █        █ █     \n" +
                "█ █   █  █  ████ ████     █ █     \n" +
                "█ █   █  █  █       █     █ █     \n" +
                "█ █   █  █  █       █     █ █     \n" +
                "█ █████  ████       ███████ ██████\n" +
                "█                                F\n" +
                "█    █████ █████████             F\n" +
                "█    █   █ █       █             F\n" +
                "█    █   █ █       ███████████████\n" +
                "█    █   █ █                      \n" +
                "██████   █ █                      \n" +
                "         ███                      ",
                new Coordinate( 1, 15), /* playerSpawn */
                new Coordinate(10, 12), /* enemySpawn  */
                new Coordinate( 1,  1), /* coinSpawn   */ 
                new Coordinate( 1,  6)  /* trapSpawn   */
            ),
            new RogueLikeMap
            (
                //Map 10
                "   ██████                     ████\n" +
                "   █    █                     █  █\n" +
                "   █    █                     █  █\n" +
                "   █    █████████████████     █  █\n" +
                "   █                    █     █  █\n" +
                "   █                    █     █  █\n" +
                "   █       ███ ███      █     █  █\n" +
                "████  █ ██         ██ █ ███████  █\n" +
                "F     █ ██         ██ █          █\n" +
                "F                                █\n" +
                "████  █ ██         ██ █ ██████████\n" +
                "   █  █ ██         ██ █ █         \n" +
                "   █       ███ ███      █         \n" +
                "   █                    █         \n" +
                "   █                    █         \n" +
                "   █                    █         \n" +
                "   █                    █         \n" +
                "   ██████████████████████         ",
                new Coordinate(32, 1), /* playerSpawn */
                new Coordinate(23, 4), /* enemySpawn  */
                new Coordinate(0,  0), /* coinSpawn   */ 
                new Coordinate(7,  9)  /* trapSpawn   */
            ),
        };
    }
}