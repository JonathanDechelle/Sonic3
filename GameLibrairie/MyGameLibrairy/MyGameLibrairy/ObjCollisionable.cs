using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace MyGameLibrairy
{
    /// <summary>
    /// Création d'objet collisionable
    /// </summary>
    public class ObjCollisionable
    {
        //VARIABLE 
        public Rectangle DimObj;
        Texture2D Texture;
        Color Color;
        public bool Loop;
        public float Rotation;

        //CONSTRUCTOR
        public ObjCollisionable(int x, int y, int SizeX, int SizeY, Color Color)
        {
            this.DimObj = new Rectangle(x, y, SizeX, SizeY);
            this.Color = Color;
        }

        public ObjCollisionable(int x, int y, int SizeX, int SizeY,bool Loop)
        {
            this.DimObj = new Rectangle(x, y, SizeX, SizeY);
            this.Loop = Loop;
        }

        public ObjCollisionable(int x, int y, int SizeX, int SizeY, bool Loop,float Rotation)
        {
            this.DimObj = new Rectangle(x, y, SizeX, SizeY);
            this.Loop = Loop;
            this.Rotation = Rotation;
        }

        public ObjCollisionable(int x, int y,Texture2D Texture,int SizeX,int SizeY,Color Color)
        {
            this.Texture = Texture;
            this.DimObj = new Rectangle(x, y, SizeX, SizeY);
            this.Color = Color;
        }

        //METHODE
        //UPDATE DRAW
        public  void Update(GameTime gameTime)
        {
           
        }

        public  void Draw(SpriteBatch g)
        {
            //g.Draw(Texture, DimObj, Color);
           // g.Draw(RessourceSonic3.Test, DimObj, Color.Blue);
        }
    }
}

