using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sonic3
{
    class Pic
    {
        Rectangle RecPic,RecPerso;
        public Vector2 Position;
        public bool Touched,recCheck;
        Texture2D Texture;

        public Pic(Vector2 Position,bool Verticale)
        {
            Texture = RessourceSonic3.PicVerticale;
            this.Position = Position;
            RecPic = new Rectangle((int)Position.X+10, (int)Position.Y+10, (int)(Texture.Width/1.5), (int)(Texture.Height/1.5));
        }

        public void Update(PlayerSonic Joueur,ref int RingsPosses,ref List<Ring> Rings,ref int Life,ref Shield Shield)
        {
            this.RecPerso = Joueur.RecPerso;
           
            if (RecPerso.isOnLeftOf(RecPic))
                Joueur.Speed.X = -0.5f;
            else if (RecPerso.isOnRightOf(RecPic))
                Joueur.Speed.X = 0.7f;

            if (this.RecPerso.Intersects(RecPic) && !Joueur.Injure)
            {
                Touched = true;
                Joueur.Injure = true;
                Joueur.HasJump = true;
                Joueur.Speed = new Vector2();
                Joueur.VitesseDepart = 0;
                recCheck = true;
                

                #region Regarde en fonction de si sonic a bouclier ou non
                if (Shield.num == 0)
                {
                    if (RingsPosses != 0) RessourceSonic3.LostRing.Play();
                    else { Life--; RessourceSonic3.Hurt.Play(); }

                    if (RingsPosses > 10) RingsPosses = 10;
                    CodeExclusifSonic.PerteRingPic(Position, RingsPosses, ref Rings);
                    RingsPosses = 0;
                }

                else
                {
                    Shield.num = 0;
                    RessourceSonic3.PerteBouclier.Play();
                }
                #endregion
                #region Reaction Soni
                if (Joueur.flip == SpriteEffects.None)
                {
                    Joueur.Speed.X = -5.5f;
                    Joueur.VitesseDepart = 0f;
                    Joueur.Speed.Y = -6.5f;
                }
                else
                {
                    Joueur.Speed.X = 5.5f;
                    Joueur.VitesseDepart = 0f;
                    Joueur.Speed.Y = -6.5f;
                }
                #endregion
            }
            else if (!Joueur.Injure) recCheck = false;
           
        }

        public void Draw(SpriteBatch g)
        {
           // g.Draw(RessourceSonic3.Test, RecPic, Color.OrangeRed);
            g.Draw(Texture, Position, Color.White);
            //g.Draw(RessourceSonic3.Test, RecPerso, Color.Blue);
        }
    }
}
