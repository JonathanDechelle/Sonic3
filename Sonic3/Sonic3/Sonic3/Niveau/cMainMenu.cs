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

class cMainMenu : GameScreen
{
    private enum ECharacter
    {
        Sonic = 0,
        Tail = 1,
        COUNT
    }

    private enum ELevel
    {
        NewGame = 0,
        AngelIslandP1 = 1,
    }

    private Dictionary<ECharacter, Texture2D> m_Characters;
    private Dictionary<ELevel, Texture2D> m_LevelIcons;

    Vector2 PosImageNiv = new Vector2(225, 30);
    AnimationPlayer AnimationPlayer = new AnimationPlayer();
    AnimationPlayer Ap2 = new AnimationPlayer();
    Animation CadreAnim1 = new Animation(RessourceSonic3.CadreAnim, 300, 0.1f, 1, true);
    Animation CadreAnim2 = new Animation(RessourceSonic3.CadreCarre, 266, 0.1f, 1, true);
    Animation Cadre;
    Animation Fleche = new Animation(RessourceSonic3.FlecheSelect, 300, 0.3f, 0.85f, true);
    Vector2 PosCadre = new Vector2(325, 530);
    Vector2 PosFleche = new Vector2(328, 440);
    Texture2D m_LevelIconSelected, m_CharacterImageSaveSlot, m_CharacterImageNoSaveSlot;
    int NumNiv = 0;
    bool decalement;

    private float m_Speed = 10f;

    public cMainMenu(IServiceProvider serviceProvider, GraphicsDeviceManager graphics)
        : base(serviceProvider, graphics)
    {
        Cadre = CadreAnim1;
    }

    public override void Load()
    {
        LoadCharacter();
        InitializeCharacterSelected();

        LoadLevelIcon();
        InitializeLevelIcon();
    }

    #region Music
    private void LoadMusic()
    {
        //MediaPlayer.Play(RessourceSonic3.MainMenuSong);
        //MediaPlayer.IsRepeating = true;
    }
#endregion

    #region Character
    private void LoadCharacter()
    {
        m_Characters = new Dictionary<ECharacter, Texture2D>();
        m_Characters.Add(ECharacter.Sonic, RessourceSonic3.SonicPresent);
        m_Characters.Add(ECharacter.Tail, RessourceSonic3.TailPresent);
    }

    private void InitializeCharacterSelected()
    {
        InitializeCharacterInSaveSlot();
        InitializeCharacterInSlotWithNoSave();
    }

    private void InitializeCharacterInSaveSlot()
    {
        ChangeCharactedSelected(true, ECharacter.Sonic);
    }

    private void InitializeCharacterInSlotWithNoSave()
    {
        ChangeCharactedSelected(false, ECharacter.Sonic);
    }

    private void ChangeCharactedSelected(bool aIsSave, ECharacter aCharacter)
    {
        ChangeCharactedSelected(ref m_CharacterImageSaveSlot, aCharacter);
        ChangeCharactedSelected(ref m_CharacterImageNoSaveSlot, aCharacter);
    }

    private void ChangeCharactedSelected(ref Texture2D aCurrentTexture, ECharacter aNewCharacter)
    {
        aCurrentTexture = GetCharacterTexture(aNewCharacter);
    }

    private Texture2D GetCharacterTexture(ECharacter aCharactere)
    {
        return m_Characters[aCharactere];
    }
    #endregion

    #region Level Icon
    private void LoadLevelIcon()
    {
        m_LevelIcons = new Dictionary<ELevel, Texture2D>();
        m_LevelIcons.Add(ELevel.NewGame, RessourceSonic3.NewGame);
        m_LevelIcons.Add(ELevel.AngelIslandP1, RessourceSonic3.Stage1);
    }

    private void InitializeLevelIcon()
    {
        ChangeLevelIcon(ELevel.NewGame);
    }

    private void ChangeLevelIcon(ELevel aLevel)
    {
        m_LevelIconSelected = m_LevelIcons[aLevel];
    }

    private void SetupCurrentLevelIcon()
    {
        //TODO save with enum
        switch (NumNiv)
        {
            case 0: m_LevelIconSelected = RessourceSonic3.NewGame;
                break;
            case 1: m_LevelIconSelected = RessourceSonic3.Stage1;
                break;
        }
    }
    #endregion

    public override void Update(GameTime aGameTime)
    {
        base.Update(aGameTime);

        AnimationPlayer.PlayAnimation(Cadre);
        Ap2.PlayAnimation(Fleche);

        if (SaveCheckPoint.Life == 0)
        {
            GameScreenManager.Instance.ChangeScreen(EScreen.SplashScreen);
            return;
        }

        if (KeyboardHelper.KeyPressed(Keys.Left) || KeyboardHelper.KeyPressed(Keys.Right) || decalement)
        {
            if (Cadre == CadreAnim1)
            {
                PosCadre.X -= m_Speed;
                decalement = true;
                if (PosCadre.X <= 110)
                {
                    PosCadre = new Vector2(110, 271);
                    PosFleche = new Vector2(120, 230);
                    Fleche.Resize = 0.60f;
                    Cadre = CadreAnim2;
                    decalement = false;
                }
            }
            else
            {
                PosCadre.X += m_Speed;
                decalement = true;
                if (PosCadre.X >= 325)
                {
                    PosCadre = new Vector2(325, 530);
                    PosFleche = new Vector2(328, 440);
                    Fleche.Resize = 0.85f;
                    Cadre = CadreAnim1;
                    decalement = false;
                }
            }
        }
    }

    public override void OnDirectionPressed(Keys aKeys)
    {
        if (KeyboardHelper.KeyPressed(Keys.Up) || KeyboardHelper.KeyPressed(Keys.Down))
        {
            ToggleCurrentCharacter();
        }
    }

    private void ToggleCurrentCharacter()
    {
        Texture2D textureUsed = Cadre == CadreAnim1
            ? m_CharacterImageSaveSlot
            : m_CharacterImageNoSaveSlot;

        // ISSUE WITH TEXTURE 2D
            if (m_CharacterImageSaveSlot == RessourceSonic3.SonicPresent)
                m_CharacterImageSaveSlot = RessourceSonic3.TailPresent;
            else
                m_CharacterImageSaveSlot = RessourceSonic3.SonicPresent;
    }

    public override void OnEnterPressed()
    {
        if (Cadre == CadreAnim2)
            SaveCheckPoint.CheckPointID = 1;

        if (NumNiv == 0 || NumNiv == 1)
        {
            MediaPlayer.Play(RessourceSonic3.AngelIslandAct1Song);

            int Numperso;
            if (Cadre == CadreAnim1)
            {
                if (m_CharacterImageSaveSlot == RessourceSonic3.SonicPresent) Numperso = 1;
                else Numperso = 2;
            }
            else
            {
                if (m_CharacterImageNoSaveSlot == RessourceSonic3.SonicPresent) Numperso = 1;
                else Numperso = 2;
            }

            //AddScreen(new cAngelIsland(serviceProvider, GraphicsDeviceManager, Numperso));

            if (Cadre == CadreAnim2)
                NumNiv = 0;
            else
                NumNiv = 1;
        }
        base.OnEnterPressed();
    }

    public override void Draw(GameTime gametime, SpriteBatch g)
    {
        g.Draw(RessourceSonic3.MainMenuBack, new Rectangle(1, 1, 800, 500), Color.White);
        g.Draw(RessourceSonic3.CadreNoSave, new Rectangle(-20, 20, (int)(RessourceSonic3.CadreNoSave.Width / 1.5), (int)(RessourceSonic3.CadreNoSave.Height / 1.5)), Color.White);
        g.Draw(m_LevelIconSelected, new Rectangle((int)PosImageNiv.X, (int)PosImageNiv.Y, (int)(m_LevelIconSelected.Width / 1.5), (int)(m_LevelIconSelected.Height / 1.5)), Color.White);
        g.Draw(RessourceSonic3.CadreNormal, new Rectangle(200, 5, (int)(RessourceSonic3.CadreNormal.Width / 1.5), (int)(RessourceSonic3.CadreNormal.Height / 1.5)), Color.White);
        AnimationPlayer.Draw(gametime, g, PosCadre, SpriteEffects.None);
        g.Draw(m_CharacterImageSaveSlot, new Rectangle(225, 210, RessourceSonic3.SonicPresent.Width * 2, RessourceSonic3.SonicPresent.Height * 2), Color.White);
        g.Draw(m_CharacterImageNoSaveSlot, new Rectangle(17, 40, RessourceSonic3.SonicPresent.Width * 2, RessourceSonic3.SonicPresent.Height * 2), Color.White);
        //Ap2.Draw(5,220,(int)(RessourceSonic3.FlecheSelect.Width/1.5),(int)(RessourceSonic3.FlecheSelect.Height/1.5)),Color.White);7
        Ap2.Draw(gametime, g, PosFleche, SpriteEffects.None);
    }
}
