// A console """""Game engine"""""
// really the worst engine in the world

namespace Test
{
    public class FartEngine
    {
        private int pointx = 10;
        private int pointy = 10;
        public string title = "GAME";

        public int xborder = 80;
        public int yborder = 24;

        // edit this to do something at the beggining of the game
        public void Init()
        {
            Console.Title = title;

            Console.BackgroundColor = ConsoleColor.DarkGreen;
            Console.ForegroundColor = ConsoleColor.White;

            Console.Clear();

            Console.CursorVisible = false;

            /*
            for (int i = 0; i < 20; i++)
            {
                Draw(num(1,50), num(1,50), "[]");
            }
            */

        }

        private void Draw(int pos_x, int pos_y, string character)
        {
            Console.SetCursorPosition(pos_x, pos_y);
            Console.Write(character);
            Console.SetCursorPosition(pointx, pointy);
        }

        private bool playerBoundariesLeft()
        {
            if (pointx == 0)
            {
                return true;
            }
            return false;
        }

        private bool playerBoundariesTop()
        {
            if (pointy == 0)
            {
                return true;
            }
            return false;
        }


        private bool playerBoundariesRight()
        {
            if (pointx == xborder)
            {
                return true;
            }
            return false;
        }

        private bool playerBoundariesBottom()
        {
            if (pointy == yborder)
            {
                return true;
            }
            return false;
        }

        // edit this to do something every frame
        public void Frame()
        {

            //Console.Clear();

            Console.SetCursorPosition(pointx, pointy);
            //Console.Beep(100,100);
            Console.Write("@");


            
            Draw(10, 10, "[]");
            Draw(15, 15, "+");
            Draw(20, 10, "#");
            Draw(1, 20, "{}");
            

            Draw(20, 25, "WELCOME TO MY CRAPPY GAME ENGINE        |         @ = PLAYER");
            //TODO: COLLISIONS AND STUFF (checking if coordinates overlap)
            //TODO: Proper drawing
            //TODO: Map boundaries
        }

        private int num(int min, int max) 
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }

        public void Input()
        {
            while (true)
            {
                switch (System.Console.ReadKey(true).Key)
                {
                    case ConsoleKey.A:
                        if (!playerBoundariesLeft()) 
                        {
                            //clean up the player
                            Draw(pointx, pointy, " ");
                            pointx--;
                        }
                        Frame();
                        break;

                    case ConsoleKey.D:
                        if (!playerBoundariesRight()) 
                        {
                            Draw(pointx, pointy, " ");
                            pointx++;
                        }
                        Frame();
                        break;

                    case ConsoleKey.S:
                        if (!playerBoundariesBottom()) 
                        {
                            Draw(pointx, pointy, " ");
                            pointy++;
                        }
                        Frame();
                        break;

                    case ConsoleKey.W:
                        if (!playerBoundariesTop()) 
                        {
                            Draw(pointx, pointy, " ");
                            pointy--;
                        }
                        Frame();
                        break;

                }
            }
        }
    }
}