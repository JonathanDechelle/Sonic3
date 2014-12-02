using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace MyGameLibrairy
{
    /// <summary>
    /// Classe créant la pluie
    /// </summary>
    public class RainDrop
    {
        Texture2D texture;
        Vector2 position;
        Vector2 speed;

        public Vector2 Position
        {
            get { return position; }
        }

        public RainDrop(Texture2D NewTexture, Vector2 NewPosition, Vector2 NewSpeed)
        {
            texture = NewTexture;
            position = NewPosition;
            speed = NewSpeed;
        }

        public void Update()
        {
            position += speed;
        }

        public void Draw(SpriteBatch g)
        {
            g.Draw(texture, position, Color.White);
        }
    }
}
