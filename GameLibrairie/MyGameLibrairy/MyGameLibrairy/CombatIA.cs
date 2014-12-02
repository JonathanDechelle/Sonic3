using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;


namespace MyGameLibrairy
{
    /// <summary>
    /// Inititialise un Ennemi en style de combat (Ex.Mortal Kombat)
    /// </summary>
    public class CombatIA:RessourcesLoxi
    {
        public Vector2 Position;
        public Vector2 Speed;
        public Rectangle Rectangle;
        public int Force;
        int Rapidité;
        Random random=new Random();
        int Mouvement;
        float JoueurDistanceX;
        bool AttackYou;
        public bool DamageYou;

        AnimationPlayer AnimationPlayer=new AnimationPlayer();
        Animation AttackAnimation, WalkingAnimation;
        SpriteEffects flip = SpriteEffects.None;

        public CombatIA(Vector2 Position,int Force,int Speed,Animation WalkingAnimation,Animation AttackAnimation)
        {
            this.Force=Force;
            this.Position = Position;
            Rapidité = Speed;
            Rectangle = new Rectangle((int)Position.X-80, (int)Position.Y-160, 160, 160);
            this.WalkingAnimation = WalkingAnimation;
            this.AttackAnimation = AttackAnimation;
        }

        public void Update(GameTime gametime, Player Joueur)
        {
            Mouvement = random.Next(1, 100);
            Position += Speed;
            Rectangle.Location = new Point((int)Position.X - 80, (int)Position.Y - 160);

            if (Joueur != null)
            {
                JoueurDistanceX = (Joueur.Position.X + Joueur.RecPerso.Width / 2) - Position.X;

                if (JoueurDistanceX >= -500 && JoueurDistanceX <= 10)
                {
                    if (Mouvement <= Rapidité)//Avance
                    {
                        Speed.X = -2f;
                        flip = SpriteEffects.FlipHorizontally;
                    }
                    else
                        Speed.X = 0;  //Ne fait rien
                }
                else if (JoueurDistanceX > 15)
                {
                    Speed.X = +2f;//Recule
                    flip = SpriteEffects.None;
                }
                else
                    Speed.X = 0;

                if (Rectangle.Intersects(Joueur.RecPerso))
                {
                    AttackYou = true;
                    if (AnimationPlayer.FrameIndex == 4)
                    {
                        DamageYou = true;
                    }
                    else
                        DamageYou = false;
                }

                else
                {
                    AttackYou = false;
                    DamageYou = false;
                }

                #region Animation Par rapport au deplacement ennemi

                if (AttackYou) AnimationPlayer.PlayAnimation(AttackAnimation);
                else AnimationPlayer.PlayAnimation(WalkingAnimation);


                #endregion
            }
        }

        public void Draw(SpriteBatch g,GameTime gametime)
        {
             AnimationPlayer.Draw(gametime, g, Position, flip);
           // g.Draw(Ressources.Test, Rectangle, Color.Blue);
        }
    }
}
