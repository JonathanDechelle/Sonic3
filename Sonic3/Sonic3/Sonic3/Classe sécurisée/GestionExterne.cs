using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

class GestionExterne
{

    static public void CameraControl(Camera camera)
    {
        //Controle camera test
        if (KeyboardHelper.KeyHold(Keys.I))
            camera.Zoom += 0.005f;
        else if (KeyboardHelper.KeyHold(Keys.K))
            camera.Zoom -= 0.005f;
        else if (KeyboardHelper.KeyPressed(Keys.O))
            camera.Zoom = 1;
    }

    static public void Menu(List<Menu> Menus, PlayerSonic Joueur, Camera camera, GameScreen Screen)
    {
        if (KeyboardHelper.KeyPressed(Keys.P) && Menus.Count == 0)
            Menus.Add(new Menu(Joueur, new Vector2(camera.X, camera.Y)));

        for (int M = Menus.Count - 1; M >= 0; M--)
        {
            Menus[M].Update(Joueur);
            if (Menus[M].Delete) Menus.RemoveAt(M);
            else
                if (Menus[M].Exit) GameScreen.RemoveScreen(Screen);
        }
    }

    static public void AnimationMort(List<Menu> Menus, bool FinNiveau, ref AnimationPlayer APDead, Animation Death, ref Vector2 APDeadpos,
                                     Vector2 APDeadPosInit, GameScreen Screen)
    {
        if (Menus.Count == 0 && !FinNiveau)
        {
            APDead.PlayAnimation(Death);
            APDeadpos.Y += 6;
            if (APDeadpos.Y - APDeadPosInit.Y == 600)
                GameScreen.RemoveScreen(Screen);
        }
    }

    static public Vector2 LoadingPosition(List<Checkpoint> CheckPoints, GameScreen Ecran)
    {
        if (SaveCheckPoint.Life == 0)
            GameScreen.RemoveScreen(Ecran);

        if (SaveCheckPoint.CheckPointID == 1)
            return new Vector2(100, 400);
        else
            return new Vector2
            (CheckPoints[SaveCheckPoint.CheckPointID - 1].Position.X,
            (CheckPoints[SaveCheckPoint.CheckPointID - 1].Position.Y - 40));

    }
    //-----------------------------------------------------------------------------------------------------------------------------------

    static public void UpdateRing(ref int RingsPosses, ref int Life, Rectangle RecUpdate, ref List<Ring> Rings, PlayerSonic Joueur, GameTime gameTime)
    {
        if (RingsPosses >= 100)
        {
            Life++;
            RessourceSonic3.LifeUp.Play();
            RingsPosses -= 100;
        }

        for (int i = Rings.Count - 1; i >= 0; i--)
        {
            if (RecUpdate.Intersects(Rings[i].RecRing))
                Rings[i].Update(Joueur.RecPerso, Joueur.flip, gameTime);
            if (Rings[i].catched) { Rings.RemoveAt(i); RingsPosses++; }
            else if (Rings[i].delete) Rings.RemoveAt(i);
        }
    }

    static public void UpdatePics(List<Pic> Pics, Rectangle RecUpdate, PlayerSonic Joueur, ref int RingsPosses, ref List<Ring> Rings, ref int Life, ref Shield Shield)
    {
        foreach (Pic P in Pics)
        {
            if (RecUpdate.Intersects(new Rectangle((int)P.Position.X, (int)P.Position.Y, 80, 80)) && !Joueur.Injure)
                P.Update(Joueur, ref RingsPosses, ref Rings, ref Life, ref Shield);
        }
    }

    static public void UpdateRhino(ref List<Rhinobot> Rhinobots, Rectangle RecUpdate, GameTime gameTime, PlayerSonic Joueur,
                                   ref int RingsPosses, ref int Life, ref Shield Shield, ref Vector2 PosAnimationPlayer,
                                   ref bool AnimalActif, ref AnimationPlayer AnimationPlayer, ref List<Ring> Rings, Random RringsX,
                                   Random RringsY)
    {
        for (int rh = Rhinobots.Count - 1; rh >= 0; rh--)
        {
            if (RecUpdate.Intersects(Rhinobots[rh].RecRhino))
                Rhinobots[rh].Update(gameTime, Joueur, ref RingsPosses, ref Life, ref Shield);
            #region Si rh toucher
            if (Rhinobots[rh].Touched)
            {
                //si saute sur rhino
                if (Rhinobots[rh].Destroy)
                {
                    CodeExclusifSonic.ActivationAnimal(ref PosAnimationPlayer, Rhinobots[rh].Position,
                                                       ref AnimalActif, ref AnimationPlayer);
                    Rhinobots.RemoveAt(rh);
                    continue;
                }

                //si n'a pas checker pour les perte de rings
                #region Perte des rings
                if (!Rhinobots[rh].PerteRingOneCheck)
                {
                    Rhinobots[rh].PerteRingOneCheck = true;
                    CodeExclusifSonic.PerteRing(ref RingsPosses, ref Life, ref Joueur, ref Rings, RringsY, RringsX, ref Shield);
                }

                Rhinobots[rh].Touched = false;
                #endregion

            }


            #endregion
        }
    }

    static public void UpdateSinge(ref List<SingeArticuler> Singes, Rectangle RecUpdate, GameTime gameTime, PlayerSonic Joueur,
                                   ref int RingsPosses, ref int Life, ref Shield Shield, ref Vector2 PosAnimationPlayer,
                                   ref bool AnimalActif, ref AnimationPlayer AnimationPlayer, ref List<Ring> Rings, Random RringsX,
                                   Random RringsY, ref List<ObjectMapping> TexturesObject)
    {
        for (int s = Singes.Count - 1; s >= 0; s--)
        {
            if (RecUpdate.Intersects((new Rectangle(Singes[s].RecTete.X - 100, Singes[s].RecTete.Y, Singes[s].RecTete.Width + 200, Singes[s].RecTete.Height))))
                Singes[s].Update(gameTime, Joueur.RecPerso);

            if (Singes[s].RecTete.Intersects(Joueur.RecPerso))
            {
                //Si saute sur singe
                if ((Joueur.HasJump || Joueur.EnBoule) && !Joueur.Injure)
                {
                    CodeExclusifSonic.ActivationAnimal(ref PosAnimationPlayer, Singes[s].PositionTete, ref AnimalActif, ref AnimationPlayer);
                    RessourceSonic3.EnnemiItem.Play();
                    TexturesObject.Add(new ObjectMapping(4, Singes[s].PositionArbre));
                    Singes.RemoveAt(s);
                    continue;
                }

            }
            //si a encore une noix
            if (Singes[s].BrasArticuler.Noix.Count != 0)
            {
                //Si noix Intersect joueur
                if (Singes[s].BrasArticuler.Noix[0].RecNoix.Intersects(Joueur.RecPerso))
                {
                    CodeExclusifSonic.PerteRing(ref RingsPosses, ref Life, ref Joueur, ref Rings, RringsY, RringsX, ref Shield);
                    Singes[s].BrasArticuler.Noix.Remove(Singes[s].BrasArticuler.Noix[0]);
                }
            }
        }
    }

    static public void UpdateLoop(List<Loop> Loops, Rectangle RecUpdate, ref PlayerSonic Joueur)
    {
        #region loop
        foreach (Loop L in Loops)
        {
            if (RecUpdate.Intersects(L.RecLoop))
                L.Update(ref Joueur);
        }
        #endregion
    }

    static public void UpdatePente(List<Pente> Pentes, Rectangle RecUpdate, ref PlayerSonic Joueur)
    {
        #region Pente
        foreach (Pente P in Pentes)
        {
            if (RecUpdate.Intersects(P.RecPente))
                P.Update(Joueur);
        }
        #endregion
    }

    static public void UpdateCheckPoint(List<Checkpoint> CheckPoints, Rectangle RecUpdate, PlayerSonic Joueur)
    {
        #region CheckPoint
        for (int c = 0; c <= CheckPoints.Count - 1; c++)
        {
            if (RecUpdate.Intersects(CheckPoints[c].RecCheck))
                CheckPoints[c].Update(Joueur.RecPerso);

            if (c == 0 && CheckPoints[0].Passer)
            {
                CheckPoints[0].Dernier = true;
                SaveCheckPoint.Update(CheckPoints[0].CheckPointID);
            }
            if (c != 0)
            {
                if (CheckPoints[c].Passer)
                {
                    for (int d = 1; c - d >= 0; d++)
                    {
                        CheckPoints[c - d].Dernier = false;
                    }

                    CheckPoints[c].Dernier = true;
                    SaveCheckPoint.Update(CheckPoints[c].CheckPointID);
                }
            }
        }
        #endregion
    }

    static public void UpdateTremplin(List<Tremplin> Tremplins, Rectangle RecUpdate, PlayerSonic Joueur)
    {
        #region Tremplin
        foreach (Tremplin t in Tremplins)
        {
            if (RecUpdate.Intersects(t.RecTremplin))
                t.Update(Joueur);
        }
        #endregion
    }

    static public void UpdateTele(ref List<Tele> Teles, Rectangle RecUpdate, GameTime gameTime, PlayerSonic Joueur,
                                  ref int Life, ref int RingsPosses, ref Shield Shield)
    {
        #region ItemTele
        for (int t = 0; t < Teles.Count; t++)
        {
            if (RecUpdate.Intersects(Teles[t].RecTele))
                Teles[t].Update(gameTime, Joueur, ref Life, ref RingsPosses, ref Shield);

            if (Teles[t].remove)
            {
                if (Joueur.EnBoule)
                    Joueur.EnBoule = false;
                Teles.RemoveAt(t);
            }
        }
        #endregion

    }
}
