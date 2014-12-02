using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MyGameLibrairy;

namespace Sonic3
{
    public class Tremplin
    {
        public bool OnTremplin;
        Vector2 PositionSimple;
        Vector2 PositionAnim;
        Texture2D TextureImageSimple;
        Animation TremplinAnim;
        AnimationPlayer Ap;
        public Rectangle RecTremplin;
        Rectangle RecJoueurMod;
        bool TremplinHorizontal;
        bool TBasDroite;

        public Tremplin(Vector2 Position,bool Horizontal,bool BasDroite)
        {
            Ap = new AnimationPlayer();
            PositionSimple = Position;
            PositionAnim = new Vector2(PositionSimple.X + 52, PositionSimple.Y + 100);
            TremplinHorizontal = Horizontal;
            TBasDroite = BasDroite;

            if (!Horizontal)
            {
                if (!TBasDroite)
                {
                    TextureImageSimple = RessourceSonic3.TremplinRouge;
                    TremplinAnim = new Animation(RessourceSonic3.tremplinrougeAnim, 100, 0.04f, 1, true);
                }
                else
                {
                    TextureImageSimple = RessourceSonic3.TremplinBas;
                    TremplinAnim = new Animation(RessourceSonic3.TremplinBasAnim, 100, 0.04f, 1, true);
                }
            }
            else
            {
                if (TBasDroite)
                {
                    TextureImageSimple = RessourceSonic3.TremplinH;
                    TremplinAnim = new Animation(RessourceSonic3.TremplinHAnim, 100, 0.04f, 1, true);
                }
                else
                {
                    TextureImageSimple = RessourceSonic3.TremplinH2;
                    TremplinAnim = new Animation(RessourceSonic3.TremplinHAnim2, 100, 0.04f, 1, true);
                }
            }
            RecTremplin = new Rectangle((int)PositionSimple.X, (int)PositionSimple.Y, 100, 100);
            if (TBasDroite && !TremplinHorizontal) RecTremplin.Y -= 100;
        }

        public void Update(PlayerSonic Joueur)
        {
            if(Joueur.flip==SpriteEffects.None)
                RecJoueurMod = new Rectangle(Joueur.RecPerso.X, Joueur.RecPerso.Y, Joueur.RecPerso.Width / 2, Joueur.RecPerso.Height);
            else
                RecJoueurMod = new Rectangle(Joueur.RecPerso.X + 30, Joueur.RecPerso.Y, Joueur.RecPerso.Width / 2, Joueur.RecPerso.Height);

            if (RecJoueurMod.Intersects(new Rectangle(RecTremplin.X,RecTremplin.Y+50,RecTremplin.Width,RecTremplin.Height)))
            {
                OnTremplin = true;
                if (Joueur.Injure == true) Joueur.Injure = false;
                RessourceSonic3.Spring.Play();
                if (!TremplinHorizontal)
                {
                    Joueur.HasJump = true;

                    if (!TBasDroite)
                        Joueur.Speed.Y = -10;
                    else
                    {
                        Joueur.Speed.Y = 10;
                        Joueur.Speed.X /=3;
                    }
                }
                else
                {
                    if (TBasDroite)
                    {
                        Joueur.Speed.X = 15;
                        Joueur.VitesseDepart = 15;
                    }
                    else
                    {
                        Joueur.Speed.X = -15;
                        Joueur.VitesseDepart = -15;
                    }
                }
            }
            
            if (OnTremplin)
            {
                Ap.PlayAnimation(TremplinAnim);
                if (Ap.FrameIndex == 3)
                {
                    OnTremplin = false;
                    Ap.FrameIndex = 0;
                }
            }
        }

        public void Draw(GameTime gametime,SpriteBatch g)
        {
            if (OnTremplin)
                Ap.Draw(gametime, g, PositionAnim, SpriteEffects.None);
            else
                g.Draw(TextureImageSimple, PositionSimple, Color.White);

          //  g.Draw(RessourceSonic3.Test, RecJoueurMod, Color.Blue);
          //  g.Draw(RessourceSonic3.Test, RecTremplin, Color.Red);
        }
    }
}
