using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGameLibrairy;
using Microsoft.Xna.Framework.Input;

namespace Sonic3
{
    class Tele
    {
        Texture2D Texture;
        public Rectangle RecTele;
        Rectangle RecJoueur;
        Vector2 Position,PositionAP;
        AnimationPlayer AP = new AnimationPlayer();
        float Timer = 0;
        bool Activate,OnlyOnce=false,Destroy=false;
        public bool remove;
        int Choix;
        Color colorTele = new Color(255, 255, 255, 255);

        public Tele(int Choix, Vector2 Position,int NumPerso)
        {
            this.Choix = Choix;
            switch (Choix)
            {
                case 1: if (NumPerso == 1) Texture = RessourceSonic3.ItemLife;
                    else Texture = RessourceSonic3.ItemLifeTail;
                    break;
                case 2:Texture=RessourceSonic3.ItemRing;
                    break;
                case 3: Texture = RessourceSonic3.ItemBulleBlanche;
                    break;
            }
            this.Position = Position;
            RecTele = new Rectangle((int)Position.X, (int)Position.Y, 90, 90);
            PositionAP = new Vector2(Position.X + 45, Position.Y + 89);
        }

        public void Update(GameTime gametime,PlayerSonic Joueur,ref int Life,ref int Rings,ref Shield Shield)
        {
            RecJoueur = Joueur.RecPerso;

            if (RecTele.Intersects(RecJoueur) && (Joueur.HasJump || Joueur.EnBoule))
            {
                if (!OnlyOnce)
                {
                    RessourceSonic3.EnnemiItem.Play();
                    OnlyOnce = true;
                    switch (Choix)
                    {
                        case 1: Life++;
                            RessourceSonic3.LifeUp.Play();
                            break;
                        case 2: Rings += 10;
                            RessourceSonic3.CatchRing.Play();
                            if (Rings >= 100)
                            {
                                Life++;
                                RessourceSonic3.LifeUp.Play();
                                Rings -= 100;
                            }
                            break;
                        case 3: Shield.num = 1;
                            break;
                    }

                    if (Joueur.Speed.Y > -3 && !Joueur.EnBoule)
                        Joueur.Speed.Y =- 3f;
                }

            }

            if (!OnlyOnce)
            {
                Timer += (float)gametime.ElapsedGameTime.TotalSeconds;
                if (Timer > 2)
                {
                    Activate = true;
                    if (Timer > 4.5)
                    {
                        Activate = false;
                        Timer = 0;
                    }
                }
                else
                    Activate = false;

                if (Activate)
                    AP.PlayAnimation(AllAnimationSonic.ItemTele);

                else
                    AP.PlayAnimation(null);
            }

            else
            {
                if (AP.FrameIndex == 4)
                {
                    AP.PlayAnimation(null);
                    Texture = RessourceSonic3.ItemDestroy;
                    Destroy = true;
                }

                if (!Destroy)
                {
                    AP.PlayAnimation(AllAnimationSonic.KillEnnemiExplosion);
                    Timer = 0;
                }
                else
                {
                    Timer += (float)gametime.ElapsedGameTime.TotalSeconds;

                    if (Timer > 4)
                        remove = true;
                    else
                        //Clignotement
                        if (Timer > 2)
                        {
                            colorTele.A -= 10;
                            colorTele.B -= 10;
                            colorTele.G -= 10;
                            colorTele.R -= 10;
                        }

                }

            }
        }

        public void Draw(GameTime gametime ,SpriteBatch g)
        { 
            //g.Draw(RessourceSonic3.Test, RecTele, Color.Red);
            
            if (AP.Animation == null)
                g.Draw(Texture, Position, colorTele);
            else
                AP.Draw(gametime, g, PositionAP, SpriteEffects.None);

            //g.Draw(RessourceSonic3.Test, RecJoueur, Color.Blue);
           
        }
    }
}
