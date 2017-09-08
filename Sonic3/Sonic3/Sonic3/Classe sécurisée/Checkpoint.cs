using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sonic3
{
    class Checkpoint
    {
        Texture2D Texture;
        public Vector2 Position;
        public Rectangle RecCheck,RecPerso;
        Animation CheckpointAnim = new Animation(RessourceSonic3.CheckPasser, 80, 0.2f, 2, true);
        AnimationPlayer Ap = new AnimationPlayer();
        public bool Passer,Dernier;
        public int CheckPointID;

        public Checkpoint(Vector2 Position,int CheckPointID)
        {
            Texture = RessourceSonic3.CheckNonPasser;
            this.Position = Position;
            RecCheck = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            this.CheckPointID = CheckPointID;
        }
        
        public void Update(Rectangle RecPerso)
        {
            this.RecPerso = new Rectangle(RecPerso.X, RecPerso.Y, RecPerso.Width/5, RecPerso.Height); 
           
            if (RecPerso.Intersects(RecCheck) && !Passer)
            {
                Passer = true;
                RessourceSonic3.CheckPoint.Play();
                Ap.PlayAnimation(CheckpointAnim);
                RecCheck.X += 40;
                RecCheck.Y += 81;
            }
        }

        public void Draw(GameTime gametime,SpriteBatch g)
        {
           // g.Draw(RessourceSonic3.Test, RecCheck, Color.Red);
            //g.Draw(RessourceSonic3.Test, RecPerso, Color.Blue);
            if (Passer)
            {
                Ap.Draw(gametime, g, RecCheck, SpriteEffects.None);
            }

            else
                g.Draw(Texture, RecCheck, Color.White);
        }
    }
}
