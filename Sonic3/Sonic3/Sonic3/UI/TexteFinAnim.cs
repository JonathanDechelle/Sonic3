using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class TexteFinAnim
{
    Texture2D PersoText, FinishedText, Niveau;
    Vector2 PosPerso, PosFinished, PosNiveau;//PositionFinale
    Vector2 PosPersoInit, PosFinishedInit, PosNiveauInit;//positionInitiale

    float CompteurDelete;
    public bool Delete = false;

    public TexteFinAnim(bool Sonic, Vector2 Position, int Niveau)
    {

        //image 
        if (Sonic) PersoText = RessourceSonic3.SonicText;
        else PersoText = RessourceSonic3.TailText;

        FinishedText = RessourceSonic3.PassedText;

        switch (Niveau)
        {
            case 1: this.Niveau = RessourceSonic3.Act1Text;
                break;
        }

        //position Finale
        PosPerso = Position;
        PosFinished = new Vector2(Position.X - 25, Position.Y + 60);
        PosNiveau = new Vector2(Position.X + 35, Position.Y + 130);

        //position Initiale
        PosPersoInit = new Vector2(PosPerso.X + 150, PosPerso.Y);
        PosFinishedInit = new Vector2(PosFinished.X - 150, PosFinished.Y);
        PosNiveauInit = new Vector2(PosNiveau.X, PosNiveau.Y + 150);

    }

    public void Update(GameTime gametime)
    {
        if (PosPersoInit.X > PosPerso.X)
        {
            PosPersoInit.X -= 2;
            PosFinishedInit.X += 2;
            PosNiveauInit.Y -= 2;
        }
        else
        {
            CompteurDelete += (float)gametime.ElapsedGameTime.TotalSeconds;
            if (CompteurDelete > 4) Delete = true;
        }

    }

    public void Draw(SpriteBatch g)
    {
        g.Draw(PersoText, PosPersoInit, Color.White);
        g.Draw(FinishedText, PosFinishedInit, Color.White);
        g.Draw(Niveau, PosNiveauInit, Color.White);
    }
}
