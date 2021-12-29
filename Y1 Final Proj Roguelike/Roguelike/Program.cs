// ---- C# 101 (Dor Ben Dor) ----
//      Michael Slavitsky
//          08/07/2021
//-------------------------------
namespace RogueLike
{
    class Program
    {
        static void Main(string[] args)
        {
            RogueLikeGame game = new RogueLikeGame();

            game.Create();

            while(game.IsRunning())
            {
                game.Update();
            }

            game.RenderGameState();
        }
    }
}
