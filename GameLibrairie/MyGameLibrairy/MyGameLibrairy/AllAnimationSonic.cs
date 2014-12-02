using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGameLibrairy
{
    public class AllAnimationSonic
    {
        static public AnimationPlayer AnimationPlayer = new AnimationPlayer();
        //Pack Sonic
        public Animation SonicNormal = new Animation(RessourceSonic3.NormalSonic, 80, 1f, 2, true);
        public Animation SonicWaiting = new Animation(RessourceSonic3.SonicWaiting, 80, 0.4f, 2, true);
        public Animation SonicCrouch = new Animation(RessourceSonic3.CrouchSonic, 80, 0.5f, 2, true);
        public Animation SonicSpin = new Animation(RessourceSonic3.SpiningSonic, 80, 0.04f, 2, true);
        public Animation SonicJump = new Animation(RessourceSonic3.SonicJump, 80, 0.1f, 2, true);
        public Animation SonicWalking = new Animation(RessourceSonic3.SonicWalking, 80, 0.3f, 2, true);
        public Animation SonicAttack1 = new Animation(RessourceSonic3.Attack1, 80, 0.080f, 2, false);
        public Animation SonicMiCourse = new Animation(RessourceSonic3.SonicMiCourse, 80, 0.08f, 2, true);
        public Animation SonicCourse = new Animation(RessourceSonic3.SonicCourse, 80, 0.07f, 2, true);
        public Animation SonicBalle = new Animation(RessourceSonic3.SonicJump, 80, 0.04f, 2, true);
        public Animation SonicHurt = new Animation(RessourceSonic3.SonicHurt, 80, 0.5f, 2, false);
        public Animation SonicSoDead = new Animation(RessourceSonic3.DeadSonic, 100, 0.2f, 1, true);
        //-----------------

        //Pack Tail

        public Animation TailWaiting = new Animation(RessourceSonic3.TailWaiting, 80, 0.4f, 2, true);
        public Animation TailWalking = new Animation(RessourceSonic3.TailWalking, 80, 0.3f, 2, true);
        public Animation TailJump = new Animation(RessourceSonic3.TailJump, 80, 0.05f, 2, true);
        public Animation TailJumpForward = new Animation(RessourceSonic3.TailJumpForward, 80, 0.1f, 2, false);
        public Animation TailCrouch = new Animation(RessourceSonic3.CrouchTail, 80, 0.5f, 2, true);
        public Animation TailBalle = new Animation(RessourceSonic3.TailBoule, 80, 0.04f, 2, true);
        public Animation TailSpin = new Animation(RessourceSonic3.SpiningTail, 80, 0.04f, 2, true);
        public Animation TailMiCourse = new Animation(RessourceSonic3.TailMiCourse, 80, 0.08f, 2, true);
        public Animation TailCourse = new Animation(RessourceSonic3.TailCourse, 80, 0.07f, 2, true);
        public Animation TailAttack1 = new Animation(RessourceSonic3.TailAttack1, 80, 0.080f, 2, false);
        public Animation TailcHurt = new Animation(RessourceSonic3.TailHurt, 80, 0.5f, 2, false);
        public Animation TailSoDead = new Animation(RessourceSonic3.DeadTail, 80, 0.2f, 2, true);
        //-------------------------------
        static public Animation TremplinRouge = new Animation(RessourceSonic3.tremplinrougeAnim, 100, 1f, 1, true);
        static public Animation RingAnim = new Animation(RessourceSonic3.RingAnim, 100, 0.25f, 1, true);
        static public Animation RingCatch = new Animation(RessourceSonic3.RingCatch, 100, 0.15f, 1, true);
        static public Animation KillEnnemiExplosion = new Animation(RessourceSonic3.KillEnnemie, 40, 0.1f, 2, false);
        static public Animation EcureuilAnim = new Animation(RessourceSonic3.Ecureuil, 50, 0.1f, 1, true);
        static public Animation PouletAnim = new Animation(RessourceSonic3.Poulet, 50, 0.1f, 1, true);
        static public Animation OiseauAnim = new Animation(RessourceSonic3.Oiseau, 50, 0.1f, 1, true);
        static public Animation ItemTele = new Animation(RessourceSonic3.ItemTele, 90, 0.4f, 1, true);
        static public Animation BulleShield = new Animation(RessourceSonic3.BubbleShieldAnim, 110, 0.2f, 1, true);
        static public Animation BulleJump = new Animation(RessourceSonic3.BulleJumpAnim, 150, 0.04f, 1, true);
        static public Animation BulleAnim = new Animation(RessourceSonic3.BulleAnim, 150, 0.06f, 1, true);
        public float WalkingFrameTimer = 0.1f;
        public float CourseFrameTimer = 0.08f;
       
    }
}
