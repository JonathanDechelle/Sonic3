using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sonic3
{
    public class Shield
    {
        Animation AnimationShield;
        AnimationPlayer Ap,Ap2;
        Vector2 Position;
        public int num;
      

        public Shield()
        {
            AnimationShield = AllAnimationSonic.BulleShield;
            Ap = new AnimationPlayer();
            Ap = new AnimationPlayer();
            num = 0;
        }

        public void Update(Vector2 JoueurPosition,bool Rebound)
        {
            Position = new Vector2(JoueurPosition.X,JoueurPosition.Y-20);
            if (Rebound)
            {
                Ap2.PlayAnimation(AllAnimationSonic.BulleJump);
                Ap.PlayAnimation(null);
                Position.Y += 10;
            }
            else
                if (num == 1)
                {
                    Ap2.PlayAnimation(AllAnimationSonic.BulleAnim);
                    Ap.PlayAnimation(AnimationShield);
                }
        }

        public void Draw(SpriteBatch g, GameTime gametime)
        {
            if (num != 0)
            {
                Ap.Draw(gametime, g, Position, SpriteEffects.None);
                Ap2.Draw(gametime, g, new Vector2(Position.X-5,Position.Y+20), SpriteEffects.None);
            }
        }
    }
}
