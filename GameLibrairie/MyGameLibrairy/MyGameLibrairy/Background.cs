using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MyGameLibrairy
{
    /// <summary>
    /// Classe servant a définir un background
    /// </summary>
    public class Background
    {
        public Texture2D texture;
        public Rectangle Rectangle;

        public void Draw(SpriteBatch g)
        {
            g.Draw(texture, Rectangle, Color.White);
        }
    }

    /// <summary>
    /// Classe servant a faire du défilement de background
    /// </summary>
    public class Scrolling : Background
    {
        public Scrolling(Texture2D newTexture, Rectangle newRectangle)
        {
            texture = newTexture;
            Rectangle = newRectangle;
        }

        public void Update()
        {
            //if (KeyboardHelper.KeyHold(Keys.A)||KeyboardHelper.KeyHold(Keys.Left))
            //{
            //    Rectangle.X++;
            //}
            //if (KeyboardHelper.KeyHold(Keys.D) || KeyboardHelper.KeyHold(Keys.Right))
            //{
            //    Rectangle.X--;
            //}
            //if (KeyboardHelper.KeyHold(Keys.W) || KeyboardHelper.KeyHold(Keys.Up))
            //{
            //    Rectangle.Y--;
            //}
            //if (KeyboardHelper.KeyHold(Keys.S) || KeyboardHelper.KeyHold(Keys.Down))
            //{
            //    Rectangle.Y++;
            //}

            Rectangle.X--;
        }
    }
}
