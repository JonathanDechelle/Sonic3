using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

    /// <summary>
    /// Represent a basic class for every screen that will need the be drawn.
    /// </summary>
    public abstract class GameScreen
    {
        protected ContentManager Content;
        protected IServiceProvider serviceProvider;
        public static List<GameScreen> listGameScreen = new List<GameScreen>();
        public static GraphicsDeviceManager GraphicsDeviceManager;

        public static void AddScreen(GameScreen Screen)
        {
            Screen.Load();
            listGameScreen.Add(Screen);
        }

        public static void RemoveScreen(int Pos)
        {
            listGameScreen[Pos].Alive = false;
        }

        public static void RemoveScreen(GameScreen Screen)
        {
            Screen.Alive = false;
        }

        public static void RemoveAllScreens(GameScreen ExcludedScreen = null)
        {
            for (int S = 0; S < listGameScreen.Count; S++)
                if (listGameScreen[S] != ExcludedScreen)
                    listGameScreen[S].Alive = false;
        }


        /// <summary>
        /// Decide if the current GameScreen is active or need to be removed.
        /// </summary>
        public bool Alive = true;
        /// <summary>
        /// Tell if the current GameScreen is on the of the screen.
        /// </summary>
        public bool IsOnTop = true;
        /// <summary>
        /// Force the screen to idle if the current GameScreen IsOnTop is false.
        /// </summary>
        public bool RequireFocus = true;
        /// <summary>
        /// Force the screen to hide if the current GameScreen IsOnTop is false.
        /// </summary>
        public bool RequireDrawFocus = false;
        /// <summary>
        /// Decide at which transparancy the current GameScreen need to be drawn(such as popup screen).
        /// </summary>
        public int Transparancy = 255;//Work in progress

        /// <summary>
        /// Empty constructor if no ContentManager is required.
        /// </summary>
        public GameScreen() { }

        /// <summary>
        /// Instanciate a new GameScreen object.
        /// </summary>
        /// <param name="serviceProvider">A IServiceProvider used to create a new ContentManager.</param>
        public GameScreen(IServiceProvider serviceProvider,GraphicsDeviceManager graphics)
        {
            Content = new ContentManager(serviceProvider);
            Content.RootDirectory = "Content";
            GraphicsDeviceManager = graphics;
            this.serviceProvider = serviceProvider;
        }
        public abstract void Load();
        /// <summary>
        /// Override the Update to make your own game logic for the screen.
        /// </summary>
        public abstract void Update(GameTime gameTime);
        /// <summary>
        /// Override the Update to make your own drawing logic for the screen.
        /// </summary>
        public abstract void Draw(GameTime gametime,SpriteBatch g);
    }
    /// <summary>
    /// Represent a temporary GameScreen that will unload every other GameScreen then load a new one.
    /// </summary>
    public class LoadScreen : GameScreen
    {
        private GameScreen[] Screens;
        private Texture2D BackgroundBuffer;
        /// <summary>
        /// Initialize a new LoadScreen that will clear the other screens and load the new one automatically.
        /// </summary>
        /// <param name="Game">Requires the main form of the project to have access to its members.</param>
        /// <param name="Screens">An array of GameScreen to create while loading.</param>
        /// <param name="BackgroundBuffer">A background picture to use for the loading screen. Can be null.</param>
        /// <param name="graphics">Pour utiliser tout ce qui attrait a la fenetre</param>
        public LoadScreen(IServiceProvider serviceProvider, GameScreen[] Screens, Texture2D BackgroundBuffer, GraphicsDeviceManager graphics)
            : base(serviceProvider, graphics)
        {
            this.Screens = Screens;
            this.BackgroundBuffer = BackgroundBuffer;
            //Remove everything else.
            for (int i = 0; i < GameScreen.listGameScreen.Count; i++)
                GameScreen.RemoveScreen(i);
        }
        public override void Load()
        { }
        public override void Update(GameTime gameTime)
        {//If all the GameScreen are unloaded and only this GameScreen is loaded.
            if (GameScreen.listGameScreen.Count == 1)
            {//Ask the Game to remove this GameScreen the next time it update.
                GameScreen.RemoveScreen(this);
                //Create and load the pending GameScreen array.
                for (int i = 0; i < Screens.Length; i++)
                    GameScreen.AddScreen(Screens[i]);
            }
        }
        public override void Draw(GameTime gametime, SpriteBatch g)
        {
            if (BackgroundBuffer != null)
                g.Draw(BackgroundBuffer, new Vector2(0, 0), Color.White);
            // g.DrawString(Game.fntArial, "Loading", new Vector2(Game.Width - 100, Game.Height - 80), Color.Black);
        }
    }
