using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Classe servant a lire les animations 
    /// </summary>
public struct AnimationPlayer
{
    public float Rotation;

    Animation animation;
    public Animation Animation
    {
        get { return animation; }
    }

    int frameIndex;
    public int FrameIndex
    {
        get { return frameIndex; }
        set { frameIndex = value; }
    }

    private float timer;


    public Vector2 Origin
    {
        get { return new Vector2(animation.FrameWidth / 2, animation.FrameHeight); }
    }

    public void PlayAnimation(Animation newAnimation)
    {
        if (animation == newAnimation)
            return;

        animation = newAnimation;
        frameIndex = 0;
        timer = 0;
    }

    public void Draw(GameTime gametime, SpriteBatch g, Vector2 Position, SpriteEffects spriteEffet)
    {
        if (Animation == null)
        {
            //throw new NotSupportedException("Yo,is no animation selected");
        }
        else
        {
            timer += (float)gametime.ElapsedGameTime.TotalSeconds;
            while (timer >= animation.FrameTimer)
            {
                timer -= animation.FrameTimer;
                if (animation.IsLooping)
                    try
                    {
                        frameIndex = (frameIndex + 1) % animation.FrameCount;
                    }
                    catch
                    {
                        frameIndex = 0;
                    }
                else frameIndex = Math.Min(frameIndex + 1, animation.FrameCount - 1);
            }

            Rectangle Rectangle = new Rectangle(frameIndex * Animation.FrameWidth,
                                             0, Animation.FrameWidth, Animation.FrameHeight);

            Rectangle RecResize = new Rectangle((int)Position.X, (int)Position.Y, (int)(Animation.FrameWidth * Animation.Resize),
            (int)(Animation.FrameHeight * Animation.Resize));

            // g.Draw(Animation.Texture,RecResize,Rectangle,Color.White,0,Origin,1,spriteEffet,0);
            g.Draw(Animation.Texture, RecResize, Rectangle, Color.White, Rotation, Origin, spriteEffet, 0);
        }
    }

    public void Draw(GameTime gametime, SpriteBatch g, Vector2 Position, SpriteEffects spriteEffet, Color Couleur)
    {
        if (Animation == null)
        {
            //throw new NotSupportedException("Yo,is no animation selected");
        }
        else
        {
            timer += (float)gametime.ElapsedGameTime.TotalSeconds;
            while (timer >= animation.FrameTimer)
            {
                timer -= animation.FrameTimer;
                if (animation.IsLooping)
                    try
                    {
                        frameIndex = (frameIndex + 1) % animation.FrameCount;
                    }
                    catch
                    {
                        frameIndex = 0;
                    }
                else frameIndex = Math.Min(frameIndex + 1, animation.FrameCount - 1);
            }

            Rectangle Rectangle = new Rectangle(frameIndex * Animation.FrameWidth,
                                             0, Animation.FrameWidth, Animation.FrameHeight);

            Rectangle RecResize = new Rectangle((int)Position.X, (int)Position.Y, (int)(Animation.FrameWidth * Animation.Resize),
            (int)(Animation.FrameHeight * Animation.Resize));

            // g.Draw(Animation.Texture,RecResize,Rectangle,Color.White,0,Origin,1,spriteEffet,0);
            g.Draw(Animation.Texture, RecResize, Rectangle, Couleur, Rotation, Origin, spriteEffet, 0);
        }
    }
    public void Draw(GameTime gametime, SpriteBatch g, Rectangle RecPosition, SpriteEffects spriteEffet)
    {
        if (Animation == null)
        {
            // throw new NotSupportedException("Yo,is no animation selected");
        }
        else
        {
            timer += (float)gametime.ElapsedGameTime.TotalSeconds;
            while (timer >= animation.FrameTimer)
            {
                timer -= animation.FrameTimer;
                if (animation.IsLooping)
                    try
                    {
                        frameIndex = (frameIndex + 1) % animation.FrameCount;
                    }
                    catch
                    {
                        frameIndex = 0;
                    }
                else frameIndex = Math.Min(frameIndex + 1, animation.FrameCount - 1);
            }

            Rectangle Rectangle = new Rectangle(frameIndex * Animation.FrameWidth,
                                             0, Animation.FrameWidth, Animation.FrameHeight);

            Rectangle RecResize = new Rectangle(RecPosition.X, RecPosition.Y, (int)animation.FrameWidth * (RecPosition.Height / animation.FrameWidth), (int)animation.FrameWidth * (RecPosition.Height / animation.FrameWidth));//new Rectangle((int)Position.X, (int)Position.Y, Animation.FrameWidth * (int)Animation.Resize,
            //Animation.FrameHeight * (int)Animation.Resize);

            // g.Draw(Animation.Texture,RecResize,Rectangle,Color.White,0,Origin,1,spriteEffet,0);
            //g.Draw(Animation.Texture, RecResize, Rectangle, Color.White, Rotation, Origin, spriteEffet, 0);

            ///Seulement pour sonic
            g.Draw(Animation.Texture, RecResize, Rectangle, Color.White, Rotation, Origin, spriteEffet, 0);
        }
    }

    public void Draw(GameTime gametime, SpriteBatch g, Vector2 Position, SpriteEffects spriteEffet, float Rotation)
    {
        if (Animation == null)
        {
            //throw new NotSupportedException("Yo,is no animation selected");
        }
        else
        {
            timer += (float)gametime.ElapsedGameTime.TotalSeconds;
            while (timer >= animation.FrameTimer)
            {
                timer -= animation.FrameTimer;
                if (animation.IsLooping)
                    try
                    {
                        frameIndex = (frameIndex + 1) % animation.FrameCount;
                    }
                    catch
                    {
                        frameIndex = 0;
                    }
                else frameIndex = Math.Min(frameIndex + 1, animation.FrameCount - 1);
            }

            Rectangle Rectangle = new Rectangle(frameIndex * Animation.FrameWidth,
                                             0, Animation.FrameWidth, Animation.FrameHeight);

            Rectangle RecResize = new Rectangle((int)Position.X, (int)Position.Y, (int)(Animation.FrameWidth * Animation.Resize),
            (int)(Animation.FrameHeight * Animation.Resize));

            // g.Draw(Animation.Texture,RecResize,Rectangle,Color.White,0,Origin,1,spriteEffet,0);
            g.Draw(Animation.Texture, RecResize, Rectangle, Color.White, Rotation, Origin, spriteEffet, 0);
        }
    }
}

