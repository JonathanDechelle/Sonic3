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
    /// Classe servant à créer un personnage de type sonic
    /// </summary>
    public class PlayerSonic : AllAnimationSonic
    {
        public SpriteEffects flip = SpriteEffects.None;
        public Vector2 Position;
        public Vector2 Speed;
        public Rectangle RecPerso;
        Animation NothingNormal,  WalkigNormal, JumpNormal,JumpForwardNormal, Attack, Crouch,Rolling,SpiningCharge,Hurt,MiCourse,Course,
                  DustSpin;
        public Animation Death;
        AnimationPlayer Ap2;
        public bool HasJump = true, SurObject, SousObject, DroiteObject, GaucheObject,
        Transformation, LoxiTransformation = false, ChargingTurbo, bCrouch, turbo, EnBoule,Attack1,Injure,Rebound,Enabled;
        public float VitesseDepart = 2;
        bool GravityLimit, GravityActive, Gravity = true;
        int NumberSpin,NumPerso;
        public float Rotation = 0;

        public PlayerSonic(bool GravityLimit, bool GravityActive,int NumPerso)
        {
            this.GravityLimit = GravityLimit;
            this.GravityActive = GravityActive;
            this.NumPerso = NumPerso;
            if (!GravityActive)
                HasJump = false;
            Ap2 = new AnimationPlayer();
            Position.X = 100;
            Position.Y = 50;
        }

        public void Load(ContentManager Content)
        {
            #region Sonic
            RecPerso = new Rectangle(Convert.ToInt32(Position.X), Convert.ToInt32(Position.Y), 80, 80);
            DustSpin = new Animation(RessourceSonic3.DustSpin, 80, 0.05f, 2, true);
            //Pack Sonic
            if (NumPerso == 1)
            {
                NothingNormal = SonicWaiting;
                WalkigNormal = SonicWalking;
                Attack = SonicAttack1;
                JumpForwardNormal = SonicJump;
                JumpNormal = SonicJump;
                Crouch = SonicCrouch;
                Rolling = SonicBalle;
                SpiningCharge = SonicSpin;
                Hurt = SonicHurt;
                MiCourse = SonicMiCourse;
                Course = SonicCourse;
                Death = SonicSoDead;
            }
            else
            {
                //Pack Tail
                NothingNormal = TailWaiting;
                WalkigNormal = TailWalking;
                JumpNormal = TailJump;
                JumpForwardNormal = TailJumpForward;
                Crouch = TailCrouch;
                Rolling = TailBalle;
                SpiningCharge = TailSpin;
                MiCourse = TailMiCourse;
                Course = TailCourse;
                Attack = TailAttack1;
                Hurt = TailcHurt;
                Death = TailSoDead;
            }
            #endregion
        }

        public void Update(GameTime gametime,List<ObjCollisionable> Obstacles, SoundEffect JumpEffect, SoundEffect ShootEffect,int NumShield)
        {
            Position += Speed;

            //Speed.X(MAX)
            if (Math.Abs(Speed.X) > 15)
            {
                if (Math.Sign(Speed.X) == -1)
                    VitesseDepart = -15;
                else
                    VitesseDepart = 15;
            }
            RecPerso.X = Convert.ToInt32(Position.X) - RecPerso.Width / 2;
            RecPerso.Y = Convert.ToInt32(Position.Y) - RecPerso.Height - (RecPerso.Height / 2);
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
                        Injure = false;
                        Attack1 = false;
                        Gravity = false;
                        SurObject = true;

                        if (Rebound)
                        {
                            Speed.Y -= 6;
                            HasJump = true;
                            Rebound = false;
                        }
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
                            SurObject = true;
                            if (Objects.Loop)
                            {
                                Position.Y -= 8;
                                DroiteObject = false;
                            }
                            else
                                Speed.X = 0;
                        }
                    if (RecPerso.isOnLeftOf(Objects.DimObj))
                    {
                        GaucheObject = true;
                        SurObject = true;
                        if (Objects.Loop)
                        {
                            Position.Y -= 8;
                            GaucheObject = false;
                        }
                        else
                            Speed.X = 0;
                    }
                    else
                        if(RecPerso.Intersects(Objects.DimObj))
                        {
                            Rotation = Objects.Rotation;

                            if (Objects.Loop)
                            {
                                Position.Y -= 6;
                            }

                        }
                    

                }
            }
            #endregion

            if (!Enabled) //bloquer les bouton lors de la transformation
            {
                #region touche W,A,S,D
                if ((KeyboardHelper.KeyHold(Keys.W) || KeyboardHelper.KeyHold(Keys.Up)) && !HasJump)
                {
                    flip = SpriteEffects.None;

                    if (!OutofWindow(RecPerso, "W") && !SousObject)
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
                else if ((KeyboardHelper.KeyHold(Keys.A) || KeyboardHelper.KeyHold(Keys.Left)) && !EnBoule)
                {

                    if (!OutofWindow(RecPerso, "A") && !DroiteObject)
                    {
                        if (Speed.X > 0)
                        {
                            if (VitesseDepart > 2)
                                VitesseDepart -= 0.15f;
                            else
                                VitesseDepart = -2;
                        }

                        Speed.X = VitesseDepart;
                        VitesseDepart -= (float)(gametime.ElapsedGameTime.TotalSeconds) * 4;
                        if (!HasJump && !Gravity)
                            Speed.Y = 0;

                        flip = SpriteEffects.FlipHorizontally;
                    }
                    else
                        Speed.X = 0;
                }
                else if ((KeyboardHelper.KeyHold(Keys.S) || KeyboardHelper.KeyHold(Keys.Down)) && !HasJump)
                {
                    if (!OutofWindow(RecPerso, "S") && !SurObject)
                    {
                        // Speed.Y = 2;
                        //Speed.X = 0;
                        //do nohting for now
                    }
                    else
                    {
                        Speed.Y = 0;
                        if (Speed.X > 0) Speed.X -= (float)gametime.ElapsedGameTime.TotalSeconds * 3;
                        else if (Speed.X < 0) Speed.X += (float)gametime.ElapsedGameTime.TotalSeconds * 3;
                    }
                }
                else if ((KeyboardHelper.KeyHold(Keys.D) || KeyboardHelper.KeyHold(Keys.Right)) && !EnBoule)
                {
                    if (!OutofWindow(RecPerso, "D") && !GaucheObject)
                    {
                        if (Speed.X < 0)
                        {
                            if (VitesseDepart < -2)
                                VitesseDepart += 0.15f;
                            else
                                VitesseDepart = 2;
                        }

                        Speed.X = VitesseDepart;

                        VitesseDepart += (float)gametime.ElapsedGameTime.TotalSeconds * 4;
                        if (!HasJump && !Gravity)
                            Speed.Y = 0;

                        flip = SpriteEffects.None;
                    }
                    else
                        Speed.X = 0;
                }
                else
                {
                    if (Speed.X > 0.5)
                    {
                        Speed.X -= (float)gametime.ElapsedGameTime.TotalSeconds * 3;
                        VitesseDepart -= (float)gametime.ElapsedGameTime.TotalSeconds * 3;
                    }
                    else if (Speed.X < 0)
                    {
                        Speed.X += (float)gametime.ElapsedGameTime.TotalSeconds * 3;
                        VitesseDepart += (float)gametime.ElapsedGameTime.TotalSeconds * 3;
                    }
                    else
                    {
                        Speed.X = 0;
                        VitesseDepart = 2;
                    }
                    if (!GravityActive)
                        Speed.Y = 0;
                }

                #endregion
                #region Space
                if (GravityActive)
                {
                    if (KeyboardHelper.KeyPressed(Keys.Space) && HasJump)
                    {
                        if (NumShield == 0)
                            Attack1 = true;

                        else
                        {
                            Speed.Y = 7;
                            Rebound = true;
                        }
                    }
                    if (KeyboardHelper.KeyPressed(Keys.Space) && !HasJump && !bCrouch)
                    {
                        Position.Y -= 10;
                        Speed.Y = -5;
                        RessourceSonic3.Jump.Play();
                        HasJump = true;
                        Gravity = true;
                        EnBoule = false;
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
                            Attack1 = false;
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
                #region Boule et pente
                if (!SurObject && !DroiteObject && !GaucheObject && (EnBoule || bCrouch))
                {
                    if (Speed.X > -4 && Speed.X < 4)
                    {
                        if (flip == SpriteEffects.None)
                            Speed.X = 4;
                        else
                            Speed.X = -4;
                    }
                    EnBoule = true;
                }

                #endregion
                #region Animation Par rapport au touche
                bCrouch = false;
                #region Si Position X change
                if (Speed.X != 0)
                {

                    if (HasJump)
                    {
                        if (Attack1)
                        {
                            AnimationPlayer.PlayAnimation(Attack);
                            if (AnimationPlayer.FrameIndex == Attack.FrameCount-1)
                                Attack1 = false;
                        }
                        else if (Injure)
                            AnimationPlayer.PlayAnimation(Hurt);

                        else
                            AnimationPlayer.PlayAnimation(JumpForwardNormal);
                    }

                    else if (KeyboardHelper.KeyPressed(Keys.S) || KeyboardHelper.KeyPressed(Keys.Down) || EnBoule)
                    {
                        AnimationPlayer.PlayAnimation(Rolling);
                        EnBoule = true;
                    }

                    else if (Math.Abs(Speed.X) > 9)
                        AnimationPlayer.PlayAnimation(Course);
                    else if (Math.Abs(Speed.X) > 6)
                        AnimationPlayer.PlayAnimation(MiCourse);
                    else
                        AnimationPlayer.PlayAnimation(WalkigNormal);

                    if (Math.Abs(Speed.X) < 2 && EnBoule)
                    {
                        VitesseDepart = 2;
                        EnBoule = false;
                    }

                }
                #endregion
                #region Si Position X reste pareil
                else if (Speed.X == 0)
                {
                    if (HasJump)
                    {
                        if (Attack1)
                        {
                            AnimationPlayer.PlayAnimation(Attack);
                            if (AnimationPlayer.FrameIndex == Attack.FrameCount-1)
                                Attack1 = false;
                        }
                             else if (Injure)
                            AnimationPlayer.PlayAnimation(Hurt);
                        else
                            AnimationPlayer.PlayAnimation(JumpNormal);

                    }

                    else if (KeyboardHelper.KeyHold(Keys.Down) || KeyboardHelper.KeyHold(Keys.S))
                    {
                        bCrouch = true;
                        if (KeyboardHelper.KeyPressed(Keys.Space))
                        {
                            ChargingTurbo = true;
                            NumberSpin++;
                            if (NumberSpin > 10)
                                NumberSpin = 10;

                            if (NumberSpin < 6)
                                RessourceSonic3.Spin.Play();
                            else
                                RessourceSonic3.Spin2.Play();

                            AnimationPlayer.PlayAnimation(SpiningCharge);
                            Ap2.PlayAnimation(DustSpin);
                        }
                        else if (!ChargingTurbo)
                        {
                            AnimationPlayer.PlayAnimation(Crouch);
                        }
                    }
                    else if (ChargingTurbo)
                    {
                        ChargingTurbo = false;
                        Ap2.PlayAnimation(null);
                        if (flip == SpriteEffects.None)
                            Speed.X = NumberSpin * 3;
                        else
                            Speed.X = -(NumberSpin * 3);
                        NumberSpin = 0;
                        EnBoule = true;
                    }
                    else
                    {
                        AnimationPlayer.PlayAnimation(NothingNormal);
                        Ap2.PlayAnimation(null);
                    }

                }
                #endregion
                #endregion
            }

            else { Speed.X = 0; Speed.Y = 0; EnBoule = false; }

#warning si jamais bug avec les animation
            //les remettre ici-----------

            //------------------------------
        }

   
   

        public void Draw(GameTime gametime, SpriteBatch g)
        {
          
            if (AnimationPlayer.Animation != null)

                if (flip == SpriteEffects.None)
                    Ap2.Draw(gametime, g, new Vector2(Position.X - 60, Position.Y - 5), SpriteEffects.None);
                else
                    Ap2.Draw(gametime, g, new Vector2(Position.X + 60, Position.Y - 5), SpriteEffects.FlipHorizontally);
            AnimationPlayer.Draw(gametime, g, Position, flip,Rotation);
           // g.Draw(RessourceSonic3.Test, RecPerso, Color.White);
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
                    if (GravityLimit)
                        if (NewPos.X <= 0) outofWindow = true;
                    break;
                case "S": NewPos.Y += 2;
                    if (!GravityActive || GravityLimit)
                        if (NewPos.Y + NewPos.Height >= 500) outofWindow = true;
                    break;
                case "D": NewPos.X += 2;
                    if (!GravityActive || GravityLimit)
                        if (NewPos.X + NewPos.Width >= 800) outofWindow = true;
                    break;
            }


            return outofWindow;
        }

    }
}
