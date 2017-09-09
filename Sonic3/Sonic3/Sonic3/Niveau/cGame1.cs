using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

    /// <summary>
    /// This is the main type for your game
    /// </summary>
public class cGame1 : Microsoft.Xna.Framework.Game
{
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;

    //Screen adjustement
    int screenWidth = 800;
    int screenHeight = 500;

    public cGame1()
    {
        graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        //Pour setter la grandeur de fenetre
        graphics.PreferredBackBufferWidth = screenWidth;
        graphics.PreferredBackBufferHeight = screenHeight;
        graphics.ApplyChanges();
        IsMouseVisible = true;

        //Plein ecran
        // graphics.IsFullScreen = true;
    }

    /// <summary>
    /// Allows the game to perform any initialization it needs to before starting to run.
    /// This is where it can query for any required services and load any non-graphic
    /// related content.  Calling base.Initialize will enumerate through any components
    /// and initialize them as well.
    /// </summary>
    protected override void Initialize()
    {
        // TODO: Add your initialization logic here

        base.Initialize();
    }

    /// <summary>
    /// LoadContent will be called once per game and is the place to load
    /// all of your content.
    /// </summary>
    protected override void LoadContent()
    {
        // Create a new SpriteBatch, which can be used to draw textures.
        spriteBatch = new SpriteBatch(GraphicsDevice);
        RessourceSonic3.LoadContent(Content);
        //Create a new Title screen.
        GameScreen.AddScreen(new cIntro(Services, this.graphics));
    }

    /// <summary>
    /// UnloadContent will be called once per game and is the place to unload
    /// all content.
    /// </summary>
    protected override void UnloadContent()
    {
        // TODO: Unload any non ContentManager content here
    }

    /// <summary>
    /// Allows the game to run logic such as updating the world,
    /// checking for collisions, gathering input, and playing audio.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Update(GameTime gameTime)
    {
        // Allows the game to exit

        KeyboardHelper.PlayerState = Keyboard.GetState();
        /*if (Game.PlayerState.IsKeyDown(Keys.Escape))
            this.Exit();*/

        for (int i = 0; i < GameScreen.listGameScreen.Count; i++)
        {
            if (i == GameScreen.listGameScreen.Count - 1)
                GameScreen.listGameScreen[i].IsOnTop = true;
            else
                GameScreen.listGameScreen[i].IsOnTop = false;
            //If the GameScreen requires to be on top and is on top or doesn't requires focus to be updated.
            if ((GameScreen.listGameScreen[i].RequireFocus && GameScreen.listGameScreen[i].IsOnTop) || !GameScreen.listGameScreen[i].RequireFocus)
            {
                //Update everything in the GameScreen List and delete it if not Alive.
                GameScreen.listGameScreen[i].Update(gameTime);
                if (!GameScreen.listGameScreen[i].Alive)//Delete, then decrement i to go back at the last instance in the list.
                    GameScreen.listGameScreen.RemoveAt(i--);
            }
        }
        if (GameScreen.listGameScreen.Count == 0)
            this.Exit();

        KeyboardHelper.PlayerStateLast = Keyboard.GetState();
        base.Update(gameTime);
    }

    /// <summary>
    /// This is called when the game should draw itself.
    /// </summary>
    /// <param name="gameTime">Provides a snapshot of timing values.</param>
    protected override void Draw(GameTime gameTime)
    {
        spriteBatch.Begin();
        GraphicsDevice.Clear(Color.White);

        // TODO: Add your drawing code here
        for (int i = 0; i < GameScreen.listGameScreen.Count; i++)
            if ((GameScreen.listGameScreen[i].RequireDrawFocus && GameScreen.listGameScreen[i].IsOnTop) || !GameScreen.listGameScreen[i].RequireDrawFocus)
                if (GameScreen.listGameScreen[i].Alive)
                    GameScreen.listGameScreen[i].Draw(gameTime, spriteBatch);
        spriteBatch.End();
        base.Draw(gameTime);
    }
}

