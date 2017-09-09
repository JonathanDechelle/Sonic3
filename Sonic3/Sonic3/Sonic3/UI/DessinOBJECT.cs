using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

class DessinOBJECT
{
    public static void AvantPlanDraw(SpriteBatch g, GameTime gametime, List<Pic> Pics, List<ObjectMapping> TexturesObject, List<Checkpoint> CheckPoints,
                            List<Flag> Flags, List<Loop> Loops, List<FireBreath> MiniBoss, List<Pente> Pentes, List<Tremplin> Tremplins, List<Tele> Teles,
                            List<SingeArticuler> Singes, List<Ring> Rings, List<Rhinobot> Rhinobots)
    {
        foreach (Pic P in Pics)
            P.Draw(g);


        foreach (ObjectMapping Texture in TexturesObject)
            Texture.Draw(g);


        foreach (Tele t in Teles)
            t.Draw(gametime, g);


        foreach (Tremplin t in Tremplins)
            t.Draw(gametime, g);


        foreach (Rhinobot rh in Rhinobots)
            rh.Draw(g, gametime);

        foreach (Checkpoint c in CheckPoints)
            c.Draw(gametime, g);

        foreach (Ring r in Rings)
            r.Draw(gametime, g);


        foreach (SingeArticuler s in Singes)
            s.Draw(g);

        foreach (Loop L in Loops)
            L.Draw(g);

        foreach (Pente P in Pentes)
            P.Draw(g);


        foreach (FireBreath f in MiniBoss)
            f.Draw(g, gametime);

        foreach (Flag F in Flags)
            F.Draw(gametime, g);
    }

    public static void ArrierePlanDraw(SpriteBatch g, GameTime gametime, Shield Shield, List<BackGroundTexture> BackTextures,
                                        HUD Hud, List<TexteFinAnim> TexteFin, List<Menu> Menus)
    {
        Shield.Draw(g, gametime);

        foreach (BackGroundTexture b in BackTextures)
            b.Draw(g);

        Hud.Draw(g);

        foreach (TexteFinAnim T in TexteFin)
            T.Draw(g);

        foreach (Menu M in Menus)
            M.Draw(g);
    }
}
