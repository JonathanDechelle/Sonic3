using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class SonicMainTitle
{
    private AnimationPlayer m_AnimationPlayer;
    private Animation m_SonicEyes;
    private Animation m_SonicHands;

    private float m_AnimationTimer;
    private AnimationState m_AnimationState;

    private const float ANIMATION_TIME_BY_STATE = 3.5f;

    private enum AnimationState
    {
        Hands = 0,
        Eyes = 1,
        COUNT
    }

    public SonicMainTitle()
    {
        LoadAnimations();
        ResetAnimationValues();
    }

    private void LoadAnimations()
    {
        m_AnimationPlayer = new AnimationPlayer();
        m_SonicEyes = new Animation(RessourceSonic3.ClinOeil, 320, 0.08f, 2, false);
        m_SonicHands = new Animation(RessourceSonic3.MainSonic, 320, 0.1f, 2, false);
    }

    private void ResetAnimationValues()
    {
        m_AnimationTimer = 0;
        m_AnimationState = AnimationState.Hands;
    }

    public void Update(Microsoft.Xna.Framework.GameTime aGameTime)
    {
        m_AnimationTimer += (float)aGameTime.ElapsedGameTime.TotalSeconds;
        ManageAnimationTimeTimeout();

        PlayCurrentAnimation();
    }

    private void ManageAnimationTimeTimeout()
    {
        if (m_AnimationTimer < ANIMATION_TIME_BY_STATE)
        {
            return;
        }

        m_AnimationTimer = 0;
        GoToNextAnimationState();
    }

    private void GoToNextAnimationState()
    {
        m_AnimationState = (AnimationState) (((int)m_AnimationState + 1) % (int)AnimationState.COUNT);
    }

    private void PlayCurrentAnimation()
    {
        Animation currentAnimation = m_AnimationState == AnimationState.Hands
            ? m_SonicHands
            : m_SonicEyes;

        m_AnimationPlayer.PlayAnimation(currentAnimation);
    }

    public void Draw(Microsoft.Xna.Framework.GameTime aGameTime, Microsoft.Xna.Framework.Graphics.SpriteBatch aSpritebatch)
    {
        m_AnimationPlayer.Draw(aGameTime, aSpritebatch, new Vector2(400, 400), SpriteEffects.None);
    }
}