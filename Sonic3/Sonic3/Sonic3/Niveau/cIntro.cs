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
    AnimationPlayer AnimationPLayer = new AnimationPlayer();
    AnimationPlayer AnimationPlayer2 = new AnimationPlayer();
    Animation TailsAirplane = new Animation(RessourceSonic3.TailAirplane, 100, 0.1f, 2, true);
    Animation SonicOeil = new Animation(RessourceSonic3.ClinOeil, 320, 0.08f, 2, false);
    Animation MainSonic = new Animation(RessourceSonic3.MainSonic, 320, 0.1f, 2, false);
    bool m_CompetitionMode;
    Vector2 PosTail = new Vector2(0, 250);
    Vector2 PosEmbleme = new Vector2(120, 500);
    SpriteEffects TailEffect;
    float Timer, Timer2;

    private SegaSplashScreen m_SegaSplashScreen;
    private EIntroSequence m_IntroSequenceState;

    private enum EIntroSequence
    {
        SplashScreen = 0,
        MainTitle = 1,
    }

    public cIntro(IServiceProvider serviceProvider, GraphicsDeviceManager graphics)
        : base(serviceProvider, graphics)
    {
        MediaPlayer.Play(RessourceSonic3.SegaSong);
        SaveCheckPoint.Life = 3;
        SaveCheckPoint.CheckPointID = 1;
    }

    public override void Load()
    {
        CreateSegaSplashScreen();  
    }

    #region SegaSplashScreen
    private void CreateSegaSplashScreen()
    {
        m_SegaSplashScreen = new SegaSplashScreen();
        m_SegaSplashScreen.Load();
        m_SegaSplashScreen.OnFinishCallback += SegaSplashScreenAnimationFinish;
    }

    private void SegaSplashScreenAnimationFinish()
    {
        m_SegaSplashScreen.OnFinishCallback -= SegaSplashScreenAnimationFinish;
        DeleteSegaSplashScreen();
        LaunchSonicTheme();
        ChangeIntroSequenceState(EIntroSequence.MainTitle);
    }

    private void DeleteSegaSplashScreen()
    {
        m_SegaSplashScreen = null;
    }
    #endregion

    #region Music
    private void LaunchSonicTheme()
    {
        MediaPlayer.IsRepeating = true;
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

    bool retour;
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
        if (m_SegaSplashScreen != null)
        {
            m_SegaSplashScreen.UpdateAnimation();
        }
    }

    private void UpdateMainTitleState(GameTime gameTime)
    {
        Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
        Timer2 += (float)gameTime.ElapsedGameTime.TotalSeconds;

        AnimationPLayer.PlayAnimation(TailsAirplane);

        if (KeyboardHelper.KeyPressed(Keys.Down) || KeyboardHelper.KeyPressed(Keys.Up))
        {
            ToggleMode();
        }

        if (KeyboardHelper.KeyPressed(Keys.Enter))
        {
            ChangeScreen(m_CompetitionMode);
        }

        if (Timer2 >= 3.5)
        {
            AnimationPlayer2.PlayAnimation(SonicOeil);
            if (Timer2 >= 7)
                Timer2 = 0;
        }
        else
            AnimationPlayer2.PlayAnimation(MainSonic);


        if (Timer >= 0.2)
        {

            if (PosEmbleme.Y <= 250)
                PosEmbleme.Y = 250;
            else
                PosEmbleme.Y -= Timer / 5.30f;

            if (PosTail.X <= 860 && retour == false)
            {
                PosTail.X++;
                TailEffect = SpriteEffects.None;
            }
            else if (PosTail.X >= -40)
            {
                PosTail.X--;
                retour = true;
                TailEffect = SpriteEffects.FlipHorizontally;
            }
            else retour = false;
            Timer = 0;
        }
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

    public override void Draw(GameTime gametime, SpriteBatch g)
    {
        g.GraphicsDevice.Clear(Color.White);
        DrawCurrentSequenceState(gametime, g);
    }

    private void DrawCurrentSequenceState(GameTime gametime, SpriteBatch g)
    {
        switch (m_IntroSequenceState)
        {
            case EIntroSequence.SplashScreen:
                DrawSplashScreenState(gametime, g);
                break;
            case EIntroSequence.MainTitle:
                DrawMainTitleState(gametime, g);
                break;
        }
    }

    private void DrawSplashScreenState(GameTime gametime, SpriteBatch g)
    {
        if (m_SegaSplashScreen == null)
        {
            return;
        }

        m_SegaSplashScreen.DrawAnimation(gametime, g);
    }

    private void DrawMainTitleState(GameTime gametime, SpriteBatch g)
    {
        g.Draw(RessourceSonic3.BackIntro, new Rectangle(0, 0, 800, 500), Color.White);
        AnimationPLayer.Draw(gametime, g, PosTail, TailEffect);

        if (m_CompetitionMode)
            g.Draw(RessourceSonic3.CompetIntro, new Rectangle(216, 400, RessourceSonic3.CompetIntro.Width * 2, RessourceSonic3.CompetIntro.Height * 2), Color.White);
        else
            g.Draw(RessourceSonic3.PlayerIntro, new Rectangle(200, 400, RessourceSonic3.PlayerIntro.Width * 2, RessourceSonic3.PlayerIntro.Height * 2), Color.White);

        if (AnimationPlayer2.Animation != null)
        {
            AnimationPlayer2.Draw(gametime, g, new Vector2(400, 400), SpriteEffects.None);

        }

        g.Draw(RessourceSonic3.CopyRight, new Rectangle(600, 440, RessourceSonic3.CopyRight.Width * 2, RessourceSonic3.CopyRight.Height * 2), Color.White);
        g.Draw(RessourceSonic3.SonicEmbleme, new Rectangle((int)PosEmbleme.X, (int)PosEmbleme.Y, RessourceSonic3.SonicEmbleme.Width * 2, RessourceSonic3.SonicEmbleme.Height * 2), Color.White);
    }
}
