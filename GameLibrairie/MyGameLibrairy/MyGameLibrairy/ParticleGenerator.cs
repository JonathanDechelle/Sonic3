using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace MyGameLibrairy
{
    /// <summary>
    /// Créateur de particules
    /// </summary>
    public  class ParticleGenerator
    {
        Texture2D texture;
        float spawnWidth;
        float density;

        List<RainDrop> raindrops = new List<RainDrop>();

        float Timer;

        Random rand1, rand2;

        public ParticleGenerator(Texture2D NewTexture, float NewSpawnWidth, float NewDensity)
        {
            texture = NewTexture;
            spawnWidth = NewSpawnWidth;
            density = NewDensity;

            rand1 = new Random();
            rand2 = new Random();
        }

        public void CreateParticle()
        {
            //double anything =rand1.Next();
            raindrops.Add(new RainDrop(texture, new Vector2(-50 + (float)rand1.NextDouble() * spawnWidth, 0)
                                              , new Vector2(1, rand2.Next(5, 8))));                                 
        }

        public void Update(GameTime gametime, GraphicsDevice graphics)
        {
            Timer += (float)gametime.ElapsedGameTime.TotalSeconds;

            while (Timer > 0)
            {
                Timer -= 1f / density;
                CreateParticle();
            }

            for (int i = 0; i < raindrops.Count; i++)
            {
                raindrops[i].Update();
                if (raindrops[i].Position.Y > graphics.Viewport.Height)
                {
                    raindrops.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Draw(SpriteBatch g)
        {
            foreach (RainDrop raindrop in raindrops)
                raindrop.Draw(g);
        }
    }
}
