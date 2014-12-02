using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using MyGameLibrairy;

namespace Sonic3
{
    class Parallax
    {
        Vector2 PosBack,PosTexture1,PosTexture2;
        Texture2D Texture1, Texture2;

        public Parallax(Texture2D Texture1, Texture2D Texture2,Vector2 Position)
        {
            this.Texture1 = Texture1;
            this.Texture2 = Texture2;

            PosBack = Position;
            PosTexture1 = Position;
            PosTexture2 = Position;
            PosBack.X -= 400;
            PosBack.Y -= 250;
        }

        public void Update(Vector2 Position)
        {
            PosBack = Position;
            PosBack.X -= 400;
            PosBack.Y -= 250;
        }

        public void Update()
        {
            PosTexture1.X--;
            PosTexture2.X++;
        }

        public void Draw(SpriteBatch g,Camera camera)
        {
            g.Draw(Texture2, PosBack, new Rectangle((int)(camera.X * 0.5f), (int)(camera.Y * 0.5f) - 152, 800, 500), Color.White);
            g.Draw(Texture1, PosBack, new Rectangle((int)(camera.X * 0.8f), (int)(camera.Y * 0.8f) - 240, 800, 500), Color.White);

            //g.Draw(Texture2,PosBack,new Rectangle((int)PosBack.X,(int)PosBack.Y,800,500), Color.White);
            //g.Draw(Texture1,new Rectangle(Color.White);
        }

        public void Draw(SpriteBatch g)
        {
            g.Draw(Texture2, PosBack, new Rectangle((int)(PosTexture1.X * 0.5f), (int)(PosTexture1.Y * 0.5f) - 152, 800, 500), Color.White);
            g.Draw(Texture1, PosBack, new Rectangle((int)(PosTexture2.X * 0.8f), (int)(PosTexture2.Y * 0.8f) - 240, 800, 500), Color.White);
        }
    }
}
