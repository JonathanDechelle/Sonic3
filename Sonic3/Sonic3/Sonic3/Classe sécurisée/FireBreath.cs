using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sonic3
{
    class FireBreath
    {
        Texture2D Texture;
        Rectangle RecPersoModif,RecBullet,RecFusee;
        public Rectangle RecMiniBoss;
        Vector2 PositionInit,PositionOscillation;
        AnimationPlayer FireAnimationPlayer,TouchAnimationPlayer,BulletAnimationPlayer;
        Animation FireAnimation,TouchAnimation,FireBullet,MiniBossDes;
        bool Descente,Stabiliser,GDDeplacement,DeplaceDroite,flipCheck,OscillCheck,OscillationUp;
        float CompteurStabilisateur=0,VitesseStabiliser=1.2f,Vitesse=3f,OscillationMax=10,CompteurTouch,AttenteDeDestruction;
        int NbFoisStabiliser,NbFoisTouche;
        SpriteEffects flip=SpriteEffects.None;
        Vector2 BulletPos = new Vector2();
        public bool Destroy,Finish;
        public Vector2 Position;
        bool TouchCheck,TouchFuseeCheck,SoundCheck,BulletTouchSonic;

        public FireBreath(Vector2 Position)
        {
            Texture = RessourceSonic3.MiniBoss1;
            this.Position = new Vector2(Position.X + 80, Position.Y + 50);
            PositionInit = this.Position;
            RecMiniBoss = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            Descente = true;
            TouchAnimation = new Animation(RessourceSonic3.MiniBoss1Touch, 160, 0.010f, 1, true);
            FireAnimation = new Animation(RessourceSonic3.MB1feuAnim, 160, 0.09f, 1, true);
            FireBullet = new Animation(RessourceSonic3.MB1FireBullet, 150, 0.2f, 1, false);
            MiniBossDes = new Animation(RessourceSonic3.MiniBossDes, 160, 0.2f, 1, false);
            FireAnimationPlayer = new AnimationPlayer();
            TouchAnimationPlayer = new AnimationPlayer();
            BulletAnimationPlayer = new AnimationPlayer();
        }

        public void Update(GameTime gametime,PlayerSonic Joueur,ref int RingsPosses,ref int Life, ref List<Ring> Rings, Random RringsY, Random RringsX, ref Shield Shield)
        {
            #region Transfo recPerso
            RecPersoModif = new Rectangle(Joueur.RecPerso.X+20, Joueur.RecPerso.Y, Joueur.RecPerso.Width/4, Joueur.RecPerso.Height);
            //si se baisse evite le missile
            if (Joueur.bCrouch||Joueur.EnBoule)
                RecPersoModif.Y += 40;
            #endregion
            #region deplacement
            if (!Destroy)
            {
                if (!Stabiliser)//Si n'est pas statique 
                {
                    BulletAnimationPlayer.PlayAnimation(null);
                    BulletTouchSonic = false;
                    SoundCheck = false;
                    RecBullet.Location = new Point(-300, 0);

                    if (flip == SpriteEffects.None)
                        BulletPos = new Vector2(Position.X, Position.Y + 180);
                    else
                        BulletPos = new Vector2(Position.X + 170, Position.Y + 180);

                    if (!GDDeplacement)//Si ne va pas de droite a gauche
                    {
                        if (Descente)
                            Position.Y += Vitesse;
                        else
                            Position.Y -= Vitesse;
                    }
                    else
                    {
                        if (!DeplaceDroite)
                            Position.X -= Vitesse;
                        else
                            Position.X += Vitesse;

                        Oscillation();
                    }
                }
                else
                {
                    if (!Descente)
                    {
                        if (!BulletTouchSonic)
                            BulletAnimationPlayer.PlayAnimation(FireBullet);

                        if (!SoundCheck)
                        {
                            RessourceSonic3.FireBullet.Play();
                            SoundCheck = true;
                        }

                        if (flip == SpriteEffects.None)
                        {
                            if (!BulletTouchSonic)
                            {
                                BulletPos.X -= 5;
                                RecBullet = new Rectangle((int)BulletPos.X - 70, (int)BulletPos.Y - 100,
                                RessourceSonic3.MB1FireBullet.Width / 6,
                                RessourceSonic3.MB1FireBullet.Height / 3);
                            }
                        }
                        else
                        {
                            if (!BulletTouchSonic)
                            {
                                BulletPos.X += 5;
                                RecBullet = new Rectangle((int)BulletPos.X, (int)BulletPos.Y - 100,
                                RessourceSonic3.MB1FireBullet.Width / 6,
                                RessourceSonic3.MB1FireBullet.Height / 3);
                            }
                        }
                    }
                    Oscillation();
                }
            }
            #region Limite
            if (!GDDeplacement) // si ne vas pas de droite a gauche
            {
                if (Position.Y > PositionInit.Y + 250)
                {
                    Descente = false;
                    Stabiliser = true;

                    if (!OscillCheck)
                    {
                        PositionOscillation = Position;
                        OscillCheck = true;
                    }
                }
                else if (Position.Y <= PositionInit.Y)
                {
                    Descente = true;
                    Stabiliser = true;

                    if (!OscillCheck)
                    {
                        PositionOscillation = Position;
                        OscillCheck = true;
                    }
                }
            }
            else
            {
                if (!Stabiliser)//si n'est pas stable
                {
                    if (Position.X < PositionInit.X - 550)
                    {
                        GDDeplacement = false; Stabiliser = true; DeplaceDroite = true;
                        NbFoisStabiliser--; flipCheck = false;
                    }

                    else if (Position.X > PositionInit.X)
                    {
                        GDDeplacement = false; Stabiliser = true; DeplaceDroite = false;
                        NbFoisStabiliser--; flipCheck = false;
                    }

                    else if ((Position.X < PositionInit.X - 260 && Position.X > PositionInit.X - 280) && !flipCheck)
                    {
                        if (flip == SpriteEffects.None) flip = SpriteEffects.FlipHorizontally;
                        else flip = SpriteEffects.None;
                        flipCheck = true;
                    }
                }
            }
            #endregion
            if (Stabiliser)//Arret de 5 secondes environs
            {
                CompteurStabilisateur += (float)gametime.ElapsedGameTime.TotalSeconds;

                if (CompteurStabilisateur >= VitesseStabiliser)
                {
                    CompteurStabilisateur = 0;
                    if (OscillCheck)
                        Position = PositionOscillation;
                    OscillCheck = false;
                    Stabiliser = false;
                    NbFoisStabiliser++;
                }

                //Deplacement gaucheDroite
                if (NbFoisStabiliser == 2)
                {
                    NbFoisStabiliser = 0;
                    if (Position.Y <= PositionInit.Y) GDDeplacement = true;
                }
            }
            #endregion

            if (NbFoisTouche == 7 && TouchAnimationPlayer.FrameIndex==6)
                Finish = true;

            if (NbFoisTouche == 6)
            {
                AttenteDeDestruction += (float)gametime.ElapsedGameTime.TotalSeconds;
                Destroy = true;
                if (AttenteDeDestruction > 3)
                {
                    TouchAnimationPlayer.PlayAnimation(MiniBossDes);
                    RessourceSonic3.MiniBossKill.Play();
                    NbFoisTouche++;
                }
            }

            if (!Destroy)
            {
                if (!Joueur.Injure)
                {
                    #region intersection RecMiniBoss/RecPerso
                    //Si touche Au miniBoss
                    if (RecMiniBoss.Intersects(RecPersoModif))
                    {
                        //Si miniboss Toucher
                        if (!TouchCheck)
                        {
                            //si la vitesse joueur x est plus petite que 6 (sinon
                            // sonic rebondit trop loin
                            if (Math.Abs(Joueur.Speed.X) < 5)
                                Joueur.Speed.X = -Joueur.Speed.X * 1.3f;
                            else
                                Joueur.Speed.X = -Joueur.Speed.X * 0.60f;

                            Joueur.Speed.Y = -5;
                            TouchCheck = true;
                            RessourceSonic3.TouchBoss.Play();
                            NbFoisTouche++;
                        }
                    }

                    if (TouchCheck)
                    {
                        TouchAnimationPlayer.PlayAnimation(TouchAnimation);
                        CompteurTouch += (float)gametime.ElapsedGameTime.TotalSeconds;

                        if (CompteurTouch >= VitesseStabiliser / 2)
                        { TouchCheck = false; TouchAnimationPlayer.PlayAnimation(null); CompteurTouch = 0; }
                    }
                    #endregion
                    #region Intersection RecFusee/RecPerso
                    else if (RecFusee.Intersects(RecPersoModif))
                    {
                        if (!TouchFuseeCheck)
                        {
                            CodeExclusifSonic.PerteRing(ref RingsPosses, ref Life, ref Joueur, ref Rings, RringsY, RringsX, ref Shield);
                            TouchFuseeCheck = true;
                        }
                    }
                    #endregion
                    TouchFuseeCheck = false;
                    #region Intersection RecBullet/RecPerso
                    if (RecBullet.Intersects(RecPersoModif))
                    {
                        BulletTouchSonic = true;
                        if (BulletTouchSonic)
                        {
                            BulletAnimationPlayer.PlayAnimation(null);
                            RecBullet.Location = new Point(-300, 0);
                            CodeExclusifSonic.PerteRing(ref RingsPosses, ref Life, ref Joueur, ref Rings, RringsY, RringsX, ref Shield);
                        }

                    }
                    #endregion
                }
            }
            RecMiniBoss = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height/4*3);
            RecFusee = new Rectangle((int)Position.X, (int)Position.Y+120, Texture.Width, Texture.Height/4);

            FireAnimationPlayer.PlayAnimation(FireAnimation);

        }

        public void Draw(SpriteBatch g,GameTime gametime)
        {
          
            if (!Destroy)
            {
                g.Draw(Texture, Position, null, Color.White, 0, new Vector2(), 1, flip, 0);
                BulletAnimationPlayer.Draw(gametime, g, BulletPos, flip);
            }

            TouchAnimationPlayer.Draw(gametime, g, new Vector2(Position.X + 80, Position.Y + 172), flip);
            if (!Destroy) FireAnimationPlayer.Draw(gametime, g, new Vector2(Position.X + 80, Position.Y + 172), flip); 
           
            // g.Draw(RessourceSonic3.Test, RecBullet, Color.Red);
           
        }

        public void Oscillation()
        {
            // Oscillation
            if (OscillationUp) Position.Y -= 0.5f;
            else Position.Y += 0.5f;

            if (Position.Y >= PositionOscillation.Y + OscillationMax)
                OscillationUp = true;
            else if (Position.Y <= PositionOscillation.Y - OscillationMax)
                OscillationUp = false;
        }
    }
}
