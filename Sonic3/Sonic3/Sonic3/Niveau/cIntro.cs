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
    private SonicMainTitle m_Sonic;

    bool m_CompetitionMode;

    private EIntroSequence m_IntroSequenceState;

    // SplashScreen
    private SegaSplashScreen m_SegaSplashScreen;

    // MainTitle
    private Sonic3Emblem m_MainTitleEmblem;
    private TailPlaneMainTitle m_TailPlane;

    private enum EIntroSequence
    {
        SplashScreen = 0,
        MainTitle = 1,
    }

    public cIntro(IServiceProvider serviceProvider, GraphicsDeviceManager graphics)
        : base(serviceProvider, graphics)
    {
        SaveCheckPoint.Life = 3;
        SaveCheckPoint.CheckPointID = 1;
    }

    public override void Load()
    {
        MediaPlayer.IsMuted = true; // Just for debug remove this later plz   

        //SplashScreen
        CreateSegaSplashScreen();
        PlaySegaSplashScreenTheme();

        //MainTitle
        CreateMainTitleEmblem();
        CreateTailPlane();
        CreateSonic();
    }

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

        SetupSonicTheme();
        LaunchSonicTheme();

        ChangeIntroSequenceState(EIntroSequence.MainTitle);
    }

    private void DeleteSegaSplashScreen()
    {
        m_SegaSplashScreen = null;
    }
    #endregion

    #region Music
    private void SetupSonicTheme()
    {
        MediaPlayer.IsRepeating = true;
    }

    private void LaunchSonicTheme()
    {
        MediaPlayer.Play(RessourceSonic3.IntroSong);
    }
    #endregion

    #region IntroSequenceState
    private void InitializeIntroSequence()
    {
        ChangeIntroSequenceState(EIntroSequence.SplashScreen);
    }

    private void ChangeIntroSequenceState(EIntroSequence aState)
    {
        m_IntroSequenceState = aState;
    }
    #endregion

    #region Emblem
    private void CreateMainTitleEmblem()
    {
        m_MainTitleEmblem = new Sonic3Emblem();
    }
    #endregion

    #region TailPlane
    private void CreateTailPlane()
    {
        m_TailPlane = new TailPlaneMainTitle();
    }
    #endregion

    #region Sonic
    private void CreateSonic()
    {
        m_Sonic = new SonicMainTitle();
    }
    #endregion

    public override void Update(GameTime gameTime)
    {
        UpdateCurrentSequenceState(gameTime);
    }

    private void UpdateCurrentSequenceState(GameTime gameTime)
    {
        switch (m_IntroSequenceState)
        {
            case EIntroSequence.SplashScreen:
                UpdateSplashScreenState();
                break;
            case EIntroSequence.MainTitle:
                UpdateMainTitleState(gameTime);
                break;
        }
    }

    private void UpdateSplashScreenState()
    {
        if (m_SegaSplashScreen == null)
        {
            return;
        }

        m_SegaSplashScreen.UpdateAnimation();
    }

    private void UpdateMainTitleState(GameTime aGameTime)
    {
        if (KeyboardHelper.KeyPressed(Keys.Down) || KeyboardHelper.KeyPressed(Keys.Up))
        {
            ToggleMode();
        }

        if (KeyboardHelper.KeyPressed(Keys.Enter))
        {
            ChangeScreen(m_CompetitionMode);
        }

        m_Sonic.Update(aGameTime);
        m_MainTitleEmblem.Update();
        m_TailPlane.Update(aGameTime);        
    }

    private void ChangeScreen(bool aCompetitionMode)
    {
        if (aCompetitionMode)
        {
            AddScreen(new cIntro(serviceProvider, GraphicsDeviceManager));
        }
        else
        {
            AddScreen(new cMainMenu(serviceProvider, GraphicsDeviceManager));
        }

        RemoveScreen(this);
    }

    private void ToggleMode()
    {
        m_CompetitionMode = !m_CompetitionMode;
    }

    public override void Draw(GameTime aGameTime, SpriteBatch aSpritebatch)
    {
        aSpritebatch.GraphicsDevice.Clear(Color.White);
        DrawCurrentSequenceState(aGameTime, aSpritebatch);
    }

    private void DrawCurrentSequenceState(GameTime aGameTime, SpriteBatch aSpritebatch)
    {
        switch (m_IntroSequenceState)
        {
            case EIntroSequence.SplashScreen:
                DrawSplashScreenState(aGameTime, aSpritebatch);
                break;
            case EIntroSequence.MainTitle:
                DrawMainTitleState(aGameTime, aSpritebatch);
                break;
        }
    }

    private void DrawSplashScreenState(GameTime aGameTime, SpriteBatch g)
    {
        if (m_SegaSplashScreen == null)
        {
            return;
        }

        m_SegaSplashScreen.DrawAnimation(aGameTime, g);
    }

    private void DrawMainTitleState(GameTime aGameTime, SpriteBatch aSpritebatch)
    {
        aSpritebatch.Draw(RessourceSonic3.BackIntro, new Rectangle(0, 0, 800, 500), Color.White);
        
        m_TailPlane.Draw(aGameTime, aSpritebatch);

        if (m_CompetitionMode)
            aSpritebatch.Draw(RessourceSonic3.CompetIntro, new Rectangle(216, 400, RessourceSonic3.CompetIntro.Width * 2, RessourceSonic3.CompetIntro.Height * 2), Color.White);
        else
            aSpritebatch.Draw(RessourceSonic3.PlayerIntro, new Rectangle(200, 400, RessourceSonic3.PlayerIntro.Width * 2, RessourceSonic3.PlayerIntro.Height * 2), Color.White);

        m_Sonic.Draw(aGameTime, aSpritebatch);

        aSpritebatch.Draw(RessourceSonic3.CopyRight, new Rectangle(600, 440, RessourceSonic3.CopyRight.Width * 2, RessourceSonic3.CopyRight.Height * 2), Color.White);

        m_MainTitleEmblem.Draw(aGameTime, aSpritebatch);
    }
}
