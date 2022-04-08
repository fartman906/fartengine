// A console """""Game engine"""""
// really the worst engine in the world

namespace Game
{

    public class FartEngine
    {
        private static int player_x = 10;
        private static int player_y = 10;
        public string title = "EXAMPLE GAME";

        public int xborder = 110;
        public int yborder = 27;

        public bool GameRunning
        { get; set; }

        // Game Variables
        private int points = 0;

        // Objects
        Object hashtag = new Object(num(5, 50), num(5, 20), "#");
        Object ampersand = new Object(num(5, 50), num(5, 20), "&");

        /// <summary>
        /// A blueprint of an object with X and Y co-ordinates
        /// </summary>
        public class Object
        {
            public int x { get; set; }
            public int y { get; set; }
            public string character { get; set; }
            public bool disabled { get; set; }

            public Object(int X, int Y, string chr)
            {
                x = X;
                y = Y;
                character = chr;
                disabled = false;
            }

            /// <summary>
            /// Draw the object to the screen
            /// </summary>
            public void DrawObject()
            {
                if (!disabled) {
                    // DRAW
                    Console.SetCursorPosition(x, y);
                    Console.Write(character);
                    Console.SetCursorPosition(player_x, player_y);
                }
            }

            /// <summary>
            /// Check if 2 objects have the same position
            /// </summary>
            public bool Intercept(int XX, int YY)
            {
                if ((x == XX && y == YY) && disabled == false) return true;
                return false;
            }
        }

        /// <summary>
        /// Random Number
        /// </summary>
        private static int num(int min, int max)
        {
            Random rnd = new Random();
            return rnd.Next(min, max);
        }

        /// <summary>
        /// Sets up the console
        /// </summary>
        public void Init()
        {
            GameRunning = true;
            Console.Title = title;
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
            Console.CursorVisible = false;
        }

        /// <summary>
        /// Draw something to the console
        /// </summary>
        private void Draw(int pos_x, int pos_y, string character)
        {
            Console.SetCursorPosition(pos_x, pos_y);
            Console.Write(character);
            Console.SetCursorPosition(player_x, player_y);
        }

        private bool playerBoundariesLeft()
        {
            if (player_x == 0) return true;
            return false;
        }

        private bool playerBoundariesTop()
        {
            if (player_y == 0) return true;
            return false;
        }

        private bool playerBoundariesRight()
        {
            if (player_x == xborder) return true;
            return false;
        }

        private bool playerBoundariesBottom()
        {
            if (player_y == yborder) return true;
            return false;
        }

        /// <summary>
        /// Check if 2 objects have the same position
        /// </summary>
        private bool Intercept(Object obj, int x, int y)
        {
            if ((obj.x == x && obj.y == y) && obj.disabled == false) return true;
            return false;
        }

        private void Player()
        {
            // draw teh player
            Console.SetCursorPosition(player_x, player_y);
            //Console.Beep(100,100);
            Console.Write("■");
        }

        private void GameOver(string message)
        {
            GameRunning = false;
            Console.Clear();
            Draw(50, 15, message);
            Thread.Sleep(1000);
            Draw(50, 20, "Press any key to close...");
            Console.ReadKey();
        }

        /// <summary>
        /// Code for game logic
        /// </summary>
        private void Logic()
        {
            if (hashtag.Intercept(player_x, player_y))
            {
                points++;
                // disable the object
                hashtag.disabled = true;

                hashtag = new Object(num(5, 50), num(5, 20), "#");
            }


            if (Intercept(ampersand, player_x, player_y))
            {
                GameOver("You lose");
            }
        }

        /// <summary>
        /// Called in the game's while loop, put your logic and drawing stuff here
        /// </summary>
        public void Frame()
        {
            Player();

            // be sure to render the objects
            hashtag.DrawObject();
            ampersand.DrawObject();

            Logic();

            // draw some subtitles (text)
            Draw(28, 28, $"Points {points}   |     # = 1 point    |         ■ = PLAYER");
        }

        /// <summary>
        /// Move the player
        /// </summary>
        public void Input()
        {
            while (GameRunning)
            {
                switch (System.Console.ReadKey(true).Key)
                {
                    case ConsoleKey.A:
                        if (!playerBoundariesLeft())
                        {
                            //clean up the player
                            Draw(player_x, player_y, " ");
                            player_x--;
                        }
                        Frame();
                        break;

                    case ConsoleKey.D:
                        if (!playerBoundariesRight())
                        {
                            Draw(player_x, player_y, " ");
                            player_x++;
                        }
                        Frame();
                        break;

                    case ConsoleKey.S:
                        if (!playerBoundariesBottom())
                        {
                            Draw(player_x, player_y, " ");
                            player_y++;
                        }
                        Frame();
                        break;

                    case ConsoleKey.W:
                        if (!playerBoundariesTop())
                        {
                            Draw(player_x, player_y, " ");
                            player_y--;
                        }
                        Frame();
                        break;
                }
            }
        }
    }
}