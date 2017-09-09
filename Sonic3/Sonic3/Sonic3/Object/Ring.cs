using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

public class Ring
{
    AnimationPlayer Ap = new AnimationPlayer();
    public Vector2 Position, Speed;
    public Rectangle RecRing;
    Rectangle RecPerso;
    public Random r;
    public bool catched, popping, delete, FinPopping;
    bool Capturer, PlayOnce, Gravity;
    public float CompteurPopping, CompteurDelete;

    public Ring(Vector2 Position)
    {
        this.Position = Position;
        RecRing = new Rectangle((int)Position.X - 25, (int)Position.Y - 75, 50, 50);
    }

    public void Update(Rectangle RecPerso, SpriteEffects flip, GameTime gametime)
    {
        Position += Speed;

        if (!popping)
        {
            Speed = new Vector2(0, 0);
            if (Gravity)
                FinPopping = true;
            Gravity = false;
        }

        if (FinPopping)
        {
            CompteurDelete += (float)gametime.ElapsedGameTime.TotalSeconds;
            if (CompteurDelete >= 1)
                delete = true;
        }

        if (flip == SpriteEffects.FlipHorizontally)
        {
            RecPerso = new Rectangle(RecPerso.X, RecPerso.Y, RecPerso.Width / 2, RecPerso.Height);
            if (popping && !Gravity)
            {
                // Speed.X = 2;
                //Speed.Y = -5;
                Gravity = true;
            }
        }

        else
        {
            RecPerso = new Rectangle(RecPerso.X + 30, RecPerso.Y, RecPerso.Width / 2, RecPerso.Height);
            if (popping && !Gravity)
            {
                Speed.X *= -1;
                //Speed.X = -2;
                Gravity = true;
            }
        }

        if (Gravity)
        {
            float i = 1;
            Speed.Y += 0.15f * i;
            CompteurPopping += (float)gametime.ElapsedGameTime.TotalSeconds;
            if (CompteurPopping >= 1.5)
                popping = false;
        }

        this.RecPerso = RecPerso;
        RecRing.X += (int)Speed.X;
        RecRing.Y += (int)Speed.Y;
        if (RecPerso.Intersects(RecRing))
        {
            Ap.PlayAnimation(AllAnimationSonic.RingCatch);
            delete = false;
            if (!PlayOnce)
            {
                RessourceSonic3.CatchRing.Play();
                PlayOnce = true;
            }
            Capturer = true;
        }
        else if (Capturer == false)
            Ap.PlayAnimation(AllAnimationSonic.RingAnim);

        if (Ap.Animation == AllAnimationSonic.RingCatch && Ap.FrameIndex == 3)
            catched = true;
    }

    public void Draw(GameTime gametime, SpriteBatch g)
    {
        //g.Draw(RessourceSonic3.Test, RecRing, Color.Red);
        Ap.Draw(gametime, g, Position, SpriteEffects.None);
        // g.Draw(RessourceSonic3.Test, RecPerso, Color.Blue);

    }
}
