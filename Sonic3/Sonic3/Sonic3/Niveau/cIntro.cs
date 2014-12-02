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
using MyGameLibrairy;


namespace Sonic3
{
    class cIntro : GameScreen
    {
        AnimationPlayer AnimationPLayer = new AnimationPlayer();
        AnimationPlayer AnimationPlayer2 = new AnimationPlayer();
        Animation Intro = new Animation(RessourceSonic3.SegaLogo, 250, 0.2f, 1, true);
        Animation TailsAirplane = new Animation(RessourceSonic3.TailAirplane, 100, 0.1f, 2, true);
        Animation SonicOeil = new Animation(RessourceSonic3.ClinOeil, 320, 0.08f, 2, false);
        Animation MainSonic = new Animation(RessourceSonic3.MainSonic, 320, 0.1f, 2, false);
        bool SegaAnimation = true, Compet;
        Vector2 PosTail = new Vector2(0, 250);
        Vector2 PosEmbleme = new Vector2(120, 500);
        SpriteEffects TailEffect;
        float Timer, Timer2;
        int LogoNum;
        Animation[] TabLogo = new Animation[5];

        public cIntro(IServiceProvider serviceProvider, GraphicsDeviceManager graphics)
            : base(serviceProvider, graphics)
        {
            MediaPlayer.Play(RessourceSonic3.SegaSong);
            SaveCheckPoint.Life = 3;
            SaveCheckPoint.CheckPointID = 1;
        }

        public override void Load()
        {
            TabLogo[0] = new Animation(RessourceSonic3.LogoPart1, 250, 0.10f, 2, false);
            TabLogo[1] = new Animation(RessourceSonic3.LogoPart2, 250, 0.15f, 2, false);
            TabLogo[2] = new Animation(RessourceSonic3.LogoPart3, 250, 0.20f, 2, false);
            TabLogo[3] = new Animation(RessourceSonic3.LogoPart4, 250, 0.25f, 2, false);
            TabLogo[4] = new Animation(RessourceSonic3.LogoPart5, 250, 0.32f, 2, false);
        }

        bool retour;
        public override void Update(GameTime gameTime)
        {
            Timer += (float)gameTime.ElapsedGameTime.TotalMilliseconds;
            Timer2 += (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (!SegaAnimation)
            {
                AnimationPLayer.PlayAnimation(TailsAirplane);

                if (KeyboardHelper.KeyPressed(Keys.Down) || KeyboardHelper.KeyPressed(Keys.Up))
                {
                    if (Compet)
                        Compet = false;
                    else
                        Compet = true;
                }

                if (KeyboardHelper.KeyPressed(Keys.Enter))
                {
                    if (Compet)
                    {
                        AddScreen(new cIntro(serviceProvider, GraphicsDeviceManager));
                        RemoveScreen(this);
                    }
                    else
                    {
                        AddScreen(new cMainMenu(serviceProvider, GraphicsDeviceManager));
                        RemoveScreen(this);
                    }
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
            else
            {
                if (AnimationPLayer.FrameIndex == 4)
                    LogoNum++;

                if (LogoNum == 4)
                    Timer = 0;

                if (LogoNum == 5)
                {
                    SegaAnimation = false;
                    MediaPlayer.IsRepeating = true;
                    MediaPlayer.Play(RessourceSonic3.IntroSong);
                }

                else
                    AnimationPLayer.PlayAnimation(TabLogo[LogoNum]);
            }


        }



        public override void Draw(GameTime gametime, SpriteBatch g)
        {
            g.GraphicsDevice.Clear(Color.White);

            if (SegaAnimation)
                AnimationPLayer.Draw(gametime, g, new Vector2(380, 500), SpriteEffects.None);
            else
            {
                g.Draw(RessourceSonic3.BackIntro, new Rectangle(0, 0, 800, 500), Color.White);
                AnimationPLayer.Draw(gametime, g, PosTail, TailEffect);

                if (Compet)
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
    }
}
