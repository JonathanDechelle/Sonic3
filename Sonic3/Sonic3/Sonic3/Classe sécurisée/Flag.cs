using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGameLibrairy;

namespace Sonic3
{
    class Flag
    {
        Rectangle RecPerso, RecFlag;
        Vector2 Position, Speed;
        Animation FlagAnim=new Animation(RessourceSonic3.Flag,110,0.08f,1,true);
        AnimationPlayer APFlag=new AnimationPlayer();
        Texture2D ImageFix;
        bool DrawFixImage = true,ArretAnim;
        float TimerFixImage,TimerCheckFixImage;
        public float PosYMinimum;
        public bool Stop,Texte;
        int NumPerso;

        public Flag(Vector2 Position,int NumPerso)
        {
            this.Position = Position;
            this.NumPerso = NumPerso;
            if (NumPerso == 1) ImageFix = RessourceSonic3.SonicFlag;
            else ImageFix = RessourceSonic3.TailFlag;
            RecFlag = new Rectangle((int)Position.X-ImageFix.Width/2, (int)Position.Y-ImageFix.Height-10, ImageFix.Width-40,ImageFix.Height);
            TimerFixImage = FlagAnim.FrameTimer;
        }

        public void Update(GameTime gametime,PlayerSonic Joueur)
        {
            #region Animation/Dessin Image flag
            if (DrawFixImage)
            {
                APFlag.PlayAnimation(null);

                if (!ArretAnim)
                {
                    TimerCheckFixImage += (float)gametime.ElapsedGameTime.TotalSeconds;
                    if (TimerCheckFixImage >= TimerFixImage)
                    {
                        TimerCheckFixImage = 0;
                        DrawFixImage = false;

                        if (NumPerso == 1)
                        {
                            if (ImageFix == RessourceSonic3.SonicFlag)
                                ImageFix = RessourceSonic3.BossGoalSign;
                            else
                                ImageFix = RessourceSonic3.SonicFlag;
                        }
                        else
                        {
                            if (ImageFix == RessourceSonic3.TailFlag)
                                ImageFix = RessourceSonic3.BossGoalSign;
                            else
                                ImageFix = RessourceSonic3.TailFlag;
                        }
                    }
                }
            }

            else
            {
                APFlag.PlayAnimation(FlagAnim);
                if (APFlag.FrameIndex == 3)
                   DrawFixImage = true;
            }
            #endregion
            #region Deplacement
            if (Position.Y < PosYMinimum)
            {
                RecFlag.Location = new Point((int)Position.X - ImageFix.Width / 2 + 20, (int)Position.Y - ImageFix.Height - 10);
                RecPerso = Joueur.RecPerso;
                Position += Speed;
                Speed.Y += 0.12f;

                #region interation Perso
                if (RecPerso.Intersects(RecFlag) && (Joueur.HasJump || Joueur.EnBoule))
                {
                    if (Math.Abs(Joueur.Speed.X) > 0)
                        Speed.X = Joueur.Speed.X * 0.5f;

                    Speed.Y = -5;
                }

                #endregion
            }
            else //si touche le sol
            {
                ArretAnim = true;
                if(!Stop)
                Texte = true;
                Stop = true;
            }
#endregion
        }

        public void Draw(GameTime gametime, SpriteBatch g)
        {
            //g.Draw(RessourceSonic3.Test, RecFlag, Color.Red);

            if(DrawFixImage)
            g.Draw(ImageFix, new Vector2(Position.X - 54, Position.Y - 110), Color.White);
            else
            APFlag.Draw(gametime, g, Position, SpriteEffects.None);

        }


    }
}
