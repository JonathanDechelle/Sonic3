using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

class SegaSplashScreen
{
    private int NUMBER_OF_PART = 5;
    private const int FRAME_NUMBERS_BY_PART = 5;

    private Animation[] m_SegaAnimationPart;
    private AnimationPlayer m_AnimationPlayer;

    private int m_CurrentAnimationPartIndex;
    public Action OnFinishCallback;

    public SegaSplashScreen()
    {
        ResetVariables();
    }

    private void ResetVariables()
    {
        m_CurrentAnimationPartIndex = 0;
        m_SegaAnimationPart = new Animation[NUMBER_OF_PART];
        m_AnimationPlayer = new AnimationPlayer();
    }

    public void Load()
    {
        m_SegaAnimationPart[0] = new Animation(RessourceSonic3.LogoPart1, 250, 0.10f, 2, false);
        m_SegaAnimationPart[1] = new Animation(RessourceSonic3.LogoPart2, 250, 0.15f, 2, false);
        m_SegaAnimationPart[2] = new Animation(RessourceSonic3.LogoPart3, 250, 0.20f, 2, false);
        m_SegaAnimationPart[3] = new Animation(RessourceSonic3.LogoPart4, 250, 0.25f, 2, false);
        m_SegaAnimationPart[4] = new Animation(RessourceSonic3.LogoPart5, 250, 0.32f, 2, false);
    }

    public void StartTheme()
    {
        MediaPlayer.IsRepeating = false;
        MediaPlayer.Play(RessourceSonic3.SegaSong);
    }

    public void UpdateAnimation()
    {
        SwitchCurrentAnimationPart();
        ManageCurrentAnimationPart();
    }

    private void SwitchCurrentAnimationPart()
    {
        int currentFrameIndex = CurrentFrameIndex();
        if (currentFrameIndex != LastFrameIndex())
        {
            return;
        }

        m_CurrentAnimationPartIndex++;
    }

    private int CurrentFrameIndex()
    {
        return m_AnimationPlayer.FrameIndex;
    }

    private void ManageCurrentAnimationPart()
    {
        if (m_CurrentAnimationPartIndex == NUMBER_OF_PART)
        {
            OnFinishCallback.SafeInvoke();
            return;
        }

        PlayCurrentAnimationPart();
    }

    private static int LastFrameIndex()
    {
        return FRAME_NUMBERS_BY_PART - 1;
    }

    private void PlayCurrentAnimationPart()
    {
        Animation currentPartAnimation = m_SegaAnimationPart[m_CurrentAnimationPartIndex];
        m_AnimationPlayer.PlayAnimation(currentPartAnimation);
    }

    public void DrawAnimation(GameTime gametime, SpriteBatch g)
    {
        m_AnimationPlayer.Draw(gametime, g, new Vector2(380, 500), SpriteEffects.None);
    }
}
