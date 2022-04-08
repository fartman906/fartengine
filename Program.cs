// main file that starts the game and does stuff

namespace Game
{
    class Program
    {
        static public void Main(String[] args)
        {
            FartEngine game = new FartEngine();
            game.Init();

            //Main Loop
            while (game.GameRunning)
            {
                game.Input();
                game.Frame(); 

                Thread.Sleep(20);
            }
        }
    }
}