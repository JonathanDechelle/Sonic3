using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Represent a basic class for every screen that will need the be drawn.
    /// </summary>
    public class GameScreen
    {
        private ContentManager Content;

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
        }

        public virtual void Load()
        {

        }

        /// <summary>
        /// Override the Update to make your own game logic for the screen.
        /// </summary>
        public virtual void Update(GameTime gameTime)
        {
            CheckOnDirectionPressed();
            CheckOnEnterPressed();
        }

        private void CheckOnEnterPressed()
        {
            if (!KeyboardHelper.KeyPressed(Keys.Enter))
            {
                return;
            }

            OnEnterPressed();
        }

        public virtual void OnEnterPressed()
        { }

        private void CheckOnDirectionPressed()
        {
            for (Keys i = Keys.Left; i < (Keys)Keys.Down + 1; i++)
            {
                if (KeyboardHelper.KeyPressed(i))
                {
                    OnDirectionPressed(i);
                    break;
                }
            }
        }

        public virtual void OnDirectionPressed(Keys aKeys)
        { }

        /// <summary>
        /// Override the Update to make your own drawing logic for the screen.
        /// </summary>
        public virtual void Draw(GameTime gametime, SpriteBatch g)
        {

        }
    }
