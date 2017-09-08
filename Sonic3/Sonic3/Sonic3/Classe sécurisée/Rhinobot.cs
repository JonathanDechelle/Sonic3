using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sonic3
{
    class Rhinobot
    {
        Texture2D Texture;
        public Vector2 Position,PositionInit;
 
        public Rectangle RecRhino,RecPerso;
        float DisParcours, DisParcouruX = 0;
        SpriteEffects flip = SpriteEffects.None;
        public bool Touched, Destroy,PerteRingOneCheck;
        bool OnlyOnce;
      
       
        public Rhinobot(Vector2 Position, int DisParcours)
        {
            Texture = RessourceSonic3.RhinobotMove;
            this.Position = Position;
            PositionInit = Position;
            this.DisParcours = -DisParcours;
            RecRhino = new Rectangle((int)this.Position.X+10, (int)this.Position.Y + 25, (int)(Texture.Width/1.2), Texture.Height);
        }

        
        public void Update(GameTime gametime, PlayerSonic Joueur,ref int RingsPosses,ref int Life,ref Shield Shield)
        {
            this.RecPerso = new Rectangle((int)Joueur.RecPerso.X,(int)Joueur.RecPerso.Y,(int)(Joueur.RecPerso.Width/2.5),Joueur.RecPerso.Height);

            Position = new Vector2();
            Position = PositionInit;
            Position.X += DisParcouruX;

            RecRhino.Location = new Point((int)Position.X+10, (int)Position.Y+ 25);
            
            #region Si rhino fonce dans sonic
            if (RecRhino.Intersects(Joueur.RecPerso))
            {
                Touched=true;
                #region Si sonic saute sur rhino
                if ((Joueur.HasJump || Joueur.EnBoule)  && !Joueur.Injure)
                {
                    if (!OnlyOnce)
                    {
                        Destroy = true;
                        RessourceSonic3.EnnemiItem.Play();
                        OnlyOnce = true;
                        if(Joueur.Speed.Y>-6)
                        Joueur.Speed.Y =- 6f;
                    }
                }
                #endregion
            }
            else
                PerteRingOneCheck = false;
            #endregion

            #region Si sonic est dans le champ de vision
            if (RecPerso.X > RecRhino.X - 240 && RecPerso.X < RecRhino.X + 250 && flip == SpriteEffects.None)
            {
                DisParcouruX -= 5;
                Texture = RessourceSonic3.RhinobotMove;

                if (DisParcouruX + 500 < DisParcours)
                {
                    flip = SpriteEffects.FlipHorizontally;
                }
            }

            else if (RecPerso.X < RecRhino.X + 240 && RecPerso.X > RecRhino.X - 250 && flip == SpriteEffects.FlipHorizontally)
            {
                DisParcouruX += 5;
                Texture = RessourceSonic3.RhinobotMove;

                if (DisParcouruX - 500 > DisParcours)
                {
                    flip = SpriteEffects.None;
                }
            }
            #endregion
            #region Sinon si il ne l'est pas
            else
            {

                if (DisParcouruX >= DisParcours * 0.08 || DisParcouruX <= DisParcours * 0.92)
                {
                    if (DisParcouruX >= DisParcours * 0 || DisParcouruX <= DisParcours * 1.20)
                        Texture = RessourceSonic3.RhinobotMove;

                    else
                        Texture = RessourceSonic3.RhinoReturn1;
                }
                else
                {
                    Texture = RessourceSonic3.RhinobotMove;
                }

                if (flip == SpriteEffects.None && DisParcouruX >= DisParcours)
                {
                    DisParcouruX -= 1.5f;
                }
                else
                {
                    flip = SpriteEffects.FlipHorizontally;
                    DisParcouruX += 1.5f;
                    if (DisParcouruX >= 0)
                        flip = SpriteEffects.None;
                }
            }
            #endregion

            
          
        }
        public void Draw(SpriteBatch g,GameTime gametime)
        {
          // g.Draw(RessourceSonic3.Test, RecRhino, Color.Red);
            //g.Draw(RessourceSonic3.Test, RecPerso, Color.Blue);

                g.Draw(Texture, Position, null, Color.White, 0f, new Vector2(), 1, flip, 0);
           
            
           // g.Draw(RessourceSonic3.Test, Position, Color.White);
           
        }

    }
}
