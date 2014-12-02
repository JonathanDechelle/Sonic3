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
using MyGameLibrairy;



namespace Sonic3
{

    class cTest : GameScreen
    {
        Camera camera;
        Vector2 PosBack;
        PlayerSonic Joueur;
        List<ObjCollisionable> obj = new List<ObjCollisionable>();
        List<ObjectMapping> textureObjet = new List<ObjectMapping>();
        List<Pente> Pentes = new List<Pente>();
        Animation FireAnim = new Animation(RessourceSonic3.FireAnim, 75, 0.5f, 2, true);
        AnimationPlayer Ap = new AnimationPlayer();

        public cTest(IServiceProvider serviceProvider, GraphicsDeviceManager graphics,int NumPerso)
            : base(serviceProvider, graphics)
        {
            camera = new Camera(graphics.GraphicsDevice.Viewport);
            Joueur = new PlayerSonic(false, true, NumPerso);
            Joueur.Position = new Vector2(400, 500);

            textureObjet.Add(new ObjectMapping(5, new Vector2(300, 300)));
            Pentes.Add(new Pente(2, new Vector2(815, 340), false));
            textureObjet.Add(new ObjectMapping(5,new Vector2(1060,170)));
        }

        public override void Load()
        {
            Joueur.Load(Content);
            CollisionLoading.Load(textureObjet, null, null, Pentes, obj);
        }

        public override void Update(GameTime gameTime)
        {
            Ap.PlayAnimation(FireAnim);

            Joueur.Update(gameTime,obj, null, null, 0);

            camera.Update(new Vector2(Joueur.Position.X + 200, Joueur.Position.Y - 200));
            PosBack = new Vector2(camera.X - 400, camera.Y - 250);

            GestionExterne.CameraControl(camera);

            foreach (Pente P in Pentes)
                P.Update(Joueur);
               

        }



        public override void Draw(GameTime gametime, SpriteBatch g)
        {
            g.End();
            g.Begin(SpriteSortMode.Deferred, null, SamplerState.PointWrap, null, null, null, camera.Transform);

            g.Draw(RessourceSonic3.BackComplete2, PosBack, Color.White);

            Ap.Draw(gametime, g, new Vector2(PosBack.X+85, PosBack.Y+175), SpriteEffects.None,0.20f);
            Ap.Draw(gametime, g, new Vector2(PosBack.X + 275, PosBack.Y + 370), SpriteEffects.None, 0.20f);
            Ap.Draw(gametime, g, new Vector2(PosBack.X + 465, PosBack.Y + 245), SpriteEffects.None, -0.20f);
            Ap.Draw(gametime, g, new Vector2(PosBack.X + 650, PosBack.Y + 305), SpriteEffects.None, -0.20f);
            Ap.Draw(gametime, g, new Vector2(PosBack.X + 720, PosBack.Y + 370), SpriteEffects.None, -0.20f);
         

           // g.Draw(RessourceSonic3.Obs4, new Vector2(300, 260), Color.White);
            foreach (ObjectMapping O in textureObjet)
               O.Draw(g);
            

            foreach (Pente P in Pentes)
                P.Draw(g);

            Joueur.Draw(gametime, g);
        }
    }

}
