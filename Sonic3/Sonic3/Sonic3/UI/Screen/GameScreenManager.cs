using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using Microsoft.Xna.Framework.Graphics;

public class GameScreenManager
{
    #region Instance
    private static GameScreenManager m_GameScreenManager;
    public static GameScreenManager Instance
    {
        get
        {
            if (m_GameScreenManager == null)
            {
                m_GameScreenManager = new GameScreenManager();
            }

            return m_GameScreenManager;
        }
    }
    #endregion

    public IServiceProvider Service { get; private set; }
    public GraphicsDeviceManager Graphics { get; private set; }

    private List<GameScreen> m_ListGameScreen = new List<GameScreen>();

    public void Initialize(GameServiceContainer aServices, GraphicsDeviceManager aGraphics)
    {
        Service = aServices;
        Graphics = aGraphics;
    }

    public void AddScreen(EScreen aScreen)
    {
        GameScreen screen = ScreenClassFactory.GetScreen(aScreen);
        AddScreen(screen);
    }

    private void AddScreen(GameScreen Screen)
    {
        Screen.Load();
        m_ListGameScreen.Add(Screen);
    }

    public void RemoveScreen(int Pos)
    {
        m_ListGameScreen[Pos].Alive = false;
    }

    public void RemoveScreen(GameScreen Screen)
    {
        Screen.Alive = false;
    }

    public void RemoveAllScreens(GameScreen ExcludedScreen = null)
    {
        for (int S = 0; S < m_ListGameScreen.Count; S++)
        {
            if (m_ListGameScreen[S] != ExcludedScreen)
            {
                m_ListGameScreen[S].Alive = false;
            }
        }
    }

    public void UpdateScreen(GameTime aGameTime)
    {
        for (int i = 0; i < m_ListGameScreen.Count; i++)
        {
            bool isOnTop = (i == m_ListGameScreen.Count - 1);

            GameScreen currentScreen = m_ListGameScreen[i];
            currentScreen.IsOnTop = isOnTop;

            if (currentScreen.RequireFocus && !currentScreen.IsOnTop)
            {
                return;
            }

            currentScreen.Update(aGameTime);

            if (!currentScreen.Alive)
            {
                m_ListGameScreen.RemoveAt(i);
                i--;
            }
        }
    }

    public void DrawScreen(GameTime aGameTime, SpriteBatch aSpritebatch)
    {
        for (int i = 0; i < m_ListGameScreen.Count; i++)
        {
            GameScreen currentScreen = m_ListGameScreen[i];

            if (currentScreen.RequireDrawFocus && !currentScreen.IsOnTop)
            {
                return;
            }

            if (!currentScreen.Alive)
            {
                return;
            }

            currentScreen.Draw(aGameTime, aSpritebatch);
        }
    }

    public void ChangeScreen(EScreen aScreen)
    {
        AddScreen(aScreen);
        RemoveLastScreen();
    }

    public void RemoveLastScreen()
    {
        int index = 0;
        RemoveScreen(index);
    }
}
