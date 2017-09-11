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
    private enum EIntroSequence
    {
        SplashScreen = 0,
        MainTitle = 1,
    }

    private enum EMainTitleMode
    {
        Normal = 0,
        Competition = 1,
        COUNT
    }


    private EIntroSequence m_IntroSequenceState;

    //TODO New Screen

    // SplashScreen
    private SegaSplashScreen m_SegaSplashScreen;

    // MainTitle
    private Sonic3Emblem m_MainTitleEmblem;
    private TailPlaneMainTitle m_TailPlane;
    private SonicMainTitle m_Sonic;
    private EMainTitleMode m_MainTitleMode;

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

    //MainTitle
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

    #region MainTitleMenu
    private void OnEnterPressed()
    {
        ChangeScreen(m_MainTitleMode);
    }

    private void ToggleMode()
    {
        m_MainTitleMode = (EMainTitleMode)(((int)m_MainTitleMode + 1) % (int)EMainTitleMode.COUNT);
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
            OnEnterPressed();
        }

        m_Sonic.Update(aGameTime);
        m_MainTitleEmblem.Update();
        m_TailPlane.Update(aGameTime);
    }

    private void ChangeScreen(EMainTitleMode aMode)
    {
        switch (aMode)
        {
            case EMainTitleMode.Normal:
                AddScreen(new cMainMenu(serviceProvider, GraphicsDeviceManager));
                break;
            case EMainTitleMode.Competition:
                AddScreen(new cIntro(serviceProvider, GraphicsDeviceManager));
                break;
        }

        RemoveScreen(this);
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
        DrawMainTitleBackground(aSpritebatch);
        DrawMaintTitleMenu(aSpritebatch);
        DrawCopyRight(aSpritebatch);

        m_TailPlane.Draw(aGameTime, aSpritebatch);
        m_Sonic.Draw(aGameTime, aSpritebatch);
        m_MainTitleEmblem.Draw(aGameTime, aSpritebatch);
    }

    private static void DrawMainTitleBackground(SpriteBatch aSpritebatch)
    {
        aSpritebatch.Draw(RessourceSonic3.BackIntro, new Rectangle(0, 0, 800, 500), Color.White);
    }

    private void DrawMaintTitleMenu(SpriteBatch aSpritebatch)
    {
        switch (m_MainTitleMode)
        {
            case EMainTitleMode.Normal:
                aSpritebatch.Draw(RessourceSonic3.PlayerIntro, new Rectangle(200, 400, RessourceSonic3.PlayerIntro.Width * 2, RessourceSonic3.PlayerIntro.Height * 2), Color.White);
                break;
            case EMainTitleMode.Competition:
                aSpritebatch.Draw(RessourceSonic3.CompetIntro, new Rectangle(216, 400, RessourceSonic3.CompetIntro.Width * 2, RessourceSonic3.CompetIntro.Height * 2), Color.White);
                break;
        }
    }

    private static void DrawCopyRight(SpriteBatch aSpritebatch)
    {
        aSpritebatch.Draw(RessourceSonic3.CopyRight, new Rectangle(600, 440, RessourceSonic3.CopyRight.Width * 2, RessourceSonic3.CopyRight.Height * 2), Color.White);
    }
}
