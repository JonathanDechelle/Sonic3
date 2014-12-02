using System;

namespace Sonic3
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (cGame1 game = new cGame1())
            {
                game.Run();
            }
        }
    }
#endif
}

