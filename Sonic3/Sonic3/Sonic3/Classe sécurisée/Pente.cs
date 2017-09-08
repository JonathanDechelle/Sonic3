using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Sonic3
{
     class Pente
    {
        Texture2D Texture;
        Vector2 Position;
        bool Ascendante;
        public Rectangle RecPente;
   

        public List<ObjCollisionable> ListObjColls = new List<ObjCollisionable>();

        public Pente(int Num,Vector2 Position, bool Ascendante)
        {
            int PosX=0, PosY=0;
            this.Position = Position;
            this.Ascendante = Ascendante;

            switch (Num)
            {
                case 1:
                    #region Pente 1
                    if (!Ascendante)
                    {
                        Texture = RessourceSonic3.Pente1;
                        ListObjColls.Add(new ObjCollisionable((int)Position.X + 50, (int)Position.Y + 30, 40, 20, true));
                        PosX = (int)Position.X + 80;
                        PosY = (int)Position.Y + 18;

                        for (int i = 16; i >= 0; i--)
                        {
                            PosX += 25;
                            PosY += 13;
                            ListObjColls.Add(new ObjCollisionable(PosX, PosY, 30, 30, true));
                        }
                    }
                    else
                    {
                        Texture = RessourceSonic3.Pente1A;
                        PosX = (int)Position.X + 7;
                        PosY = (int)Position.Y + 265;

                        for (int i = 17; i >= 0; i--)
                        {
                            PosX += 25;
                            PosY -= 13;
                            ListObjColls.Add(new ObjCollisionable(PosX, PosY, 30, 30, true));
                        }

                        ListObjColls.Add(new ObjCollisionable((int)PosX + 40, (int)PosY, 40, 20, true));
                    }
#endregion
                    break;
                case 2:
                    if (!Ascendante)
                    {
                        Texture = RessourceSonic3.Pente2;
                        ListObjColls.Add(new ObjCollisionable((int)Position.X + 20, (int)Position.Y + 210, 40, 20, true));
                        PosX = ListObjColls[0].DimObj.X;// + 80;
                        PosY = ListObjColls[0].DimObj.Y;// + 18;

                        for (int i = 4; i >= 0; i--)
                        {
                            PosX += 25;
                            PosY -= 13;
                            ListObjColls.Add(new ObjCollisionable(PosX, PosY, 30, 30, true));
                        }

                        for (int i = 5; i >= 0; i--)
                        {
                            PosX += 10;
                            PosY -= 13;
                            ListObjColls.Add(new ObjCollisionable(PosX, PosY, 30, 30, true));
                        }

                            PosX += 40;
                            //PosY -= 10;
                            ListObjColls.Add(new ObjCollisionable(PosX, PosY, 60, 30, true));
                    }
                    else
                    {

                    }
                    break;
            }
           
            RecPente=new Rectangle((int)Position.X,(int)Position.Y,Texture.Width,Texture.Height);
        }

        public void Update(PlayerSonic Joueur)
        {
            if (RecPente.Intersects(Joueur.RecPerso))
            {
                if (Joueur.Speed.X == 0 && Joueur.EnBoule)
                    Joueur.EnBoule = false;

                //Pour eviter le choc entre les grosseurs des obj
                //Les obj collisionable et le personnage
                if (Joueur.Speed.X == 0 && Joueur.Speed.Y > 0 && Joueur.Speed.Y < 2.5)
                    Joueur.Speed.Y = 0;

                //pour mettre le joueur en boule dans la pente
                if (Joueur.Speed.X > 0 && (KeyboardHelper.KeyPressed(Keys.W) || KeyboardHelper.KeyPressed(Keys.Down)))
                    Joueur.EnBoule = true;
            }
        }

        public void Draw(SpriteBatch g)
        {
            g.Draw(Texture, Position, Color.White);
            //foreach (ObjCollisionable O in ListObjColls)
            //{
            //    g.Draw(RessourceSonic3.Test, O.DimObj, Color.Blue);
            //}
        }
    }
}
