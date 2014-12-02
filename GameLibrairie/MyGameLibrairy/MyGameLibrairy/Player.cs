using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;

namespace MyGameLibrairy
{
    /// <summary>
    /// Classe servant à créer un personnage
    /// </summary>
    public class Player:AllAnimationLoxi
    {
        public List<Bullets> bullets = new List<Bullets>();
        SpriteEffects flip = SpriteEffects.None;
        public Vector2 Position;
        Vector2 Speed;
        double AngleTir;
        KeyboardState pastKey;
        public Rectangle RecPerso;
        bool bCrouch;
        Animation NothingNormal, NothingTransfo, WalkigNormal, WalkingTransfo, JumpNormal,JumpTransfo,TransfoNormal,
                  JumpForwardNormal, JumpForwardTransfo,ShootNormal,ShootUpwardNormal,Attack,Crouch,AttackCrouch;

        bool HasJump=true,Gravity = true,SurObject,SousObject,DroiteObject,GaucheObject;
        bool GravityLimit,GravityActive;
        bool Hula = false;
        bool ShootAnim, ShootUp;
        public bool Transformation , LoxiTransformation = false;

        public Player(bool GravityLimit,bool GravityActive)
        {
            this.GravityLimit = GravityLimit;
            this.GravityActive = GravityActive;
            if (!GravityActive)
                HasJump = false;
        }

        public void Load(ContentManager Content)
        {
            #region Loxi
            RecPerso = new Rectangle(Convert.ToInt32(Position.X), Convert.ToInt32(Position.Y), 90, 90);
            NothingNormal = DonaldNothingAnimation;
            NothingTransfo = LoxinothingAnimation;
            WalkigNormal = DonaldWalkingAnimation;
            WalkingTransfo = LoxiwalkAnimation;
            JumpNormal = DonaldJumpAnimation;
            JumpTransfo = LoxiJumpAnimation;
            JumpForwardNormal = DonaldJumpAnimation;
            JumpForwardTransfo = LoxiJumpAnimation;
            TransfoNormal = TransformationAnimation;
            ShootNormal = DonaldShootAnimation;
            ShootUpwardNormal = DonaldShootUpwardAnimation;
            Attack = HulaAnimation;
            Crouch = DonaldWalkingAnimation;
            AttackCrouch = DonaldNothingAnimation;
            #endregion
      
        }

        public void Update(List<ObjCollisionable>Obstacles,SoundEffect JumpEffect,SoundEffect ShootEffect)
        {
            Position += Speed;
            
            RecPerso.X=Convert.ToInt32(Position.X)-90/2;
            RecPerso.Y=Convert.ToInt32(Position.Y)-90-(90/2);
            SurObject = false;
            SousObject = false;
            DroiteObject = false;
            GaucheObject = false;

            #region Obstacle

            if (Obstacles != null)
            {
                foreach (ObjCollisionable Objects in Obstacles)
                {
                    if (RecPerso.isOnTopOf(Objects.DimObj))
                    {
                        Speed.Y = 0;
                        HasJump = false;
                        Gravity = false;
                        SurObject = true;
                        break;
                    }
                    else
                        Gravity = true;
                   
                        if (RecPerso.isOnBottomOf(Objects.DimObj))
                        {
                            SousObject = true;
                            Speed.Y = 0;
                            
                        }
                        else
                            if (RecPerso.isOnRightOf(Objects.DimObj))
                            {
                                DroiteObject = true;
                                Speed.X = 0;
                                
                            }
                        if (RecPerso.isOnLeftOf(Objects.DimObj))
                        {
                            GaucheObject = true;
                            Speed.X = 0;
                             
                        }
                       
                }
            }
            #endregion

            if (!Transformation) //bloquer les bouton lors de la transformation
            {
                #region touche W,A,S,D
                if (KeyboardHelper.KeyHold(Keys.W) || KeyboardHelper.KeyHold(Keys.Up) && !HasJump)
                {
                    flip = SpriteEffects.None;

                    if(KeyboardHelper.KeyPressed(Keys.C))
                    {
                        ShootUp=true;
                    }
                        if (!OutofWindow(RecPerso, "W")&& !SousObject)
                        {
                            if (!GravityActive)
                            {
                                Speed.Y = -2;
                                Speed.X = 0;
                                flip = SpriteEffects.None;
                            }
                        }
                        else
                            Speed.Y = 0;
                    
                }
                else if (KeyboardHelper.KeyHold(Keys.A) || KeyboardHelper.KeyHold(Keys.Left))
                {
                    
                    if (!OutofWindow(RecPerso, "A") &&!DroiteObject)
                    {
                        Speed.X = -2;
                        if(!HasJump && !Gravity)
                        Speed.Y = 0;

                        if (KeyboardHelper.KeyHold(Keys.LeftShift))
                        {
                            Speed.X -= 2;
                            WalkigNormal.FrameTimer = CourseFrameTimer;
                        }
                        else
                        WalkigNormal.FrameTimer = WalkingFrameTimer;

                        flip = SpriteEffects.FlipHorizontally;
                    }
                    else
                        Speed.X = 0;
                }
                else if (KeyboardHelper.KeyHold(Keys.S) || KeyboardHelper.KeyHold(Keys.Down) && !HasJump)
                {
                    if (!OutofWindow(RecPerso, "S")&&!SurObject)
                    {
                        Speed.Y = 2;
                        Speed.X = 0;
                       // flip = SpriteEffects.None;
                    }
                    else
                        Speed.Y = 0;
                }
                else if (KeyboardHelper.KeyHold(Keys.D) || KeyboardHelper.KeyHold(Keys.Right))
                {
                    if (!OutofWindow(RecPerso, "D") && !GaucheObject)
                    {
                        Speed.X = 2;
                        KeyboardHelper.InputRightPressed();
                        if(!HasJump && !Gravity)
                        Speed.Y = 0;

                        if (KeyboardHelper.KeyHold(Keys.LeftShift))
                        {
                            Speed.X += 2;
                            WalkigNormal.FrameTimer = CourseFrameTimer;
                        }
                        else
                            WalkigNormal.FrameTimer = WalkingFrameTimer;
                        flip = SpriteEffects.None;
                    }
                    else
                        Speed.X = 0;
                }
                else
                {
                    Speed.X = 0;
                    if(!GravityActive)
                    Speed.Y = 0;
                    Hula = false;
                }

                #endregion
                #region Space
                if (GravityActive)
                {
                    if (KeyboardHelper.KeyPressed(Keys.Space) && !HasJump && !bCrouch)
                    {
                        Position.Y -= 10;
                        Speed.Y = -5;
                        if (JumpEffect != null)
                            JumpEffect.Play();
                        HasJump = true;
                        Gravity = true;
                    }

                    if (Gravity)
                    {
                        float i = 1;
                        Speed.Y += 0.15f * i;
                    }

                    ///Pour aterrir au sol
                    if (GravityLimit)
                    {
                        if (Position.Y >= 500)
                        {
                            HasJump = false;
                            Gravity = false;
                        }

                        else
                        {
                            Gravity = true;
                        }


                        if (!Gravity)
                            Speed.Y = 0f;
                    }
                }

                #endregion
                #region Transformation
                if(KeyboardHelper.KeyPressed(Keys.T))
                {
                     Transformation = true;
                }
                #endregion
                #region Hula
                if (KeyboardHelper.KeyHold(Keys.LeftAlt))
                {
                    Hula = true;
                }
                #endregion

                UpdateBullets();

                #region Shoot
                if (KeyboardHelper.KeyHold(Keys.C) && pastKey.IsKeyUp(Keys.C)&&GravityActive)
                {
                    ShootAnim = true;
                    if(ShootEffect!=null)
                    ShootEffect.Play();
                    Shoot();
                }
                pastKey = Keyboard.GetState();
                #endregion
            }

            else {Speed.X = 0; Speed.Y = 0; }


            #region Animation Par rapport au touche
            bCrouch = false; 
            #region Si Position X change
            if (Speed.X != 0)
            {
                if (LoxiTransformation)
                {
                    if (HasJump)
                        AnimationPlayer.PlayAnimation(JumpForwardTransfo);
                    else if (Hula)
                        AnimationPlayer.PlayAnimation(Attack);
                    else
                        AnimationPlayer.PlayAnimation(WalkingTransfo);
                }
                else
                {
                    if (HasJump)
                        AnimationPlayer.PlayAnimation(JumpForwardNormal);
                    else if (ShootAnim)
                    {
                        if (ShootUp)
                        {
                            AnimationPlayer.PlayAnimation(ShootUpwardNormal);
                            if (AnimationPlayer.FrameIndex == 8)
                            {
                                ShootAnim = false;
                                ShootUp = false;
                            }
                        }
                        else
                        {
                            AnimationPlayer.PlayAnimation(ShootNormal);
                            if (AnimationPlayer.FrameIndex == 10)
                                ShootAnim = false;
                        }
                    }
                    else
                        AnimationPlayer.PlayAnimation(WalkigNormal);
                }
            }
            #endregion
            #region Si Position X reste pareil
            else if (Speed.X == 0)
            {
                if (Transformation)
                {
                    AnimationPlayer.PlayAnimation(TransfoNormal);
                    if (AnimationPlayer.FrameIndex == 18)
                        Transformation = false;
                    LoxiTransformation = true;
                }
                else
                    if (LoxiTransformation)
                    {
                        if (HasJump)
                            AnimationPlayer.PlayAnimation(JumpTransfo);

                        else if (Hula)
                            AnimationPlayer.PlayAnimation(Attack);
                        else
                            AnimationPlayer.PlayAnimation(NothingTransfo);
                    }
                    else
                    {
                        if (HasJump)
                            AnimationPlayer.PlayAnimation(JumpNormal);

                        else if (ShootAnim)
                        {
                            if (ShootUp)
                            {
                                AnimationPlayer.PlayAnimation(ShootUpwardNormal);
                                if (AnimationPlayer.FrameIndex == 8)
                                {
                                    ShootAnim = false;
                                    ShootUp = false;
                                }
                            }
                            else
                            {
                                AnimationPlayer.PlayAnimation(ShootNormal);
                                if (AnimationPlayer.FrameIndex == 10)
                                    ShootAnim = false;
                            }
                        }
                       

                        else if (KeyboardHelper.KeyHold(Keys.Down) || KeyboardHelper.KeyHold(Keys.S))
                        {
                            bCrouch = true;
                            AnimationPlayer.PlayAnimation(Crouch);
                        }
                        else
                            AnimationPlayer.PlayAnimation(NothingNormal);
                    }
            }
            #endregion
            #endregion
        }

        public void UpdateBullets()
        {
            foreach (Bullets bullet in bullets)
            { 
                bullet.Position += bullet.Speed;
                bullet.Rectangle=new Rectangle((int)bullet.Position.X,(int)bullet.Position.Y,bullet.Texture.Width,bullet.Texture.Height);
                if (Vector2.Distance(bullet.Position, Position) > 500)
                    bullet.isVisible = false;
            }

            for (int i = 0; i < bullets.Count(); i++)
            {
                if (!bullets[i].isVisible)
                {
                    bullets.RemoveAt(i);
                    i--;
                }
            }

            if (ShootUp)
            {
                AngleTir = 300;
            }
            else
                AngleTir = 0;
        }

        public void Shoot()
        {
            Bullets newBullet = new Bullets(RessourcesLoxi.BalleJoueur);
            newBullet.Speed = new Vector2((float)Math.Cos(AngleTir), (float)Math.Sin(AngleTir)) * 5f + Speed;
            if (flip == SpriteEffects.FlipHorizontally)
            {
                newBullet.Speed = -newBullet.Speed;
                newBullet.SpriteEffect = flip;
            }
            else
                newBullet.SpriteEffect = SpriteEffects.None;
            
            newBullet.Position = Position + newBullet.Speed * 5;
            newBullet.Position.Y -= RecPerso.Height;
            newBullet.isVisible = true;

            if (bullets.Count() < 20)
                bullets.Add(newBullet);
        }

        public void Draw(GameTime gametime,SpriteBatch g)
        {
            AnimationPlayer.Draw(gametime, g, Position, flip);
            foreach (Bullets bullet in bullets)
            {
                bullet.Draw(g);
            }
           //g.Draw(Ressources.Test, RecPerso, Color.White);
        }

        public bool OutofWindow(Rectangle Position, string Direction)
        {
            Rectangle NewPos = Position;
            bool outofWindow = false;

            switch (Direction)
            {
                case "W": NewPos.Y -= 2;
                    if (GravityLimit) 
                    if (NewPos.Y <= 0) outofWindow = true;
                    break;
                case "A": NewPos.X -= 2;
                    if(GravityLimit)
                    if (NewPos.X <= 0) outofWindow = true;
                    break;
                case "S": NewPos.Y += 2;
                    if (!GravityActive || GravityLimit)
                        if (NewPos.Y+NewPos.Height  >= 500) outofWindow = true;
                    break;
                case "D": NewPos.X += 2;
                    if (!GravityActive|| GravityLimit)
                        if (NewPos.X+NewPos.Width >= 800) outofWindow = true;
                    break;
            }

          
            return outofWindow;
        }
   
    }
}
