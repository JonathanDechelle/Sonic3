using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

class SingeArticuler
{
    Texture2D Tete, Bras;
    public Vector2 PositionTete, PositionArbre;
    Vector2 PositionBras;
    float Seconde;
    int NumStep = 0;
    int DistanceStep = 16;
    public BrasArticuler BrasArticuler;
    Rectangle RecArbre, RecPerso;
    public Rectangle RecTete;
    public ObjCollisionable RecCollision;

    public SingeArticuler(Vector2 PositionArbre)
    {
        this.PositionArbre = PositionArbre;
        RecArbre = new Rectangle((int)PositionArbre.X - 70, (int)PositionArbre.Y, RessourceSonic3.ArbreCoconut.Width + 70, RessourceSonic3.ArbreCoconut.Height);
        Tete = RessourceSonic3.TeteSinge;
        Bras = RessourceSonic3.BrasSinge;
        PositionTete = new Vector2(PositionArbre.X + 185, PositionArbre.Y + 162);
        PositionBras = new Vector2(PositionArbre.X + 250, PositionArbre.Y + 209);
        BrasArticuler = new BrasArticuler(PositionTete);
        RecCollision = new ObjCollisionable((int)(this.PositionArbre.X + 100), (int)(this.PositionArbre.Y + 390), 250, 50, Color.White);
    }


    public void Update(GameTime gametime, Rectangle RecPerso)
    {
        this.RecPerso = RecPerso;
        RecTete = new Rectangle((int)PositionTete.X, (int)PositionTete.Y, Tete.Width, Tete.Height);
        Seconde += (float)gametime.ElapsedGameTime.TotalSeconds;
        if (Seconde > 0.4 && Seconde < 0.5)
        {
            PositionTete.Y -= DistanceStep;
            if (NumStep == 3 || NumStep == -1)
                PositionTete.Y += DistanceStep;
            Seconde = 1;
        }
        if (Seconde > 1.2)
        {
            PositionBras.Y -= DistanceStep;
            Seconde = 0;

            if (DistanceStep / (Math.Abs(DistanceStep)) == 1)
                NumStep++;
            else
                NumStep--;
        }

        if (NumStep == 3)
            DistanceStep = -(DistanceStep);
        else if (NumStep == -1)
            DistanceStep = Math.Abs(DistanceStep);

        if (RecArbre.Contains(RecPerso))
        {
            if (BrasArticuler.Noix.Count != 0)
                BrasArticuler.Noix[0].Armed = true;
        }

        BrasArticuler.Update(PositionTete);
    }
    public void Draw(SpriteBatch g)
    {
        // g.Draw(RessourceSonic3.Test, RecArbre, Color.White);
        BrasArticuler.Draw(g);
        g.Draw(Tete, PositionTete, Color.White);
        g.Draw(RessourceSonic3.ArbreCoconut, PositionArbre, Color.White);
        g.Draw(Bras, PositionBras, Color.White);
        // g.Draw(RessourceSonic3.Test, RecPerso, Color.Blue);
        // g.Draw(RessourceSonic3.Test, RecTete, Color.Red);
    }
}

    class BrasArticuler
    { 
        Vector2[] PositionBoule = new Vector2[4];
        Vector2 PositionMain, DistanceDuCentre, Centre;
        double Angle = 3.5, Vitesse = 0.03;
        Random randomAngle;
        float RotationMain=0,AngleMain=0.024f;

        public List<NoixCoco> Noix=new List<NoixCoco>();

        public BrasArticuler(Vector2 PositionSinge)
        {
            Centre = new Vector2 (PositionSinge.X+2,PositionSinge.Y+40);
            DistanceDuCentre = new Vector2(1);
            PositionBoule[0] = new Vector2(Centre.X, Centre.Y);
            PositionBoule[1] = new Vector2(PositionBoule[0].X - 20, PositionBoule[0].Y);
            PositionBoule[2] = new Vector2(PositionBoule[1].X - 20, PositionBoule[0].Y);
            PositionBoule[3] = new Vector2(PositionBoule[2].X - 20, PositionBoule[0].Y);
            PositionMain = new Vector2(PositionBoule[3].X - 20, PositionBoule[0].Y);
            Noix.Add(new NoixCoco(PositionMain));
            randomAngle = new Random();
        }

        public void Update(Vector2 PositionSinge)
        {
            Angle += Vitesse;
            RotationMain -= AngleMain;

            if (Noix.Count != 0)
            {
                if (Noix[0].Armed)
                    Noix[0].Update(ref Noix[0].Position);
                else
                    Noix[0].Update(ref PositionMain);
            }
          
            if (RotationMain < -1.5)
                RotationMain = -1.5f;
            else if (RotationMain > 0)
                RotationMain = 0;
          
            if (Angle > 4.5)
            {
                Vitesse = -Vitesse;
                AngleMain = Math.Abs(AngleMain);
            }
            else if (Angle < 2.5)
            {
                Vitesse = Math.Abs(Vitesse);
                AngleMain = -AngleMain;
            }

            Centre = new Vector2(PositionSinge.X+2, PositionSinge.Y + 40);
            for (int B = 0; B < PositionBoule.Length; B++)
            {
                PositionBoule[B].X = (float)(DistanceDuCentre.X * Math.Cos(Angle) - DistanceDuCentre.Y * Math.Sin(Angle));
                PositionBoule[B].Y = (float)(DistanceDuCentre.X * Math.Sin(Angle) + DistanceDuCentre.Y * Math.Cos(Angle));
                PositionBoule[B] += Centre;
                DistanceDuCentre.X += 17;
            }

            PositionMain.X = (float)(DistanceDuCentre.X * Math.Cos(Angle) - DistanceDuCentre.Y * Math.Sin(Angle));
            PositionMain.Y = (float)(DistanceDuCentre.X * Math.Sin(Angle) + DistanceDuCentre.Y * Math.Cos(Angle));
            PositionMain += Centre;
            DistanceDuCentre.X -= 68;
        }

        public void Draw(SpriteBatch g)
        {
            foreach (Vector2 B in PositionBoule)
                g.Draw(RessourceSonic3.BouleBrasArti, B, Color.White);

            g.Draw(RessourceSonic3.MainSingeArticu, new Vector2(PositionMain.X+15,PositionMain.Y+15),null,Color.White,RotationMain,new Vector2(15,15),1,SpriteEffects.None,0);
            foreach (NoixCoco n in Noix)
            {
                n.Draw(g);
            }
        }
    }

    class NoixCoco
    {
        Texture2D NoixNormal, NoixArmed;
        public Vector2 Position;
        public Rectangle RecNoix;
        public bool Armed;

        public NoixCoco(Vector2 Position)
        {
            this.Position = Position;
            NoixNormal = RessourceSonic3.NoixCoco;
            NoixArmed = RessourceSonic3.NoixArmed;
            RecNoix = new Rectangle((int)Position.X, (int)Position.Y, NoixNormal.Width, NoixNormal.Height);
        }


        public void Update(ref Vector2 Position)
        {
            this.Position = Position;
            RecNoix = new Rectangle((int)Position.X, (int)Position.Y, NoixNormal.Width, NoixNormal.Height);

            if (Armed)
            {
                Position.X -= 0.5f;
                Position.Y += 3f;
            }



        }

        public void Draw(SpriteBatch g)
        {
            if (Armed)
                g.Draw(NoixArmed, Position, Color.White);
            else
                g.Draw(NoixNormal, Position, Color.White);

            //g.Draw(RessourceSonic3.Test, RecNoix, Color.Yellow);
        }
    }
