using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/// <summary>
/// classe servant a créer une action en animation
/// </summary>
public class Animation
{
    Texture2D texture;

    public Texture2D Texture
    {
        get { return texture; }
    }

    public int FrameWidth;


    public float Resize;

    public int FrameHeight
    {
        get
        {
            return texture.Height;
        }

    }
    float frameTime;
    public float FrameTimer
    {
        get { return frameTime; }
        set { frameTime = value; }
    }

    public int FrameCount;

    bool isLooping;
    public bool IsLooping
    {
        get { return isLooping; }
    }

    public Animation(Texture2D Texture, int FrameWidth, float FrameTime, float Resize, bool IsLooping)
    {
        this.texture = Texture;
        this.FrameWidth = FrameWidth;
        this.frameTime = FrameTime;
        this.Resize = Resize;
        this.isLooping = IsLooping;
        this.FrameCount = Texture.Width / this.FrameWidth;
    }

}
