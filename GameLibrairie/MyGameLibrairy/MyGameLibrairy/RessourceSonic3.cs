using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;

namespace MyGameLibrairy
{
    public class RessourceSonic3
    {
        //Ecriture
        public static SpriteFont EcritureInformative;
        //intro
        public static Texture2D SegaLogo, BackIntro, TailAirplane, LogoPart1, LogoPart2, LogoPart3, LogoPart4, LogoPart5,
                                SonicEmbleme, CopyRight, ClinOeil, MainSonic, PlayerIntro, CompetIntro;

        public static Song SegaSong, IntroSong, MainMenuSong, AngelIslandAct1Song, AngelIslandAct2Song,MinorBoss, LevelComplete;

        //MainMenu
        public static Texture2D MainMenuBack, CadreNormal, CadreNoSave, CadreAnim, NewGame, Stage1, CadreCarre, SonicPresent, TailPresent,
                                FlecheSelect;
        //Pause
        public static Texture2D SonicPause;

        //AngelIsland
        public static Texture2D CompleteBack, Obstacle1, Obstacle2, Obs3,
            ArbreCoconut, Feuillage1, Feuillage2, Ecorce, Ecorce2,PicVerticale,loop,Pente1,Pente1A,Arriere3;

        //Angel Island Part2
        public static Texture2D BackAct2,BackAct2Front,BackComplete2,Obs4,Pente2,FireAnim,Act2Signe;

        public static Texture2D DustSpin;

        //PERSO
        //Sonic 
        public static Texture2D NormalSonic, SonicWaiting, CrouchSonic, SpiningSonic, SonicJump, SonicWalking, Attack1, SonicMiCourse, SonicCourse,
                               SonicHurt,DeadSonic;

        //Tail 
        public static Texture2D NormalTail, TailWaiting, CrouchTail, SpiningTail, TailJump, TailWalking, TailAttack1, TailMiCourse, TailCourse, TailHurt
                                 ,TailBoule,DeadTail,TailJumpForward;
        //Shield
        public static Texture2D BubbleShieldAnim,BulleJumpAnim,BulleAnim;
        //Testing
        public static Texture2D Test;

        //OBJECT
        public static Texture2D TremplinRouge, tremplinrougeAnim, RingAnim, RingCatch,CheckNonPasser,CheckPasser,ItemTele,TremplinH,TremplinHAnim,
            TremplinH2, TremplinHAnim2,TremplinBas,TremplinBasAnim;
        //Télé
        public static Texture2D ItemLife,ItemLifeTail, ItemRing, ItemBulleBlanche,ItemDestroy;

        //Sound and effect
        public static SoundEffect Jump, Spin, Spin2, Spring, CatchRing,LostRing,EnnemiItem,LifeUp,PerteBouclier,CheckPoint,FireBullet,TouchBoss,
            Hurt,MiniBossKill;

        // HUD --
        // font Rings
        public static Texture2D Ring0, Ring1, Ring2, Ring3, Ring4, Ring5, Ring6, Ring7, Ring8, Ring9,RingTexte;
        // Life 
        public static Texture2D SonicLife,TailLife;

        //ENNEMI
        //Kill Ennemi
        public static Texture2D KillEnnemie;
        //Animal
        public static Texture2D Poulet, Ecureuil, Oiseau;
        //Rhinobot
        public static Texture2D RhinobotMove,RhinoReturn1,RhinoReturn2;
        //Singe
        public static Texture2D TeteSinge,BrasSinge,MainSingeArticu,BouleBrasArti,NoixCoco,NoixArmed;
        //MiniBoss
        public static Texture2D MiniBoss1,MiniBoss1Touch,MB1feuAnim,MB1FireBullet,MiniBossDes,Flag,SonicFlag,TailFlag,BossGoalSign;

        //Fin de niveau
        public static Texture2D SonicText,TailText, PassedText, Act1Text;

        public static void LoadContent(ContentManager Content)
        {
            AngelIslandAct2Song = Content.Load<Song>("Angel Island  Act2");
            Act2Signe = Content.Load<Texture2D>("Act2Signe");
            FireAnim = Content.Load<Texture2D>("FireAnim");
            Pente2 = Content.Load<Texture2D>("Pente2");
            Obs4 = Content.Load<Texture2D>("Obs4");
            BackComplete2 = Content.Load<Texture2D>("BackComplete2");
            BackAct2Front = Content.Load<Texture2D>("Act2Front");
            BackAct2 = Content.Load<Texture2D>("Act2Back");
            TailLife = Content.Load<Texture2D>("TailLife");
            ItemLifeTail = Content.Load<Texture2D>("ItemLifeTail");
            TailFlag = Content.Load<Texture2D>("TailGoalSign");
            TailText = Content.Load<Texture2D>("TailText");
            SonicPause = Content.Load<Texture2D>("SonicPause");
            DeadTail = Content.Load<Texture2D>("DeadTail");
            TailHurt = Content.Load<Texture2D>("TailHurt");
            TailAttack1 = Content.Load<Texture2D>("TailAttack");
            TailCourse = Content.Load<Texture2D>("TailCourse");
            TailMiCourse = Content.Load<Texture2D>("TailMiCourse");
            TailJumpForward = Content.Load<Texture2D>("TailJumpForward");
            SpiningTail = Content.Load<Texture2D>("TailSpining");
            TailBoule = Content.Load<Texture2D>("TailBoule");   
            CrouchTail = Content.Load<Texture2D>("CrouchTail");
            TailJump = Content.Load<Texture2D>("TailJump");
            TailWalking = Content.Load<Texture2D>("TailWalking");
            TailWaiting = Content.Load<Texture2D>("TailWaiting");
            LevelComplete = Content.Load<Song>("Level Complete");
            SonicText = Content.Load<Texture2D>("SonicText");
            PassedText = Content.Load<Texture2D>("PassedText");
            Act1Text = Content.Load<Texture2D>("Act1Text");
            MinorBoss = Content.Load<Song>("Minor bosses");
            DeadSonic = Content.Load<Texture2D>("DeadSonic");
            TremplinBas = Content.Load<Texture2D>("RedBongB");
            TremplinBasAnim = Content.Load<Texture2D>("RedBongBAnim");
            Arriere3 = Content.Load<Texture2D>("Arriere3");
            TremplinH2 = Content.Load<Texture2D>("redBongH2");
            TremplinHAnim2 = Content.Load<Texture2D>("redBongHAnim2");
            TremplinH = Content.Load<Texture2D>("redBongH");
            TremplinHAnim = Content.Load<Texture2D>("redBongHAnim");
            BossGoalSign = Content.Load<Texture2D>("BossGoalSign");
            SonicFlag = Content.Load<Texture2D>("SonicGoalSign");
            Flag = Content.Load<Texture2D>("FlagAnim");
            MiniBossKill = Content.Load<SoundEffect>("Destruction MiniBoss");
            MiniBossDes = Content.Load<Texture2D>("miniBossDes");
            Hurt = Content.Load<SoundEffect>("Hurt");
            FireBullet = Content.Load<SoundEffect>("FireBulletwav");
            TouchBoss = Content.Load<SoundEffect>("TouchBoss");
            MB1FireBullet = Content.Load<Texture2D>("FireBullet");
            MB1feuAnim = Content.Load<Texture2D>("MB1FeuAnim");
            MiniBoss1Touch = Content.Load<Texture2D>("MiniBoss1Touch");
            MiniBoss1 = Content.Load<Texture2D>("MiniBoss1");
            CheckPoint = Content.Load<SoundEffect>("CheckPoint");
            Pente1A = Content.Load<Texture2D>("Pente1A");
            Pente1 = Content.Load<Texture2D>("Pente1");
            loop = Content.Load<Texture2D>("loop");
            PerteBouclier = Content.Load<SoundEffect>("Perte Bouclier");
            BulleAnim = Content.Load<Texture2D>("BulleAnim");
            BulleJumpAnim = Content.Load<Texture2D>("bulleJumpAnim");
            BubbleShieldAnim = Content.Load<Texture2D>("BulleShieldAnim");
            LifeUp = Content.Load<SoundEffect>("LifeUp");
            ItemDestroy = Content.Load<Texture2D>("itemDestroy");
            ItemLife = Content.Load<Texture2D>("itemLife");
            ItemRing = Content.Load<Texture2D>("itemRing");
            ItemBulleBlanche = Content.Load<Texture2D>("itemBulleBlanche");
            ItemTele = Content.Load<Texture2D>("itemTele");
            NoixCoco = Content.Load<Texture2D>("NoixCoco");
            NoixArmed = Content.Load<Texture2D>("NoixArmed");
            MainSingeArticu = Content.Load<Texture2D>("MainBrasArticuler");
            BouleBrasArti = Content.Load<Texture2D>("BouleBras");
            BrasSinge = Content.Load<Texture2D>("BrasSinge");
            TeteSinge = Content.Load<Texture2D>("TeteSinge");
            EnnemiItem = Content.Load<SoundEffect>("EnnemiItem");
            Poulet = Content.Load<Texture2D>("PoulelAnim");
            Oiseau = Content.Load<Texture2D>("OiseauAnim");
            Ecureuil = Content.Load<Texture2D>("EcureuilAnim");
            KillEnnemie = Content.Load<Texture2D>("killBadnickAnim");
            RhinoReturn1 = Content.Load<Texture2D>("RhinobotReturn1");
            RhinoReturn2 = Content.Load<Texture2D>("RhinobotReturn2");
            RhinobotMove = Content.Load<Texture2D>("RhinobotMove");
            CheckNonPasser = Content.Load<Texture2D>("checkpointNonPasser");
            CheckPasser = Content.Load<Texture2D>("checkpointPasser");
            SonicLife = Content.Load<Texture2D>("SonicLife");
            SonicHurt = Content.Load<Texture2D>("sonicHurt");
            LostRing = Content.Load<SoundEffect>("LostRing");
            PicVerticale = Content.Load<Texture2D>("PicVerticale");
            RingTexte = Content.Load<Texture2D>("RingText");
            Ring0 = Content.Load<Texture2D>("Ring0");
            Ring1 = Content.Load<Texture2D>("Ring1");
            Ring2 = Content.Load<Texture2D>("Ring2");
            Ring3 = Content.Load<Texture2D>("Ring3");
            Ring4 = Content.Load<Texture2D>("Ring4");
            Ring5 = Content.Load<Texture2D>("Ring5");
            Ring6 = Content.Load<Texture2D>("Ring6");
            Ring7 = Content.Load<Texture2D>("Ring7");
            Ring8 = Content.Load<Texture2D>("Ring8");
            Ring9 = Content.Load<Texture2D>("Ring9");
            CatchRing = Content.Load<SoundEffect>("CatchRing");
            RingCatch = Content.Load<Texture2D>("ringcatch");
            RingAnim = Content.Load<Texture2D>("ringAnim");
            Ecorce2 = Content.Load<Texture2D>("ecorceComplexe2");
            Ecorce = Content.Load<Texture2D>("ecorceComplexe");
            Spring = Content.Load<SoundEffect>("Spring");
            ArbreCoconut = Content.Load<Texture2D>("arbre");
            Feuillage1 = Content.Load<Texture2D>("feuillage1");
            Feuillage2 = Content.Load<Texture2D>("feuillage2");
            tremplinrougeAnim = Content.Load<Texture2D>("RedBongAnim");
            TremplinRouge = Content.Load<Texture2D>("RedBong");
            Jump = Content.Load<SoundEffect>("Jump");
            Spin = Content.Load<SoundEffect>("Spin");
            Spin2 = Content.Load<SoundEffect>("Spin2");
            SonicCourse=Content.Load<Texture2D>("SonicCourse");
            SonicMiCourse = Content.Load<Texture2D>("SonicMiCourse");
            EcritureInformative = Content.Load<SpriteFont>("Info");
            Obs3 = Content.Load<Texture2D>("Obs3");
            DustSpin = Content.Load<Texture2D>("DustSpin");
            Attack1 = Content.Load<Texture2D>("attack1");
            Obstacle2 = Content.Load<Texture2D>("obstacle2");
            Obstacle1 = Content.Load<Texture2D>("obstacle1");
            SonicWalking = Content.Load<Texture2D>("SonicWalking");
            SonicJump = Content.Load<Texture2D>("SonicJump");
            SpiningSonic = Content.Load<Texture2D>("SpiningSonic");
            CrouchSonic = Content.Load<Texture2D>("CrouchSonic");
            SonicWaiting = Content.Load<Texture2D>("SonicWaiting");
            NormalSonic = Content.Load<Texture2D>("normalSonic");
            CompleteBack = Content.Load<Texture2D>("CompleteAngelIslandBack");
            AngelIslandAct1Song = Content.Load<Song>("Angel Island  Act1");
            MainMenuSong = Content.Load<Song>("MainMenu");
            FlecheSelect = Content.Load<Texture2D>("flecheSelect");
            TailPresent = Content.Load<Texture2D>("TailPresent");
            SonicPresent = Content.Load<Texture2D>("sonicPresent");
            Test=Content.Load<Texture2D>("Test");
            CadreCarre = Content.Load<Texture2D>("cadreCarre");
            Stage1 = Content.Load<Texture2D>("Stage1");
            CadreNormal = Content.Load<Texture2D>("cadreNormal");
            CadreNoSave = Content.Load<Texture2D>("cadreNoSave");
            CadreAnim = Content.Load<Texture2D>("cadreAnim");
            NewGame = Content.Load<Texture2D>("NewGame");
            MainMenuBack = Content.Load<Texture2D>("MainMenuBack2");
            PlayerIntro = Content.Load<Texture2D>("playerIntro");
            CompetIntro = Content.Load<Texture2D>("CompetIntro");
            MainSonic = Content.Load<Texture2D>("MainSonic");
            ClinOeil = Content.Load<Texture2D>("ClinOeil");
            CopyRight = Content.Load<Texture2D>("Copyright");
            SonicEmbleme = Content.Load<Texture2D>("sonic3embleme");
            SegaSong = Content.Load<Song>("sega");
            IntroSong = Content.Load<Song>("SonicIntroRepeat");
            LogoPart1 = Content.Load<Texture2D>("LogoPart1");
            LogoPart2 = Content.Load<Texture2D>("LogoPart2");
            LogoPart3 = Content.Load<Texture2D>("LogoPart3");
            LogoPart4 = Content.Load<Texture2D>("LogoPart4");
            LogoPart5 = Content.Load<Texture2D>("LogoPart5");
            SegaLogo=Content.Load<Texture2D>("segalogow");
            BackIntro = Content.Load<Texture2D>("backintro");
            TailAirplane = Content.Load<Texture2D>("TailAirplane");
        }
    }
}
