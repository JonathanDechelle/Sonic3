using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sonic3
{
    public static class CodeExclusifSonic
    {

        public static void PerteRing(ref int RingsPosses,ref int Life, ref PlayerSonic Joueur, ref List<Ring> Rings, Random RringsY, Random RringsX, ref Shield Shield)
        {
            if (Shield.num == 0)
            {
                if (RingsPosses != 0)
                    RessourceSonic3.LostRing.Play();
                else
                {
                    Life--;
                    RessourceSonic3.Hurt.Play();
                }

                if (RingsPosses > 10)
                    RingsPosses = 10;

                for (int i = RingsPosses - 1; i >= 0; i--)
                {
                    Rings.Add(new Ring(new Vector2(Joueur.Position.X, Joueur.Position.Y - 205)));
                    Rings[Rings.Count - 1].Speed.Y = RringsY.Next(-6, -3);
                    Rings[Rings.Count - 1].Speed.X = RringsX.Next(1, 5);
                    Rings[Rings.Count - 1].popping = true;
                }

                RingsPosses = 0;
            }
            else
            {
                Shield.num = 0;
                RessourceSonic3.PerteBouclier.Play();
            }

            Joueur.Speed = new Vector2();
            Joueur.HasJump = true;
            Joueur.Injure = true;

            if (Joueur.flip == SpriteEffects.None)
            {
                Joueur.Speed.X = -5;
                Joueur.Speed.Y = -5;
            }
            else
            {
                Joueur.Speed.X = 5;
                Joueur.Speed.Y = -5;
            }

        }
        
        public static void PerteRingPic(Vector2 Position,int RingsPosses,ref List<Ring>Rings)
        {
            Random RringsY = new Random();
            Random RringsX = new Random();

            for (int i = RingsPosses - 1; i >= 0; i--)
            {
                Rings.Add(new Ring(new Vector2(Position.X,Position.Y - 75)));
                //Random 2 fois pour permettre plus de hasard
                Rings[Rings.Count - 1].Speed.Y = RringsY.Next(-6, -3);
                Rings[Rings.Count - 1].Speed.X = RringsX.Next(1, 5);
                Rings[Rings.Count - 1].Speed.Y = RringsY.Next(-6, -3);
                Rings[Rings.Count - 1].Speed.X = RringsX.Next(1, 5);
                Rings[Rings.Count - 1].popping = true;
            }
        }

        public static void Animal(bool Actif, int NumAnimal, Random RAnimal, ref AnimationPlayer AnimationPlayer, ref Vector2 PosAnimationPlayer,Camera camera)
        {
            if (!Actif)
                return;

            NumAnimal = RAnimal.Next(1, 4);
            NumAnimal = RAnimal.Next(1, 4);

            if (AnimationPlayer.FrameIndex == 4)
            {
                switch (NumAnimal)
                {
                    case 1: AnimationPlayer.PlayAnimation(AllAnimationSonic.EcureuilAnim);
                        break;
                    case 2: AnimationPlayer.PlayAnimation(AllAnimationSonic.PouletAnim);
                        break;
                    case 3: AnimationPlayer.PlayAnimation(AllAnimationSonic.OiseauAnim);
                        break;
                }

            }

            if (AnimationPlayer.Animation == AllAnimationSonic.EcureuilAnim ||
                AnimationPlayer.Animation == AllAnimationSonic.OiseauAnim ||
                AnimationPlayer.Animation == AllAnimationSonic.PouletAnim)
                PosAnimationPlayer.X += 7;

            if (PosAnimationPlayer.X > camera.X + 300)
                AnimationPlayer.PlayAnimation(null);
        }

        public static void ActivationAnimal(ref Vector2 PosAnimationPlayer,Vector2 PosRef,ref bool AnimalActif,ref AnimationPlayer AnimationPlayer)
        {
            PosAnimationPlayer = new Vector2(PosRef.X + 80, PosRef.Y + 80);
            AnimalActif = true;
            AnimationPlayer.PlayAnimation(AllAnimationSonic.KillEnnemiExplosion);
        }
    }
}
