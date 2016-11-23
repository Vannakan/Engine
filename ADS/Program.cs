using System;

namespace ADS
{
#if WINDOWS || LINUX
    /// <summary>
    /// The main class.
    /// </summary>
    public static class Program
    {
        //Allows me to access Game1 from anywhere. This isnt so good but will allow me to call the game1.exit method which is the only
        //intention of this.
        //Temporary measure
        public static Game1 Game;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (var game = new Game1())
            {
                Game = game;
                Game.Run();
            }

            
        }
    }
#endif
}
