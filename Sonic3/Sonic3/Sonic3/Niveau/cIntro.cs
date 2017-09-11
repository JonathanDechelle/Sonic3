using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

class cIntro : GameScreen
{
    private SegaSplashScreen m_SegaSplashScreen;

    public cIntro(IServiceProvider serviceProvider, GraphicsDeviceManager graphics)
        : base(serviceProvider, graphics)
    {
        SaveCheckPoint.Life = 3;
        SaveCheckPoint.CheckPointID = 1;
    }

    public override void Load()
    {
        MediaPlayer.IsMuted = true; // Just for debug remove this later plz   

        CreateSegaSplashScreen();
        PlaySegaSplashScreenTheme();
    }

    //SplashScreen
    #region SegaSplashScreen
    private void CreateSegaSplashScreen()
    {
        m_SegaSplashScreen = new SegaSplashScreen();
        m_SegaSplashScreen.Load();
        m_SegaSplashScreen.OnFinishCallback += SegaSplashScreenAnimationFinish;
    }

    private void PlaySegaSplashScreenTheme()
    {
        m_SegaSplashScreen.StartTheme();
    }

    private void SegaSplashScreenAnimationFinish()
    {
        m_SegaSplashScreen.OnFinishCallback -= SegaSplashScreenAnimationFinish;
        DeleteSegaSplashScreen();

        GoToMainTitle();
    }

    private void GoToMainTitle()
    {
        AddScreen(new MainTitle(serviceProvider, GraphicsDeviceManager));
        RemoveScreen(this);
    }

    private void DeleteSegaSplashScreen()
    {
        m_SegaSplashScreen = null;
    }
    #endregion

    public override void Update(GameTime gameTime)
    {
        UpdateSplashScreen();
    }

    private void UpdateSplashScreen()
    {
        if (m_SegaSplashScreen == null)
        {
            return;
        }

        m_SegaSplashScreen.UpdateAnimation();
    }

    public override void Draw(GameTime aGameTime, SpriteBatch aSpritebatch)
    {
        DrawSplashScreenBackground(aSpritebatch);
        DrawSplashScreen(aGameTime, aSpritebatch);
    }

    private static void DrawSplashScreenBackground(SpriteBatch aSpritebatch)
    {
        aSpritebatch.GraphicsDevice.Clear(Color.White);
    }

    private void DrawSplashScreen(GameTime aGameTime, SpriteBatch g)
    {
        if (m_SegaSplashScreen == null)
        {
            return;
        }

        m_SegaSplashScreen.DrawAnimation(aGameTime, g);
    }
}
