using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

class cMainMenu : GameScreen
{
    Vector2 PosImageNiv = new Vector2(225, 30);
    AnimationPlayer AnimationPlayer = new AnimationPlayer();
    AnimationPlayer Ap2 = new AnimationPlayer();
    Animation CadreAnim1 = new Animation(RessourceSonic3.CadreAnim, 300, 0.1f, 1, true);
    Animation CadreAnim2 = new Animation(RessourceSonic3.CadreCarre, 266, 0.1f, 1, true);
    Animation Cadre;
    Animation Fleche = new Animation(RessourceSonic3.FlecheSelect, 300, 0.3f, 0.85f, true);
    Vector2 PosCadre = new Vector2(325, 530);
    Vector2 PosFleche = new Vector2(328, 440);
    Texture2D ImageNiveau, ImagePerso, ImagePerso2;
    int NumNiv = 0;
    bool decalement;
    bool StopReading = true;

    public cMainMenu(IServiceProvider serviceProvider, GraphicsDeviceManager graphics)
        : base(serviceProvider, graphics)
    {
        Cadre = CadreAnim1;
        ImagePerso = RessourceSonic3.SonicPresent;
        ImagePerso2 = RessourceSonic3.SonicPresent;
        MediaPlayer.Play(RessourceSonic3.MainMenuSong);
        MediaPlayer.IsRepeating = true;
    }

    public override void Load()
    {

    }

    public override void Update(GameTime gameTime)
    {
        AnimationPlayer.PlayAnimation(Cadre);
        Ap2.PlayAnimation(Fleche);

        if (SaveCheckPoint.Life == 0)
        {
            RemoveScreen(this);
            AddScreen(new cIntro(serviceProvider, GraphicsDeviceManager));
        }

        if (KeyboardHelper.KeyPressed(Keys.Up) || KeyboardHelper.KeyPressed(Keys.Down))
        {
            if (Cadre == CadreAnim1)
            {
                if (ImagePerso == RessourceSonic3.SonicPresent)
                    ImagePerso = RessourceSonic3.TailPresent;
                else
                    ImagePerso = RessourceSonic3.SonicPresent;
            }
            else
            {
                if (ImagePerso2 == RessourceSonic3.SonicPresent)
                    ImagePerso2 = RessourceSonic3.TailPresent;
                else
                    ImagePerso2 = RessourceSonic3.SonicPresent;
            }
        }
        if (KeyboardHelper.KeyPressed(Keys.Left) || KeyboardHelper.KeyPressed(Keys.Right) || decalement)
        {
            if (Cadre == CadreAnim1)
            {
                PosCadre.X -= (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1.5f;
                decalement = true;
                if (PosCadre.X <= 110)
                {
                    PosCadre = new Vector2(110, 271);
                    PosFleche = new Vector2(120, 230);
                    Fleche.Resize = 0.60f;
                    Cadre = CadreAnim2;
                    decalement = false;
                }
            }
            else
            {
                PosCadre.X += (float)gameTime.ElapsedGameTime.TotalMilliseconds / 1.5f;
                decalement = true;
                if (PosCadre.X >= 325)
                {
                    PosCadre = new Vector2(325, 530);
                    PosFleche = new Vector2(328, 440);
                    Fleche.Resize = 0.85f;
                    Cadre = CadreAnim1;
                    decalement = false;
                }
            }
        }
        switch (NumNiv)
        {
            case 0: ImageNiveau = RessourceSonic3.NewGame;
                break;
            case 1: ImageNiveau = RessourceSonic3.Stage1;
                break;
        }

        if (KeyboardHelper.KeyPressed(Keys.Enter) && StopReading == false)
        {
            if (Cadre == CadreAnim2)
                SaveCheckPoint.CheckPointID = 1;

            if (NumNiv == 0 || NumNiv == 1)
            {
                MediaPlayer.Play(RessourceSonic3.AngelIslandAct1Song);

                int Numperso;
                if (Cadre == CadreAnim1)
                {
                    if (ImagePerso == RessourceSonic3.SonicPresent) Numperso = 1;
                    else Numperso = 2;
                }
                else
                {
                    if (ImagePerso2 == RessourceSonic3.SonicPresent) Numperso = 1;
                    else Numperso = 2;
                }

                AddScreen(new cAngelIsland(serviceProvider, GraphicsDeviceManager, Numperso));

                if (Cadre == CadreAnim2)
                    NumNiv = 0;
                else
                    NumNiv = 1;
            }

        }

        StopReading = false;
    }



    public override void Draw(GameTime gametime, SpriteBatch g)
    {
        g.Draw(RessourceSonic3.MainMenuBack, new Rectangle(1, 1, 800, 500), Color.White);
        g.Draw(RessourceSonic3.CadreNoSave, new Rectangle(-20, 20, (int)(RessourceSonic3.CadreNoSave.Width / 1.5), (int)(RessourceSonic3.CadreNoSave.Height / 1.5)), Color.White);
        g.Draw(ImageNiveau, new Rectangle((int)PosImageNiv.X, (int)PosImageNiv.Y, (int)(ImageNiveau.Width / 1.5), (int)(ImageNiveau.Height / 1.5)), Color.White);
        g.Draw(RessourceSonic3.CadreNormal, new Rectangle(200, 5, (int)(RessourceSonic3.CadreNormal.Width / 1.5), (int)(RessourceSonic3.CadreNormal.Height / 1.5)), Color.White);
        AnimationPlayer.Draw(gametime, g, PosCadre, SpriteEffects.None);
        g.Draw(ImagePerso, new Rectangle(225, 210, RessourceSonic3.SonicPresent.Width * 2, RessourceSonic3.SonicPresent.Height * 2), Color.White);
        g.Draw(ImagePerso2, new Rectangle(17, 40, RessourceSonic3.SonicPresent.Width * 2, RessourceSonic3.SonicPresent.Height * 2), Color.White);
        //Ap2.Draw(5,220,(int)(RessourceSonic3.FlecheSelect.Width/1.5),(int)(RessourceSonic3.FlecheSelect.Height/1.5)),Color.White);7
        Ap2.Draw(gametime, g, PosFleche, SpriteEffects.None);
    }
}
