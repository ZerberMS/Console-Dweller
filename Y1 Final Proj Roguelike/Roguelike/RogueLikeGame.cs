using System;

namespace RogueLike
{
    class RogueLikeGame
    {
        public RogueLikeGame()
        {
            finishedLevel = false;
            isRunning     = true;
            victoryScreen = false;
            nextUpdate    = DateTime.MinValue;
            enemyUpdate   = DateTime.MinValue;

            userInput     = new UserInput();
            coin          = new Coin();
            player        = new Player();
            trap          = new Trap();
            enemy         = new Enemy();

            hud           = new AsciiHud(player.Hearts, player.Coins);
            map           = new AsciiMap();
            screen        = new AsciiScreen();
            shop          = new AsciiShop();
            log           = new Log();
        }

        public void Create()
        {
            Console.CursorVisible = false;

            coin.Position   = map.CoinSpawn;
            player.Position = map.PlayerSpawn;
            trap.Position   = map.TrapSpawn;
            enemy.Position  = map.EnemySpawn;
        }

        public void Update()
        {
            if(DateTime.Now < nextUpdate)
            {
                return;
            }

            if(Console.KeyAvailable)
            {
                ProcessUserInput();
            }

            if(finishedLevel)
            {
                if(VictoryCondition())
                {
                    return;
                }

                openShop();

                LoadNextLevel();
            }

            EnemyMoveAndDamage();

            CheckLoseCondition();

            RenderGame();

            nextUpdate = DateTime.Now.AddMilliseconds(100);
        }

        public bool IsRunning()
        {
            return isRunning;
        }

        public void RenderGameState()
        {
            if(victoryScreen)
            {
                screen.SetVictoryScreen();
                Console.Beep(700, 150);
                Console.Beep(1000, 150);
                Console.Beep(1300, 150);
                Console.Beep(1700, 230);
            }
            else
            {
                Console.Beep(400, 200);
                Console.Beep(250, 200);
                Console.Beep(100, 200);
            }

            Console.SetCursorPosition(0, 0);
            Console.Write(screen.AsciiArt);
        }

        private char GetSymbol(int x, int y)
        {
            const int mapWidth = 35;

            return map.AsciiArt[x + y * mapWidth];
        }

        private void EnemyDamagePlayer()
        {
            player.Hearts -= enemy.Damage;
            hud.Health = player.Hearts;
            log.AddMessage("1 damage recieved");
            Console.Beep(350, 50);
        }

        private void EnemyMoveAndDamage()
        {
            if (DateTime.Now < enemyUpdate)
            {
                return;
            }

            int x = enemy.Position.x;
            int y = enemy.Position.y;

            if (enemy.Position.x < player.Position.x-1)
            {
                x++;
            }
            else if (enemy.Position.x > player.Position.x+1)
            {
                x--;
            }

            if (enemy.Position.y < player.Position.y-1)
            {
                y++;
            }
            else if (enemy.Position.y > player.Position.y+1)
            {
                y--;
            }

            char symbol = GetSymbol(x, y);

            if (symbol != '█')
            {
                enemy.Position = new Coordinate(x, y);
            }

            
            if (enemy.Position.y == player.Position.y - 1 && enemy.Position.x == player.Position.x + 1 ||
                enemy.Position.y == player.Position.y - 1 && enemy.Position.x == player.Position.x - 1)
            {
                EnemyDamagePlayer();
            }
            else if (enemy.Position.y == player.Position.y + 1 && enemy.Position.x == player.Position.x + 1 ||
                enemy.Position.y == player.Position.y + 1 && enemy.Position.x == player.Position.x - 1)
            {
                EnemyDamagePlayer();
            }
            else if (enemy.Position.y == player.Position.y + 1 && enemy.Position.x == player.Position.x ||
                enemy.Position.y == player.Position.y - 1 && enemy.Position.x == player.Position.x)
            {
                EnemyDamagePlayer();
            }
            else if (enemy.Position.y == player.Position.y && enemy.Position.x == player.Position.x + 1 ||
                enemy.Position.y == player.Position.y && enemy.Position.x == player.Position.x - 1)
            {
                EnemyDamagePlayer();
            }
            else if (enemy.Position.y == player.Position.y && enemy.Position.x == player.Position.x)
            {
                EnemyDamagePlayer();
            }

            enemyUpdate = DateTime.Now.AddMilliseconds(500);
        }

        private void ProcessUserInput()
        {
            Coordinate newPosition = userInput.ReadNextPosition(player.Position);

            char symbol = GetSymbol(newPosition.x, newPosition.y);

            if (symbol == 'F')
            {
                finishedLevel = true;
                Console.Beep(1400, 150);
            }
            else if(symbol != '█')
            {
                player.Position = newPosition;
            }
        }

        private bool VictoryCondition()
        {
            if(map.CurrentMapIndex == 9)
            {
                isRunning     = false;
                victoryScreen = true;
                return true;
            }

            return false;
        }

        private void CheckLoseCondition()
        {
            if(player.Hearts == 0)
            {
                isRunning = false;
            }
        }

        private void openShop()
        {
            RenderShop();

            while(true)
            {
                if(Console.KeyAvailable)
                {
                    int numberKey = userInput.ReadNumberKey();
                    if(numberKey == 1)
                    {
                        if(player.Coins > 0)
                        {
                            if(player.Hearts < 5)
                            {
                                shop.Message = "you bought 1 heart!  ";
                                ++player.Hearts;
                                --player.Coins;
                                hud.Health = player.Hearts;
                                hud.Coins  = player.Coins;
                                Console.Beep(700, 80);
                                Console.SetCursorPosition(0, 18); // hudX = 0, hudY = 18
                                Console.Write(hud.AsciiArt);
                            }
                            else
                            {
                                shop.Message = "max hp, cant buy more";
                            }
                        }
                        else
                        {
                            shop.Message =  "Not enought coins    ";
                        }
                        RenderShop();
                    }
                    else if(numberKey == 2)
                    {
                        break;
                    }
                }
            }
        }

        private void RenderShop()
        {
            Console.SetCursorPosition(0, 0);
            Console.Write(shop.AsciiArt);
            shop.Message = "                     ";
        }

        private void LoadNextLevel()
        {
            map.NextMap();
            log.AddMessage("You advanced to level " + map.CurrentMapIndex.ToString());

            coin.Position   = map.CoinSpawn;
            if(map.CurrentMapIndex == 9) //removes the coin from Map10
            {
                coin.Visible = false;
            }
            else
            {
                coin.Visible = true;
            }

            player.Position = map.PlayerSpawn;

            trap.Position   = map.TrapSpawn;
            trap.Visible    = false;

            enemy.Position  = map.EnemySpawn;

            finishedLevel   = false;
        }

        private void RenderGame()
        {
            Console.SetCursorPosition(0, 0);
            Console.WriteLine(map.AsciiArt);
            Console.WriteLine(hud.AsciiArt);
            Console.WriteLine(log.AsciiArt);

            if (coin.Visible)
            {
                if(player.Position.x == coin.Position.x && player.Position.y == coin.Position.y)
                {
                    coin.Visible = false;
                    ++player.Coins;
                    hud.Coins = player.Coins;
                    log.AddMessage("You found a coin!");
                    Console.Beep(1000, 80);
                }
                else
                {
                    Console.SetCursorPosition(coin.Position.x, coin.Position.y);
                    Console.ForegroundColor = coin.Color;
                    Console.Write(coin.Symbol);
                }
            }

            if(!trap.Visible)
            {
                if(player.Position.x == trap.Position.x && player.Position.y == trap.Position.y)
                {
                    trap.Visible = true;
                    player.Hearts -= trap.Damage;
                    hud.Health = player.Hearts;
                    log.AddMessage("You sprung a trap!");
                    Console.Beep(800, 80);
                }
            }
            else
            {
                Console.SetCursorPosition(trap.Position.x, trap.Position.y);
                Console.ForegroundColor = trap.Color;
                Console.Write(trap.Symbol);
            }

            Console.SetCursorPosition(enemy.Position.x, enemy.Position.y);
            Console.ForegroundColor = enemy.Color;
            Console.Write(enemy.Symbol);

            Console.SetCursorPosition(player.Position.x, player.Position.y);
            Console.ForegroundColor = player.Color;
            Console.Write(player.Symbol);

            Console.ForegroundColor = ConsoleColor.White;

            log.Render();
        }

        private bool        finishedLevel;
        private bool        isRunning;
        private bool        victoryScreen;
        private DateTime    nextUpdate;
        private DateTime    enemyUpdate;

        private UserInput   userInput;
        private Coin        coin;
        private Player      player;
        private Trap        trap;
        private Enemy       enemy;

        private AsciiHud    hud;
        private AsciiMap    map;
        private AsciiScreen screen;
        private AsciiShop   shop;
        private Log         log;
    }
}