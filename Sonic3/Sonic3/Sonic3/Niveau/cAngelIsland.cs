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

class cAngelIsland : GameScreen
{
    Camera camera;
    PlayerSonic Joueur;
    HUD Hud;
    Animation Death;
    AnimationPlayer AnimationPlayer = new AnimationPlayer(), APDead = new AnimationPlayer();
    Vector2 PosBack, PosHUD, PosAnimationPlayer, APDeadpos, APDeadPosInit;
    int RingsPosses = 0;
    int Life = SaveCheckPoint.Life;
    int MapLimitY = 1500;
    int NumAnimal = 0;
    int NumPerso;
    List<ObjCollisionable> Obj = new List<ObjCollisionable>();
    List<ObjectMapping> TexturesObject = new List<ObjectMapping>();
    List<Tremplin> Tremplins = new List<Tremplin>();
    List<Ring> Rings = new List<Ring>();
    List<Pic> Pics = new List<Pic>();
    List<Checkpoint> CheckPoints = new List<Checkpoint>();
    List<Rhinobot> Rhinobots = new List<Rhinobot>();
    List<SingeArticuler> Singes = new List<SingeArticuler>();
    List<Tele> Teles = new List<Tele>();
    List<Loop> Loops = new List<Loop>();
    List<Pente> Pentes = new List<Pente>();
    List<FireBreath> MiniBoss = new List<FireBreath>();
    List<Flag> Flags = new List<Flag>();
    List<TexteFinAnim> TexteFin = new List<TexteFinAnim>();
    List<Menu> Menus = new List<Menu>();
    List<BackGroundTexture> BackTextures = new List<BackGroundTexture>();
    Shield Shield = new Shield();
    Random RringsY = new Random();
    Random RringsX = new Random();
    Random RAnimal = new Random();
    bool AnimalActif, FinNiveau;
    Rectangle RecUpdate;

    public cAngelIsland(IServiceProvider serviceProvider, GraphicsDeviceManager graphics, int NumPerso)
        : base(serviceProvider, graphics)
    {
        this.NumPerso = NumPerso;
        Hud = new HUD(NumPerso);
        camera = new Camera(graphics.GraphicsDevice.Viewport);
        CheckPoints.Add(new Checkpoint(new Vector2(100, 360), 1));
        CheckPoints.Add(new Checkpoint(new Vector2(2200, 360), 2));
        CheckPoints.Add(new Checkpoint(new Vector2(4500, 650), 3));
        CheckPoints.Add(new Checkpoint(new Vector2(5500, 650), 4));


        Joueur = new PlayerSonic(false, true, NumPerso);
        Joueur.Position = GestionExterne.LoadingPosition(CheckPoints, this);


        TexturesObject.Add(new ObjectMapping(1, new Vector2(-130, 230)));
        TexturesObject.Add(new ObjectMapping(2, new Vector2(120, 230)));
        TexturesObject.Add(new ObjectMapping(3, new Vector2(320, 220)));
        TexturesObject.Add(new ObjectMapping(3, new Vector2(780, 220)));
        TexturesObject.Add(new ObjectMapping(2, new Vector2(1260, 230)));
        TexturesObject.Add(new ObjectMapping(2, new Vector2(850, -130)));
        BackTextures.Add(new BackGroundTexture(1, new Vector2(-350, -540)));
        BackTextures.Add(new BackGroundTexture(2, new Vector2(150, -520)));
        BackTextures.Add(new BackGroundTexture(3, new Vector2(880, -520)));
        BackTextures.Add(new BackGroundTexture(2, new Vector2(1560, -520)));
        BackTextures.Add(new BackGroundTexture(1, new Vector2(2400, -900)));
        BackTextures.Add(new BackGroundTexture(1, new Vector2(2100, -700)));
        BackTextures.Add(new BackGroundTexture(4, new Vector2(2600, -1250)));
        BackTextures.Add(new BackGroundTexture(3, new Vector2(3700, -850)));
        BackTextures.Add(new BackGroundTexture(2, new Vector2(5000, -850)));
        BackTextures.Add(new BackGroundTexture(1, new Vector2(6000, -500)));
        BackTextures.Add(new BackGroundTexture(0, new Vector2(6600, -500)));
        BackTextures.Add(new BackGroundTexture(1, new Vector2(6900, -500)));

        Teles.Add(new Tele(1, new Vector2(920, -10), NumPerso));
        Rhinobots.Add(new Rhinobot(new Vector2(700, 350), 300));
        Tremplins.Add(new Tremplin(new Vector2(1300, 350), false, false));
        Tremplins.Add(new Tremplin(new Vector2(1300, 50), false, true));
        Tremplins.Add(new Tremplin(new Vector2(1650, 50), false, true));
        Rings.Add(new Ring(new Vector2(400, 350)));
        Rings.Add(new Ring(new Vector2(500, 350)));
        Rings.Add(new Ring(new Vector2(600, 350)));
        Rings.Add(new Ring(new Vector2(700, 350)));
        Rings.Add(new Ring(new Vector2(800, 350)));
        Rings.Add(new Ring(new Vector2(1450, 375)));
        Rings.Add(new Ring(new Vector2(1550, 320)));
        Rings.Add(new Ring(new Vector2(1850, 320)));
        Rings.Add(new Ring(new Vector2(1950, 375)));
        // -------------
        Rings.Add(new Ring(new Vector2(1680, 480)));
        Rings.Add(new Ring(new Vector2(1680, 600)));
        Rings.Add(new Ring(new Vector2(1680, 720)));
        Rings.Add(new Ring(new Vector2(1680, 840)));
        //----------------------------------------------------------
        TexturesObject.Add(new ObjectMapping(1, new Vector2(1800, 220)));
        TexturesObject.Add(new ObjectMapping(2, new Vector2(2000, 220)));
        TexturesObject.Add(new ObjectMapping(2, new Vector2(2200, 220)));
        TexturesObject.Add(new ObjectMapping(3, new Vector2(2400, 220)));
        Pics.Add(new Pic(new Vector2(2500, 360), false));
        Pics.Add(new Pic(new Vector2(2600, 360), false));
        Pics.Add(new Pic(new Vector2(2700, 360), false));
        Tremplins.Add(new Tremplin(new Vector2(2850, 340), false, false));
        Rings.Add(new Ring(new Vector2(2900, 300)));
        Rings.Add(new Ring(new Vector2(2900, 250)));
        Rings.Add(new Ring(new Vector2(2900, 200)));
        //-------------------------------------------------------------
        TexturesObject.Add(new ObjectMapping(3, new Vector2(3050, -200)));
        Tremplins.Add(new Tremplin(new Vector2(3000, 100), false, false));
        Rings.Add(new Ring(new Vector2(3050, 50)));
        Rings.Add(new Ring(new Vector2(3050, 0)));
        Rings.Add(new Ring(new Vector2(3050, -50)));
        Teles.Add(new Tele(2, new Vector2(3250, -70), NumPerso));
        Pentes.Add(new Pente(1, new Vector2(3555, -10), false));
        TexturesObject.Add(new ObjectMapping(3, new Vector2(4500, -10)));
        Teles.Add(new Tele(3, new Vector2(4650, 100), NumPerso));
        Tremplins.Add(new Tremplin(new Vector2(4800, 100), true, true));
        Tremplins.Add(new Tremplin(new Vector2(5300, 100), false, true));
        //-----------------------------------------------------------
        TexturesObject.Add(new ObjectMapping(2, new Vector2(1600, 620)));
        TexturesObject.Add(new ObjectMapping(3, new Vector2(1800, 620)));
        TexturesObject.Add(new ObjectMapping(2, new Vector2(2000, 620)));
        TexturesObject.Add(new ObjectMapping(1, new Vector2(2200, 620)));
        TexturesObject.Add(new ObjectMapping(2, new Vector2(2400, 620)));
        TexturesObject.Add(new ObjectMapping(3, new Vector2(2600, 620)));
        Tremplins.Add(new Tremplin(new Vector2(2000, 720), true, true));
        Rings.Add(new Ring(new Vector2(2550, 710)));
        Rings.Add(new Ring(new Vector2(2600, 710)));
        Rings.Add(new Ring(new Vector2(2650, 710)));
        Rings.Add(new Ring(new Vector2(2700, 710)));
        Pics.Add(new Pic(new Vector2(2500, 750), false));
        Pics.Add(new Pic(new Vector2(2600, 750), false));
        Pentes.Add(new Pente(1, new Vector2(3110, 590), true));
        Rings.Add(new Ring(new Vector2(3750, 650)));
        Rings.Add(new Ring(new Vector2(3800, 650)));
        Rings.Add(new Ring(new Vector2(3850, 650)));
        Rings.Add(new Ring(new Vector2(3900, 650)));
        //-------------------------------------------------------------------
        TexturesObject.Add(new ObjectMapping(2, new Vector2(4000, 510)));
        TexturesObject.Add(new ObjectMapping(1, new Vector2(4200, 510)));
        TexturesObject.Add(new ObjectMapping(3, new Vector2(4400, 510)));
        Teles.Add(new Tele(2, new Vector2(4400, 650), NumPerso));
        Rhinobots.Add(new Rhinobot(new Vector2(4600, 650), 100));
        Pics.Add(new Pic(new Vector2(4700, 650), false));
        Pics.Add(new Pic(new Vector2(4800, 650), false));
        //-------------------------------------------------------------------
        Pentes.Add(new Pente(1, new Vector2(5000, 700), true));
        TexturesObject.Add(new ObjectMapping(1, new Vector2(5520, 520)));
        TexturesObject.Add(new ObjectMapping(2, new Vector2(5720, 520)));
        TexturesObject.Add(new ObjectMapping(2, new Vector2(5920, 520)));
        Pics.Add(new Pic(new Vector2(5750, 680), false));
        Pics.Add(new Pic(new Vector2(5850, 680), false));
        Singes.Add(new SingeArticuler(new Vector2(5920, 340)));
        Pentes.Add(new Pente(1, new Vector2(6245, 465), true));
        //----------------------------------------------------------------------
        TexturesObject.Add(new ObjectMapping(2, new Vector2(6775, 290)));
        Teles.Add(new Tele(1, new Vector2(6800, 410), NumPerso));
        Pentes.Add(new Pente(1, new Vector2(7000, 470), false));
        //----------------------------------------------------------------------<
        TexturesObject.Add(new ObjectMapping(3, new Vector2(7510, 500)));
        TexturesObject.Add(new ObjectMapping(3, new Vector2(7610, 500)));
        TexturesObject.Add(new ObjectMapping(3, new Vector2(7900, 500)));
        TexturesObject.Add(new ObjectMapping(2, new Vector2(8000, 500)));
        TexturesObject.Add(new ObjectMapping(2, new Vector2(8100, 500)));
        TexturesObject.Add(new ObjectMapping(3, new Vector2(8200, 500)));
        MiniBoss.Add(new FireBreath(new Vector2(8300, 250)));
        //------------------------------------------------------------------
    }

    public override void Load()
    {
        Joueur.Load(Content);
        Death = Joueur.Death;

        CollisionLoading.Load(TexturesObject, Singes, Loops, Pentes, Obj);
    }

    public override void Update(GameTime gameTime)
    {
        RecUpdate = new Rectangle((int)camera.X - 400, (int)camera.Y - 249, 800, 600);


        GestionExterne.CameraControl(camera);
        GestionExterne.Menu(Menus, Joueur, camera, this);

        #region Gestion De la sauvegarde de la vie
        if (Life < SaveCheckPoint.Life)
            Mort();
        else
            SaveCheckPoint.Life = Life;
        #endregion

        if (Joueur != null && !Joueur.Enabled)
        {
            //Sortie de MAP
            if (Joueur.Position.Y > MapLimitY)
                Life--;

            //Pics
            GestionExterne.UpdatePics(Pics, RecUpdate, Joueur, ref RingsPosses, ref Rings, ref Life, ref Shield);

            // Apparition des animaux
            CodeExclusifSonic.Animal(AnimalActif, NumAnimal, RAnimal, ref AnimationPlayer, ref PosAnimationPlayer, camera);

            //RhinoBots
            GestionExterne.UpdateRhino(ref Rhinobots, RecUpdate, gameTime, Joueur, ref RingsPosses, ref Life, ref Shield, ref PosAnimationPlayer
                                       , ref AnimalActif, ref AnimationPlayer, ref Rings, RringsX, RringsY);

            //Singes
            GestionExterne.UpdateSinge(ref Singes, RecUpdate, gameTime, Joueur, ref RingsPosses, ref Life, ref Shield, ref PosAnimationPlayer,
                                     ref AnimalActif, ref AnimationPlayer, ref Rings, RringsX, RringsY, ref TexturesObject);


            Joueur.Update(gameTime, Obj, null, null, Shield.num);

            #region Contrainte de boss
            if (Joueur.Position.X > 8000 && MiniBoss.Count == 1 && !camera.Locked)
            { camera.Locked = true; MediaPlayer.Play(RessourceSonic3.MinorBoss); }
            #endregion
            #region Camera Update
            if (Joueur.Position.X < 90)
            {
                //si PosX <90 camera X bloque mais continue d'updater en Y
                camera.Update(new Vector2(289, Joueur.Position.Y - 200));

                //Si est a la limite de la map en X perso bloque
                if (Joueur.Position.X < -40)
                    Joueur.Position.X = -40;
            }

            else if (!camera.Locked)
            {
                camera.Update(new Vector2(Joueur.Position.X + 200, Joueur.Position.Y - 200));
            }
            else
            {
                //Ajustement de la camera pour l'entrée premier Boss
                if (camera.X < 8199)
                    camera.X += 2;

                else //Lorsque L'Ajustement est fini camera rentre en mode fixe
                    camera.Update(new Vector2(8199, 544));

                //Limite du personnage losque la caméra est blocké
                if (Joueur.Position.X > camera.X + 350) Joueur.Position.X = camera.X + 350;
                if (Joueur.Position.X < camera.X - 350) Joueur.Position.X = camera.X - 350;
            }
            #endregion

            Shield.Update(Joueur.Position, Joueur.Rebound);

            #region MiniBoss
            for (int m = MiniBoss.Count - 1; m >= 0; m--)
            {
                if (MiniBoss[m].RecMiniBoss.Intersects(RecUpdate))
                    MiniBoss[m].Update(gameTime, Joueur, ref RingsPosses, ref Life, ref Rings, RringsY, RringsX, ref Shield);
                if (MiniBoss[m].Finish)
                {
                    Flags.Add(new Flag(new Vector2(camera.X, MiniBoss[m].Position.Y - 200), NumPerso));
                    if (!Joueur.HasJump) Flags[0].PosYMinimum = Joueur.Position.Y - 30;
                    else Flags[0].PosYMinimum = Joueur.Position.Y + 27;
                    MiniBoss.RemoveAt(m);
                }
            }
            #endregion

            //Loops
            GestionExterne.UpdateLoop(Loops, RecUpdate, ref Joueur);

            //Pente
            GestionExterne.UpdatePente(Pentes, RecUpdate, ref Joueur);

            //CheckPoint
            GestionExterne.UpdateCheckPoint(CheckPoints, RecUpdate, Joueur);

            //Tremplin
            GestionExterne.UpdateTremplin(Tremplins, RecUpdate, Joueur);

            //Tele
            GestionExterne.UpdateTele(ref Teles, RecUpdate, gameTime, Joueur, ref Life, ref RingsPosses, ref Shield);

            //Rings
            GestionExterne.UpdateRing(ref RingsPosses, ref Life, RecUpdate, ref Rings, Joueur, gameTime);

            #region Update Back et HUD
            PosBack = new Vector2(camera.X - 400, camera.Y - 250);
            PosHUD = new Vector2(PosBack.X + 450, PosBack.Y + 250);
            Hud.Update(RingsPosses, Life, PosHUD);
            #endregion
        }
        else //Gestion de la mort
            GestionExterne.AnimationMort(Menus, FinNiveau, ref APDead, Death, ref APDeadpos, APDeadPosInit, this);


        #region Flags
        for (int F = Flags.Count - 1; F >= 0; F--)
        {
            Flags[F].Update(gameTime, Joueur);
            if (Flags[F].Texte)
            {
                if (NumPerso == 1)
                    TexteFin.Add(new TexteFinAnim(true, new Vector2(8100, 380), 1));
                else
                    TexteFin.Add(new TexteFinAnim(false, new Vector2(8100, 380), 1));
                Flags[F].Texte = false;
                MediaPlayer.IsRepeating = false;
                MediaPlayer.Play(RessourceSonic3.LevelComplete);
                Joueur.Enabled = true;
                FinNiveau = true;
            }
            if (Flags[F].Stop)
            {
                TexteFin[0].Update(gameTime);

                if (TexteFin[0].Delete)
                {
                    Flags.RemoveAt(F);
                    TexteFin.RemoveAt(0);
                    Joueur.Enabled = false;
                    FinNiveau = false;
                    camera.Locked = false;
                    AddScreen(new cTransition1(serviceProvider, GraphicsDeviceManager, NumPerso));
                    RemoveScreen(this);
                }
            }
        }
        #endregion
    }


    public override void Draw(GameTime gametime, SpriteBatch g)
    {
        g.End();
        g.Begin(SpriteSortMode.Deferred, null, SamplerState.PointWrap, null, null, null, camera.Transform);

        g.Draw(RessourceSonic3.CompleteBack, PosBack, Color.White);


        DessinOBJECT.AvantPlanDraw(g, gametime, Pics, TexturesObject, CheckPoints, Flags, Loops, MiniBoss,
                                    Pentes, Tremplins, Teles, Singes, Rings, Rhinobots);

        if (Joueur != null) Joueur.Draw(gametime, g);
        else APDead.Draw(gametime, g, APDeadpos, SpriteEffects.None);

        DessinOBJECT.ArrierePlanDraw(g, gametime, Shield, BackTextures, Hud, TexteFin, Menus);

        AnimationPlayer.Draw(gametime, g, PosAnimationPlayer, SpriteEffects.None);
    }

    public void Mort()
    {
        SaveCheckPoint.Life = Life;
        APDeadpos = Joueur.Position;
        APDeadpos.Y -= 500;
        APDeadpos.X += 80;
        APDeadPosInit = APDeadpos;
        Joueur = null;
    }
}
