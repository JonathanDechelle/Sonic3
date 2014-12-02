using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MyGameLibrairy
{
    /// <summary>
    /// Classe servant a Crée des balles graphiquement
    /// </summary>
    public class Bullets
    {
        public Texture2D Texture;
        public SpriteEffects SpriteEffect;
        public Vector2 Position;
        public Vector2 Speed;
        public Vector2 Origin;
        public Rectangle Rectangle;
        public bool isVisible;

        public Bullets(Texture2D NewTexture)
        {
            Texture = NewTexture;
            isVisible = false;
        }

        public void Draw(SpriteBatch g)
        {
            g.Draw(Texture, Position, null, Color.White, 0f, Origin, 1f, SpriteEffect, 0);
        }
    }
}
