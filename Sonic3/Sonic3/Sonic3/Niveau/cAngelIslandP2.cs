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

namespace Sonic3
{
    class cAngelIslandP2 : GameScreen
    {
        PlayerSonic Joueur;
        HUD Hud;
        int Life = SaveCheckPoint.Life;
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
       
        public cAngelIslandP2(IServiceProvider serviceProvider, GraphicsDeviceManager graphics, int NumPerso)
            : base(serviceProvider, graphics)
        {
            this.NumPerso = NumPerso;
            Hud = new HUD(NumPerso);
            Joueur = new PlayerSonic(false, true, NumPerso);
           
        }

        public override void Load()
        {
            Joueur.Load(Content);
        }

        public override void Update(GameTime gameTime)
        {
            Joueur.Update(gameTime, null, RessourceSonic3.Jump, null, Shield.num);

            
        }

        public override void Draw(GameTime gametime, SpriteBatch g)
        {
            Joueur.Draw(gametime,g);
        }
    }
}
