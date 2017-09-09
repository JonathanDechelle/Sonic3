using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class BackGroundTexture
{
    Texture2D Texture;
    Vector2 Position;

    public BackGroundTexture(int Numtext, Vector2 Position)
    {
        switch (Numtext)
        {
            case 0: Texture = RessourceSonic3.Ecorce;
                break;
            case 1: Texture = RessourceSonic3.Ecorce2;
                break;
            case 2: Texture = RessourceSonic3.Feuillage1;
                break;
            case 3: Texture = RessourceSonic3.Feuillage2;
                break;
            case 4: Texture = RessourceSonic3.Arriere3;
                break;
        }

        this.Position = Position;
    }

    public void Draw(SpriteBatch g)
    {
        g.Draw(Texture, Position, Color.White);
    }
}
