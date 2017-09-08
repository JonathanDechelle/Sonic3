using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sonic3
{
    public class ObjectMapping
    {
        Texture2D Texture;
        public Vector2 Position;
        public ObjCollisionable Rectangle;

        public ObjectMapping(Texture2D Texture, Vector2 Position,Vector2 DecalementCollision,int SizeX,int SizeY)
        {
            this.Texture = Texture;
            this.Position = Position;
            Rectangle = new ObjCollisionable((int)(this.Position.X + DecalementCollision.X), (int)(this.Position.Y + DecalementCollision.Y), SizeX, SizeY,Color.White);
        }

        public ObjectMapping(int NumObs, Vector2 Position)
        {
            this.Position=Position;
            switch (NumObs)
            {
                case 1: this.Texture = RessourceSonic3.Obstacle1;
                    Rectangle = new ObjCollisionable((int)(this.Position.X + 30), (int)(this.Position.Y + 210), 230, 20, Color.White);
                    break;

                case 2: this.Texture = RessourceSonic3.Obstacle2;
                    Rectangle = new ObjCollisionable((int)(this.Position.X + 20), (int)(this.Position.Y + 210), 240, 20, Color.White);
                    break;

                case 3: this.Texture = RessourceSonic3.Obs3;
                    Rectangle = new ObjCollisionable((int)(this.Position.X + 45), (int)(this.Position.Y + 215), 490, 30, Color.White);
                    break;

                case 4: this.Texture = RessourceSonic3.ArbreCoconut;
                    Rectangle = new ObjCollisionable((int)(this.Position.X), (int)(this.Position.Y), Texture.Height, Texture.Width, Color.White);
                    break;

                case 5: this.Texture = RessourceSonic3.Obs4;
                    Rectangle = new ObjCollisionable((int)(this.Position.X + 45), (int)(this.Position.Y + 250), 480, 20, Color.White);
                    break;

            }
        }

        public void Draw(SpriteBatch g)
        {
            g.Draw(Texture, Position, Color.White);
            //g.Draw(RessourceSonic3.Test, Rectangle.DimObj, Color.Blue);
        }
    }

    
}
