using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyGameLibrairy
{
    public class AllAnimationLoxi
    {

        static public AnimationPlayer AnimationPlayer = new AnimationPlayer();
        //Donald Animation
        #region DonaldAnimation
        public Animation DonaldNothingAnimation= new Animation(RessourcesLoxi.NothingDonald, 90, 1.5f, 2, true);
        public Animation DonaldWalkingAnimation=new Animation(RessourcesLoxi.WalkingDonald, 90, 0.1f, 2, true);
        public Animation DonaldJumpAnimation = new Animation(RessourcesLoxi.JumpDonald, 100, 0.2f, 2, true);
        public Animation DonaldJumpForwardAnimation= new Animation(RessourcesLoxi.JumpForwardDonald, 90, 0.2f, 2, true);
        public Animation DonaldShootAnimation = new Animation(RessourcesLoxi.Shoot, 90, 0.1f, 2, false);
        public Animation DonaldShootUpwardAnimation = new Animation(RessourcesLoxi.ShootUpward, 100, 0.1f, 2, false);
        #endregion
        //Loxi Animation
        #region LoxiAnimation
        public Animation LoxiwalkAnimation = new Animation(RessourcesLoxi.WalkLoxi, 90, 0.1f, 2, true);
        public Animation LoxiJumpAnimation = new Animation(RessourcesLoxi.JumpLoxi, 100, 0.1f, 2, true);
        static public Animation LoxinothingAnimation= new Animation(RessourcesLoxi.NothingLoxi, 80, 0.25f, 2, true);
        public Animation TransformationAnimation = new Animation(RessourcesLoxi.Transformation, 101, 0.15f, 2, true);
        public Animation LoxiJumpForwardAnimation = new Animation(RessourcesLoxi.JumpForwardLoxi, 85, 0.2f, 2, true);
        static public Animation HulaAnimation= new Animation(RessourcesLoxi.Hula, 100, 0.1f, 2, false);
        static public Animation Hula2Animation = new Animation(RessourcesLoxi.Hula2, 110, 0.1f, 2, false);
        static public Animation SuperComboPart1 = new Animation(RessourcesLoxi.SuperCombo1, 180, 0.5f, 2, false);
        static public Animation SuperComboPart2 = new Animation(RessourcesLoxi.SuperCombo2, 180, 0.5f, 2, false);
        #endregion

        //Animation wario
        #region Wario Animation
        static public Animation WarioSurpris = new Animation(RessourcesLoxi.WarioSurpris, 60, 0.5f, 2, true);
        static public Animation WarioExplique = new Animation(RessourcesLoxi.WarioExplique, 60, 0.5f, 2, true);
        static public Animation WarioExplose = new Animation(RessourcesLoxi.WarioExplosion, 60, 1, 2, false);
        #endregion

        #region Animation NivTortueNinja
        //Animation Splinter
        static public Animation DanseTransformation = new Animation(RessourcesLoxi.DanseTransfo, 80, 0.9f, 2, true);
        static public Animation NothingSplinter = new Animation(RessourcesLoxi.SplinterSingle, 80, 0.1f, 2, true);
        //Animation Tortue
        #region Raphael
        static public Animation WalkingRaph = new Animation(RessourcesLoxi.WalkingRaph, 80, 0.5f, 2, true);
        static public Animation RaphAttack = new Animation(RessourcesLoxi.RaphAttack, 90, 0.3f, 2, true);
        #endregion
        #region Michelangelo
        static public Animation WalkingMich = new Animation(RessourcesLoxi.WalkingMich, 80, 0.5f, 2, true);
        static public Animation MichAttack = new Animation(RessourcesLoxi.MichAttack, 100, 0.3f, 2, true);
        #endregion
        #region Donatello
        static public Animation WalkingDon = new Animation(RessourcesLoxi.WalkingDonatello, 80, 0.5f, 2, true);
        static public Animation DonAttack = new Animation(RessourcesLoxi.DonAttack, 105, 0.3f, 2, true);
        #endregion
        #region Leonardo
        static public Animation WalkingLeo = new Animation(RessourcesLoxi.LeoWalking, 80, 0.5f, 2, true);
        static public Animation LeoAttack = new Animation(RessourcesLoxi.LeoAttack, 100, 0.3f, 2, true);


        static public Animation RaphAttente = new Animation(RessourcesLoxi.AfterFightRaph, 80, 0.5f, 2, true);
        static public Animation MichAttente = new Animation(RessourcesLoxi.AfterFightMich, 80, 0.5f, 2, true);
        static public Animation DonAttente = new Animation(RessourcesLoxi.AfterFightDon, 80, 0.5f, 2, true);
        static public Animation LeoAttente = new Animation(RessourcesLoxi.AfterFightLeo, 80, 0.5f, 2, true);

        static public Animation RaphAttack2 = new Animation(RessourcesLoxi.RaphAttack2, 110, 0.5f, 2, false);
        static public Animation MichAttack2 = new Animation(RessourcesLoxi.MichAttack2, 120, 0.5f, 2, false);
        static public Animation DonAttack2 = new Animation(RessourcesLoxi.DonAttack2, 110, 0.5f, 2, false);
        static public Animation LeoAttack2 = new Animation(RessourcesLoxi.LeoAttack2, 110, 0.5f, 2, false);
        #endregion
        #endregion

        public float WalkingFrameTimer = 0.1f;
        public float CourseFrameTimer = 0.05f;
        public bool SonicGame = false;
    }
}
