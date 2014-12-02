using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MyGameLibrairy
{
    /// <summary>
    /// Classe servant à crée des boutons autonomes
    /// </summary>
    public class Button
    {
        Texture2D Texture;
        public Vector2 Position;
        Rectangle Rectangle;
        Rectangle mouseRectangle;

        Color color = new Color(255, 255, 255, 255);

        public Vector2 size;

        public Button(Texture2D Texture,Vector2 NewPosition,float Resize)
        {
            this.Texture = Texture;
            //ScreenW=800 ScreenH= 500
            //ImgW=100    ImgH=20

            ///Divide for keep the properties
            ///
            Position = NewPosition;
            size = new Vector2(Texture.Width/Resize,Texture.Height/Resize);
        }

        bool down;
        public bool IsCliked;
        public void Update(MouseState Mouse)
        {
            Rectangle=new Rectangle((int)Position.X,(int)Position.Y,
                                    (int)size.X,(int)size.Y);

             mouseRectangle = new Rectangle(Mouse.X, Mouse.Y, 1, 1);

            if (mouseRectangle.Intersects(Rectangle))
            {
                if (color.A == 255) down = false;
                if (color.A == 0) down = false;
                if (down) color.A += 3; else color.A -= 3;
                if (Mouse.LeftButton == ButtonState.Pressed) IsCliked = true;
            }
            else if(color.A<255)
            {
                color.A+=3;
                IsCliked=false;
            }
        }

        public void setPosition(Vector2 newPosition)
        {
            Position = newPosition;
        }

        public void Draw(SpriteBatch g)
        {
            g.Draw(Texture, Rectangle, color);
        }
    }
}