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
    /// <summary>
    /// classe associer au stockage de toutes les images
    /// </summary>
    public class RessourcesLoxi
    {
        //Variable d'image static 
        public static Texture2D Test, Niv1Plage,PageTitre,BambooForest,TestPatrouille,BackgroundEtoile;

        //Action Loxi
        public static Texture2D WalkLoxi, JumpLoxi, JumpForwardLoxi, NothingLoxi, Transformation, Hula,
                                SorsDeFosse1, SorsDeFosse2, Hula2,SuperCombo1,SuperCombo2;

        //Action Donald
        public static Texture2D NothingDonald, WalkingDonald, JumpDonald, JumpForwardDonald, Shoot, ShootUpward;

        //Action raphael,michelangelo,donatello,leonard0
        public static Texture2D WalkingRaph, RaphAttack, WalkingMich, MichAttack,WalkingDonatello,DonAttack,LeoWalking,LeoAttack,
                                AfterFightRaph,AfterFightMich,AfterFightDon,AfterFightLeo,MichAttack2,DonAttack2,RaphAttack2,LeoAttack2;
                           
        //Daffy duck
        public static Texture2D DaffiDuck,DaffiExitLevel;

        //Bouton
        public static Texture2D MainMenuButton,ExplicationMainButton;

        //Pause 
        public static Texture2D PausedMenu;

        //HelatBar
        public static Texture2D HealtBar,HealtBarCombat;

        //Sprite Texte
        public static SpriteFont Texte,Texte2;

        //Pluie-ParticleGenerator
        public static Texture2D Rain;

        //Musique et sons
        public static Song SongImageTitre, SongCinematique1,SongNiv1,SongCinematique2,SongNiv2,SongCinematique3,Rasputin,FinalSong;
        public static SoundEffect JumpEffect,ShootEffect;

        //Balle
        public static Texture2D BalleJoueur;

        //Niveau Complexe Scientifique
        public static Texture2D BunkerUpperView, BunkerRightSide, BunkerLeftSide,Fleche,Cercle,Donald,
                                RifleSoldierCheck,RifleSoldierPatrouille,BulleParole,FouAnime,DragInNiv2,Machine,Machine2;

        //Niveau CombatTortueNinja
        public static Texture2D PresentCombatWarrior,PresentRaph,PresentLeonardo,PresentDonatello,
                                PresentMichelangelo,SplinterSingle,Perchoir,grotte,grotte2,grotte3,grotte4,grotte5,
                                DanseTransfo;
        //Wario 
        public static Texture2D WarioNormal, WarioSurpris, WarioExplique,WarioExplosion;
        //Load Content
        public static void LoadContent(ContentManager Content)
        {
            FinalSong = Content.Load<Song>("SkrillexOrchestral");
            SuperCombo1 = Content.Load<Texture2D>("superCombo1");
            SuperCombo2 = Content.Load<Texture2D>("superCombo2");
            WarioExplosion = Content.Load<Texture2D>("WarioDestruction");
            LeoAttack2 = Content.Load<Texture2D>("LeoAttack2");
            MichAttack2 = Content.Load<Texture2D>("MichAttack2");
            RaphAttack2 = Content.Load<Texture2D>("RaphAttack2");
            DonAttack2 = Content.Load<Texture2D>("DonAttack2");
            Hula2 = Content.Load<Texture2D>("Hula2");
            BackgroundEtoile = Content.Load<Texture2D>("Crazy");
            Rasputin = Content.Load<Song>("Rasputin");
            DaffiExitLevel = Content.Load<Texture2D>("ExitLevel");
            WarioNormal = Content.Load<Texture2D>("warionormal");
            WarioSurpris = Content.Load<Texture2D>("wariosurpris");
            WarioExplique = Content.Load<Texture2D>("warioexplique");
            SongCinematique3 = Content.Load<Song>("Anti Gravity");
            SorsDeFosse1 = Content.Load<Texture2D>("SorsDeFausse1");
            SorsDeFosse2 = Content.Load<Texture2D>("SorsDeFausse2");
            DanseTransfo = Content.Load<Texture2D>("DanseTransfo");
            AfterFightDon = Content.Load<Texture2D>("AfterFightDon");
            AfterFightLeo = Content.Load<Texture2D>("AfterFightLeo");
            AfterFightMich = Content.Load<Texture2D>("AfterFightMich");
            AfterFightRaph = Content.Load<Texture2D>("AfterFightRaph");
            LeoAttack = Content.Load<Texture2D>("leoattack");
            LeoWalking = Content.Load<Texture2D>("leowalking");
            grotte5 = Content.Load<Texture2D>("grotte5");
            DonAttack = Content.Load<Texture2D>("DonAttack");
            WalkingDonatello = Content.Load<Texture2D>("donwalking");
            WalkingMich = Content.Load<Texture2D>("walkingmich");
            MichAttack = Content.Load<Texture2D>("michattack");
            grotte4 = Content.Load<Texture2D>("grotte4");
            grotte3 = Content.Load<Texture2D>("grotte3");
            Perchoir = Content.Load<Texture2D>("perchoir");
            RaphAttack = Content.Load<Texture2D>("RaphAttack");
            WalkingRaph = Content.Load<Texture2D>("raphaelmarche");
            SongNiv2 = Content.Load<Song>("Electric Daisy Violin");
            SongCinematique2 = Content.Load<Song>("Shadows");
            SongNiv1 = Content.Load<Song>("Elements");
            grotte2 = Content.Load<Texture2D>("grotte2");
            grotte = Content.Load<Texture2D>("grotte");
            PresentCombatWarrior = Content.Load<Texture2D>("PresentationCombattant");
            SplinterSingle = Content.Load<Texture2D>("splinterSingle");
            PresentMichelangelo = Content.Load<Texture2D>("presentMichelangelo");
            PresentDonatello = Content.Load<Texture2D>("presentDonatello");
            PresentLeonardo = Content.Load<Texture2D>("presentLeonardo");
            PresentRaph = Content.Load<Texture2D>("PresentRaphaelle");
            Cercle = Content.Load<Texture2D>("Cercle");
            Texte2 = Content.Load<SpriteFont>("Parole");
            RifleSoldierCheck = Content.Load<Texture2D>("RifleSoldierCheck");
            RifleSoldierPatrouille = Content.Load<Texture2D>("RifleSoldierPatrouille");
            FouAnime = Content.Load<Texture2D>("fouanime");
            DragInNiv2 = Content.Load<Texture2D>("dragInNiv2");
            Machine = Content.Load<Texture2D>("Machine");
            Machine2 = Content.Load<Texture2D>("Machine2");
            Donald = Content.Load<Texture2D>("Donalduck");
            BunkerUpperView = Content.Load<Texture2D>("bunkerUpperView");
            BunkerRightSide = Content.Load<Texture2D>("bunkerRightSide");
            BunkerLeftSide = Content.Load<Texture2D>("bunkerLeftSide");
            Fleche = Content.Load<Texture2D>("fleche");
            BulleParole = Content.Load<Texture2D>("BulleDeParole");
            BalleJoueur = Content.Load<Texture2D>("BalleJoueur");
            SongImageTitre = Content.Load<Song>("SongLoxi");
            SongCinematique1 = Content.Load<Song>("LoveInMotion");
            JumpEffect = Content.Load<SoundEffect>("JumpEffect");
            ShootEffect = Content.Load<SoundEffect>("ShootEffect");
            TestPatrouille = Content.Load<Texture2D>("TestPatrouille");
            BambooForest = Content.Load<Texture2D>("foretbambous");
            Rain = Content.Load<Texture2D>("Goutte");
            Texte = Content.Load<SpriteFont>("fontCinematique");
            PageTitre = Content.Load<Texture2D>("ImageTitre");
            Test = Content.Load<Texture2D>("Test");
            Niv1Plage = Content.Load<Texture2D>("Plage");
            WalkLoxi = Content.Load<Texture2D>("WalkingLoxi");
            JumpLoxi = Content.Load<Texture2D>("JumpLoxi");
            JumpForwardLoxi = Content.Load<Texture2D>("JumpForwardLoxi");
            NothingLoxi = Content.Load<Texture2D>("NothingLoxi");
            Transformation = Content.Load<Texture2D>("Transform");
            Hula = Content.Load<Texture2D>("Hula");
            MainMenuButton = Content.Load<Texture2D>("btnStart");
            NothingDonald = Content.Load<Texture2D>("idleDonald");
            WalkingDonald = Content.Load<Texture2D>("WalkingDonald");
            JumpDonald = Content.Load<Texture2D>("JumpDonald");
            JumpForwardDonald = Content.Load<Texture2D>("JumpForwardDonald");
            Shoot = Content.Load<Texture2D>("ShootDonald");
            ShootUpward = Content.Load<Texture2D>("ShootDonaldUpward");
            DaffiDuck = Content.Load<Texture2D>("daffiduck");
            HealtBar = Content.Load<Texture2D>("HealtBar");
            HealtBarCombat = Content.Load<Texture2D>("HealtBarCombat");
            PausedMenu = Content.Load<Texture2D>("Donald_Original_Outfit");
            ExplicationMainButton = Content.Load<Texture2D>("btnExplication");
        }
       

        ///NOTE PERSO
        ///Spriters.ressources.com pour les personnage
        /// 
        ///Lécran fait
        /// 450X770
       
    }
}
