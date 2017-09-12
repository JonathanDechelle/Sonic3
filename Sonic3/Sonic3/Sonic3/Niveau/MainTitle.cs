using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using Microsoft.Xna.Framework.Media;

public class MainTitle : GameScreen
{
    private enum EMainTitleMode
    {
        Normal = 0,
        Competition = 1,
        COUNT
    }

    private Sonic3Emblem m_MainTitleEmblem;
    private TailPlaneMainTitle m_TailPlane;
    private SonicMainTitle m_Sonic;
    private EMainTitleMode m_MainTitleMode;

    public MainTitle(IServiceProvider aServiceProvider, GraphicsDeviceManager aGraphics)
        :base(aServiceProvider, aGraphics)
    {}

    public override void Load()
    {
        SetupSonicTheme();
        LaunchSonicTheme();

        CreateMainTitleEmblem();
        CreateTailPlane();
        CreateSonic();
    }

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


    public override void Update(GameTime aGameTime)
    {
        base.Update(aGameTime);

        m_Sonic.Update(aGameTime);
        m_MainTitleEmblem.Update();
        m_TailPlane.Update(aGameTime);
    }

    #region MainTitleMenu
    public override void OnDirectionPressed(Keys aKeys)
    {
        if (KeyboardHelper.KeyPressed(Keys.Down) || KeyboardHelper.KeyPressed(Keys.Up))
        {
            ToggleMode();
        }
    }

    public override void OnEnterPressed()
    {
        ChangeScreen(m_MainTitleMode);
    }

    private void ChangeScreen(EMainTitleMode aMode)
    {
        switch (aMode)
        {
            case EMainTitleMode.Normal:
                GameScreenManager.Instance.ChangeScreen(EScreen.MainMenu);
                break;
            case EMainTitleMode.Competition:
                GameScreenManager.Instance.ChangeScreen(EScreen.SplashScreen);
                break;
        }
    }

    private void ToggleMode()
    {
        m_MainTitleMode = (EMainTitleMode)(((int)m_MainTitleMode + 1) % (int)EMainTitleMode.COUNT);
    }
    #endregion

    public override void Draw(GameTime aGameTime, SpriteBatch aSpritebatch)
    {
        DrawMainTitleBackground(aSpritebatch);
        DrawMaintTitleMenu(aSpritebatch);
        DrawCopyRight(aSpritebatch);

        m_TailPlane.Draw(aGameTime, aSpritebatch);
        m_Sonic.Draw(aGameTime, aSpritebatch);
        m_MainTitleEmblem.Draw(aGameTime, aSpritebatch);
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

    private static void DrawMainTitleBackground(SpriteBatch aSpritebatch)
    {
        aSpritebatch.Draw(RessourceSonic3.BackIntro, new Rectangle(0, 0, 800, 500), Color.White);
    }

    private static void DrawCopyRight(SpriteBatch aSpritebatch)
    {
        aSpritebatch.Draw(RessourceSonic3.CopyRight, new Rectangle(600, 440, RessourceSonic3.CopyRight.Width * 2, RessourceSonic3.CopyRight.Height * 2), Color.White);
    }
}
