using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class Sonic3Emblem
{
    private const float INITIAL_POSITION_X = 120;
    private const float INITIAL_POSITION_Y = 500;
    private const float INITIAL_SPEED = 5.3f;
    private const float TARGET_HEIGHT = 250f;
    private const int RENDER_MULTIPLIER = 2;

    private Vector2 m_Position;
    private float m_Speed;
    private bool m_HasReachedTargetPosition;

    public Sonic3Emblem()
    {
        Load();
    }

    private void Load()
    {
        SetupInitialValues();
    }

    private void SetupInitialValues()
    {
        m_Position = new Vector2(INITIAL_POSITION_X, INITIAL_POSITION_Y);
        m_Speed = INITIAL_SPEED;
    }

    public void Update()
    {
        if (m_HasReachedTargetPosition)
        {
            return;
        }

        UpdatePosition();
    }

    private void UpdatePosition()
    {
        float nextHeight = m_Position.Y - m_Speed;

        m_HasReachedTargetPosition = nextHeight < TARGET_HEIGHT;

        float cappedHeight = Math.Max(nextHeight, TARGET_HEIGHT);
        m_Position.Y = cappedHeight;
    }

    public void Draw(GameTime aGameTime, SpriteBatch aSpritebatch)
    {
        aSpritebatch.Draw(RessourceSonic3.SonicEmbleme, new Rectangle((int)m_Position.X, (int)m_Position.Y, GetWidthToRender(), GetHeightToRender()), Color.White);
    }

    private static int GetHeightToRender()
    {
        return RessourceSonic3.SonicEmbleme.Height * RENDER_MULTIPLIER;
    }

    private static int GetWidthToRender()
    {
        return RessourceSonic3.SonicEmbleme.Width * RENDER_MULTIPLIER;
    }
}
