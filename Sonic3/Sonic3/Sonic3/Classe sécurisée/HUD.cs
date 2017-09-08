using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Sonic3
{
    class HUD
    {
        Texture2D[] TabRings = new Texture2D[10];
        Texture2D TextureLife;
        Vector2 PosDiz, PosUnite,PosLifeDesc,PosLife;
        int DizaineAffiche, UniteAffiche,LifeUnit,LifeDiz;
        Color colorRing = new Color(255, 255, 255, 255);
        

        public HUD(int NumPerso)
        {
            TabRings[0] = RessourceSonic3.Ring0;
            TabRings[1] = RessourceSonic3.Ring1;
            TabRings[2] = RessourceSonic3.Ring2;
            TabRings[3] = RessourceSonic3.Ring3;
            TabRings[4] = RessourceSonic3.Ring4;
            TabRings[5] = RessourceSonic3.Ring5;
            TabRings[6] = RessourceSonic3.Ring6;
            TabRings[7] = RessourceSonic3.Ring7;
            TabRings[8] = RessourceSonic3.Ring8;
            TabRings[9] = RessourceSonic3.Ring9;

            if (NumPerso == 1)
                TextureLife = RessourceSonic3.SonicLife;
            else
                TextureLife = RessourceSonic3.TailLife;
        }

        public void Update(int NbRings,int Life,Vector2 Position)
        {
            //Rings 
            DizaineAffiche = NbRings / 10;
            if (NbRings > 10)
                NbRings-=DizaineAffiche*10;

            UniteAffiche = NbRings /1;
            if (UniteAffiche == 10)
                UniteAffiche = 0;
            //-------------------------

            //Life
            LifeDiz = Life / 10;
            if (Life > 10)
                Life -= LifeDiz*10;

            LifeUnit = Life / 1;
            if (LifeUnit == 10)
                LifeUnit = 0;
           
            //-------------------------

            if (UniteAffiche == 0 && DizaineAffiche == 0)
            {
                colorRing.A -= 15;
                colorRing.B -= 15;
                colorRing.G -= 15;
                colorRing.R -= 15;
            }
            else
                colorRing = Color.White;

            PosUnite = new Vector2(Position.X - 320,(float)(Position.Y - 234.95));
            PosDiz = new Vector2(Position.X - 340, Position.Y - 235);
            PosLifeDesc = new Vector2(Position.X - 450, Position.Y + 160);
            PosLife = new Vector2(Position.X - 360, Position.Y + 196);
        }

        public void Draw(SpriteBatch g)
        {
           
            //Ring
            if (DizaineAffiche != 0)
            {
                if (DizaineAffiche == 10) DizaineAffiche = 0;

                g.Draw(TabRings[DizaineAffiche], PosDiz, Color.White);
                g.Draw(TabRings[UniteAffiche], PosUnite, Color.White);
            }
            else
                g.Draw(TabRings[UniteAffiche], PosDiz, Color.White);
            //----------------

            //Life
            if (LifeDiz != 0)
            {
                g.Draw(TabRings[LifeDiz], PosLife, Color.White);
                g.Draw(TabRings[LifeUnit], new Vector2(PosLife.X + 10, PosLife.Y), Color.White);
            }
            else
            {
                if (LifeUnit == -1) LifeUnit = 0;
                g.Draw(TabRings[LifeUnit], PosLife, Color.White);
            }

            g.Draw(RessourceSonic3.RingTexte, new Vector2(PosDiz.X - 80, PosDiz.Y-10), colorRing);
            g.Draw(TextureLife, PosLifeDesc, Color.White);
            //g.Draw(TabRings[LifeUnit],PosLife, Color.White);
            
        }

    }
}
