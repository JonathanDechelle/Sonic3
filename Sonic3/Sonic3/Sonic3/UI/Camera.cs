using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

    /// <summary>
    /// Classe servant à crée une caméra qui suivrera le joueur
    /// </summary>
public class Camera
{
    public bool Locked;

    private Matrix transform;
    public Matrix Transform
    {
        get { return transform; }
    }

    private Vector2 Centre;
    private Viewport ViewPort;

    private float zoom = 1;
    private float rotation = 0;

    public float X
    {
        get { return Centre.X; }
        set { Centre.X = value; }
    }

    public float Y
    {
        get { return Centre.Y; }
        set { Centre.Y = value; }
    }

    public float Zoom
    {
        get { return zoom; }
        set
        {
            zoom = value;
            if (zoom < 0.1f) zoom = 0.1f;
        }
    }

    public float Rotation
    {
        get { return rotation; }
        set { rotation = value; }
    }

    public Camera(Viewport NewViewPort)
    {
        ViewPort = NewViewPort;

    }

    public void Update(Vector2 Position)
    {
        Centre = new Vector2(Position.X, Position.Y);

        transform = Matrix.CreateTranslation(new Vector3(-Centre.X, -Centre.Y, 0)) *
                                           Matrix.CreateRotationZ(Rotation) *
                                           Matrix.CreateScale(new Vector3(Zoom, Zoom, 0)) *
                                           Matrix.CreateTranslation(new Vector3(ViewPort.Width / 2, ViewPort.Height / 2, 0));
    }

    public void SetPosition(Vector2 Position)
    {
        Centre = Position;
    }
}
