using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyGameLibrairy;

namespace Sonic3
{
    class Loop
    {
        Texture2D Texture;
        Vector2 Position;
        public Rectangle RecLoop;
        Vector2 Milieu;
        public List<ObjCollisionable> ListObjColls = new List<ObjCollisionable>();
       

        public Loop(Vector2 Position)
        {
            this.Position = Position;
            Texture = RessourceSonic3.loop;
            RecLoop = new Rectangle((int)this.Position.X,(int) this.Position.Y, Texture.Width, Texture.Height);
            Milieu = new Vector2(this.Position.X + Texture.Width/2-20 , this.Position.Y + Texture.Height / 2);

           

            int PosX = (int)Position.X + 70, PosY = (int)Position.Y + 365;

            //Pente descendante
            for (int i = 6; i >= 0; i--)
            {
                ListObjColls.Add(new ObjCollisionable(PosX, PosY, 30, 30, true));
                PosX += 20;
                PosY += 6;
            }

            //Pente stable
            for (int i = 2; i >= 0; i--)
            {
                ListObjColls.Add(new ObjCollisionable(PosX, PosY, 30, 30, true));
                PosX += 20;
            }

            //Pente montante
            for (int i = 6; i >= 0; i--)
            {
                ListObjColls.Add(new ObjCollisionable(PosX, PosY, 30, 30, true));
                PosX += 20;
                PosY -= 9;
            }
        }

        public void Update(ref PlayerSonic Joueur)
        {
            if (Joueur.Position.X >= Milieu.X)
            {
                //if (Joueur.Position.X >= Milieu.X * 2.5)
                //    AllAnimationSonic.AnimationPlayer.Rotation = -13f;
                //else
                //APloop = AllAnimationSonic.AnimationPlayer;
                //APloop.Rotation = 10;
                //AllAnimationSonic.AnimationPlayer = APloop;

                //AllAnimationSonic.AnimationPlayer.Rotation -= 30f;
            }
            else
            {
                AllAnimationSonic.AnimationPlayer.Rotation = 0;
            }
        }

        public void Draw(SpriteBatch g)
        {
            g.Draw(Texture, Position, Color.White);
            foreach (ObjCollisionable O in ListObjColls)
            {
                g.Draw(RessourceSonic3.Test, O.DimObj, Color.Blue);
            }

            g.Draw(RessourceSonic3.Test, AllAnimationSonic.AnimationPlayer.Origin, Color.Blue);
            g.Draw(RessourceSonic3.Test, Milieu, Color.Red);
        }
    }
}
