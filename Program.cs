using System.Threading;


namespace Test 
{
    class Program
    {
        static public void Main(String[] args)
        {
            FartEngine game = new FartEngine();

            game.Init();

            //Main Loop
            while (true)
            {
                game.Input();
                game.Frame(); 

                Thread.Sleep(20);
            }
        }
    }
}