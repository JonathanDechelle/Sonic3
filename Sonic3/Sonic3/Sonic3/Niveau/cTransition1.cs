using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

class cTransition1 : GameScreen
{
    Parallax Parallax;
    float Compteur;
    bool fin;
    int NumPerso;

    public cTransition1(IServiceProvider serviceProvider, GraphicsDeviceManager graphics, int NumPerso)
        : base(serviceProvider, graphics)
    {
        Parallax = new Parallax(RessourceSonic3.BackAct2Front, RessourceSonic3.BackAct2, new Vector2(400, 250));
        this.NumPerso = NumPerso;
    }

    public override void Load()
    {

    }

    public override void Update(GameTime gameTime)
    {

        if (Compteur <= 3 && !fin)
        {
            Parallax.Update();
            Compteur += (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        else if (!fin)
        {
            fin = true;
            Compteur = 0;
            MediaPlayer.Play(RessourceSonic3.AngelIslandAct2Song);
            MediaPlayer.IsRepeating = true;
        }
        else
        {
            Compteur += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (Compteur >= 2)
            {
                //AddScreen(new cTest(serviceProvider, GraphicsDeviceManager,NumPerso));
                //RemoveScreen(this);
            }
        }
    }

    public override void Draw(GameTime gametime, SpriteBatch g)
    {
        Parallax.Draw(g);
        if (fin) g.Draw(RessourceSonic3.Act2Signe, new Vector2(250, 100), Color.White);
    }
}