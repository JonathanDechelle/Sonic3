using System;
using Microsoft.Xna.Framework;

public class ScreenClassFactory
{
    public static GameScreen GetScreen(EScreen aScreen)
    {
        GameScreenManager gameScreenManager = GameScreenManager.Instance;
        IServiceProvider serviceProvider = gameScreenManager.Service;
        GraphicsDeviceManager graphics = gameScreenManager.Graphics;

        switch (aScreen)
        {
            case EScreen.SplashScreen:
                return new cIntro(serviceProvider, graphics);
            case EScreen.MainTitle:
                return new MainTitle(serviceProvider, graphics);
        }

        return null;
    }
}