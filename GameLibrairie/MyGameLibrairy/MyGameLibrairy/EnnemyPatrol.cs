 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace MyGameLibrairy
{
    /// <summary>
    /// Classe servant à créer un ennemi qui patrouille
    /// </summary>
    public class EnnemyPatrol
    {
        Texture2D Texture;
        public Rectangle Rectangle;
        public  Vector2 Position;
        public SpriteEffects Effect;
        Vector2 Origin;
        Vector2 Speed;
        float Rotation = 0f;

        bool Right;
        public  bool DiscoverYou,DroiteObject,GaucheObject; 
        float Distance;
        float OldDistance;

        public EnnemyPatrol(Texture2D NewTexture, Vector2 NewPosition, float NewDistance)
        {
            Texture = NewTexture;
            Position = NewPosition;
            Distance = NewDistance;
            Rectangle = new Rectangle((int)Position.X-90,(int)Position.Y-90,90, 90);
            OldDistance = Distance;
        }

        float playerDistanceX,playerDistanceY;
        public void Update(Player Joueur,List<ObjCollisionable>Obstacles)
        {
            Position += Speed;
            Rectangle.X = (int)Position.X-45;
            Rectangle.Y = (int)Position.Y-90;
            DroiteObject = false; GaucheObject = false;
            Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);

            if (Obstacles != null)
            {
                foreach (ObjCollisionable obstacle in Obstacles)
                {
                    if (Rectangle.isOnRightOf(obstacle.DimObj))
                    {
                        Distance = -1;
                    }
                }
            }

            if (Distance <= 0)
            {
                    Right = true;
                    Speed.X = 1f;
                    Effect = SpriteEffects.FlipHorizontally;
            }
            else if (Distance >= OldDistance)
            {
                    Right = false;
                    Speed.X = -1f;
                    Effect = SpriteEffects.None;
            }

            if (Right) Distance++; else Distance --;

            MouseState mouse = Mouse.GetState();
            if (Joueur != null)
            {
                playerDistanceX =﻿ Joueur.Position.X - Position.X;
                playerDistanceY = Joueur.Position.Y - Position.Y;

                if (playerDistanceX >= -300 && playerDistanceX <= 300 && playerDistanceY>=-100 && playerDistanceY<=100)
                {
                    DiscoverYou =true;
                    if (playerDistanceX < -1)
                    {
                        Speed.X = -1f;
                        Effect = SpriteEffects.None;
                      
                    }
                    else if (playerDistanceX > 1)
                    {
                        Speed.X = 1f;
                        Effect = SpriteEffects.FlipHorizontally;
                    }
                    else if (playerDistanceX == 0)
                    Speed.X = 0f;

                }

                 else
                     DiscoverYou = false;
              
            }
        }
            public void Draw(SpriteBatch g)
            {
                if (Speed.X > 0)
                    g.Draw(Texture, Position, null, Color.White, Rotation, Origin, 1f, Effect, 0f);
                else
                    g.Draw(Texture, Position, null, Color.White, Rotation, Origin, 1f, Effect, 0f);
            }
        }
    }

