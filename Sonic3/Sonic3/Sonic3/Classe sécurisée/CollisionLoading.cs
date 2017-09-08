using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonic3
{
    class CollisionLoading
    {
       static public void Load(List<ObjectMapping> TexturesObject,List<SingeArticuler> Singes,List<Loop> Loops,List<Pente> Pentes, List<ObjCollisionable>Obj)
        {
            if (TexturesObject != null)
            {
                foreach (ObjectMapping Texture in TexturesObject)
                    Obj.Add(Texture.Rectangle);
            }

            if (Singes != null)
            {
                foreach (SingeArticuler S in Singes)
                    Obj.Add(S.RecCollision);
            }

            if (Loops != null)
            {
                foreach (Loop L in Loops)
                    foreach (ObjCollisionable O in L.ListObjColls)
                        Obj.Add(O);
            }

            if (Pentes != null)
            {
                foreach (Pente P in Pentes)
                    foreach (ObjCollisionable O in P.ListObjColls)
                        Obj.Add(O);
            }
        }
    }
}
