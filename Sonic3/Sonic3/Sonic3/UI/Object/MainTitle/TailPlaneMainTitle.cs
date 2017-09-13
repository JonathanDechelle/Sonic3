using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

public class TailPlaneMainTitle
{
    private const float INITIAL_POSITION_X = 0;
    private const float INITIAL_POSITION_Y = 250f;
    private const float SPEED = 1.5f;
    private const float LIMIT_LEFT_X = -60;
    private const float LIMIT_RIGHT_X = 860;

    private AnimationPlayer m_AnimationPlayer;
    private Animation m_TailsAirplane;

    private Vector2 m_Position;
    private SpriteEffects m_SpriteEffect;
    private EDirection m_Direction;
    private float m_Speed;

    private enum EDirection
    {
        Left = -1,
        Right = 1,
    }

    //TODO LOGIC
    private bool m_Retour;

    public TailPlaneMainTitle()
    {
        Initialize();
    }

    private void Initialize()
    {
        LoadAnimation();
        SetupInitialValues();
    }

    private void LoadAnimation()
    {
        m_AnimationPlayer = new AnimationPlayer();
        m_TailsAirplane = new Animation(RessourceSonic3.TailAirplane, 100, 0.1f, 2, true);
    }

    private void SetupInitialValues()
    {
        SetupInitialPosition();
        SetupInitialDirection();
        SetupInitialSpeed();
    }

    private void SetupInitialPosition()
    {
        m_Position = new Vector2(INITIAL_POSITION_X, INITIAL_POSITION_Y);
    }

    private void SetupInitialDirection()
    {
        m_Direction = EDirection.Right;
    }

    private void SetupInitialSpeed()
    {
        m_Speed = SPEED;
    }

    public void Draw(GameTime aGameTime, SpriteBatch aSpritebatch)
    {
        m_AnimationPlayer.Draw(aGameTime, aSpritebatch, m_Position, m_SpriteEffect);
    }

    public void Update(GameTime aGameTime)
    {
        m_AnimationPlayer.PlayAnimation(m_TailsAirplane);

        ChangePosition();
        SetSpriteEffect(m_Direction);
        ChangeDirection();
    }

    private void ChangePosition()
    {
        float positionAdded = m_Speed * (float)m_Direction;
        m_Position.X += positionAdded;
    }

    private void SetSpriteEffect(EDirection aDirection)
    {
        m_SpriteEffect = aDirection == EDirection.Right
            ? SpriteEffects.None
            : SpriteEffects.FlipHorizontally;
    }

    private void ChangeDirection()
    {
        if (m_Position.X > LIMIT_RIGHT_X)
        {
            ChangeDirection(EDirection.Left);
            return;
        }

        if (m_Position.X < LIMIT_LEFT_X)
        {
            ChangeDirection(EDirection.Right);
        }
    }

    private void ChangeDirection(EDirection aDirection)
    {
        m_Direction = aDirection;
    }
}