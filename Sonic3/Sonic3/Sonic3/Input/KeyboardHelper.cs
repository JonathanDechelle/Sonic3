using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

    /// <summary>
    /// Classe associer aux controles de clavier
    /// </summary>
public class KeyboardHelper
{
    private enum InputStatus { FirstPress = 1, SecondPress = 70, ThirdPress = 120, FourthPress = 170, LastPress = 220 };

    public static KeyboardState PlayerState;
    public static KeyboardState PlayerStateLast;

    private static Keys[] MoveLeft = new Keys[] { Keys.Left, Keys.A };
    private static Keys[] MoveRight = new Keys[] { Keys.Right, Keys.D };
    private static Keys[] MoveUp = new Keys[] { Keys.Up, Keys.W };
    private static Keys[] MoveDown = new Keys[] { Keys.Down, Keys.S };
    public static Keys[] ConfirmChoice = new Keys[] { Keys.Space, Keys.X };
    public static Keys[] AlternateChoice = new Keys[] { Keys.Tab, Keys.Z };
    public static Keys[] Skip = new Keys[] { Keys.Escape, Keys.Enter };

    private static int InputLeftStatus = 0;
    private static int InputRightStatus = 0;
    private static int InputUpStatus = 0;
    private static int InputDownStatus = 0;
    private static int InputConfirmStatus = 0;

    public static bool InputLeftPressed()
    {
        if (PlayerState.IsKeyDown(MoveLeft[0]) || PlayerState.IsKeyDown(MoveLeft[1]))
            InputLeftStatus++;
        else
        {
            InputLeftStatus = 0;
            return false;
        }

        #region Acceleration
        if (InputLeftStatus == (int)InputStatus.FirstPress)
            return true;

        else if (InputLeftStatus <= (int)InputStatus.SecondPress)
        {
            if (InputLeftStatus % 25 == 0)
                return true;
        }
        else if (InputLeftStatus <= (int)InputStatus.ThirdPress)
        {
            if (InputLeftStatus % 20 == 0)
                return true;
        }
        else if (InputLeftStatus <= (int)InputStatus.FourthPress)
        {
            if (InputLeftStatus % 10 == 0)
                return true;
        }
        else if (InputLeftStatus <= (int)InputStatus.LastPress)
        {
            if (InputLeftStatus % 3 == 0)
                return true;
        }
        else if (InputLeftStatus % 2 == 0)
            return true;
        #endregion

        return false;
    }
    public static bool InputRightPressed()
    {
        if (PlayerState.IsKeyDown(MoveRight[0]) || PlayerState.IsKeyDown(MoveRight[1]))
            InputRightStatus++;
        else
        {
            InputRightStatus = 0;
            return false;
        }

        #region Acceleration
        if (InputRightStatus == (int)InputStatus.FirstPress)
            return true;
        else if (InputRightStatus <= (int)InputStatus.SecondPress)
        {
            if (InputRightStatus % 25 == 0)
                return true;
        }
        else if (InputRightStatus <= (int)InputStatus.ThirdPress)
        {
            if (InputRightStatus % 20 == 0)
                return true;
        }
        else if (InputRightStatus <= (int)InputStatus.FourthPress)
        {
            if (InputRightStatus % 10 == 0)
                return true;
        }
        else if (InputRightStatus <= (int)InputStatus.LastPress)
        {
            if (InputRightStatus % 3 == 0)
                return true;
        }
        else if (InputRightStatus % 2 == 0)
            return true;
        #endregion

        return false;
    }
    public static bool InputUpPressed()
    {
        if (PlayerState.IsKeyDown(MoveUp[0]) || PlayerState.IsKeyDown(MoveUp[1]))
            InputUpStatus++;
        else
        {
            InputUpStatus = 0;
            return false;
        }

        #region Acceleration
        if (InputUpStatus == (int)InputStatus.FirstPress)
            return true;
        else if (InputUpStatus <= (int)InputStatus.SecondPress)
        {
            if (InputUpStatus % 25 == 0)
                return true;
        }
        else if (InputUpStatus <= (int)InputStatus.ThirdPress)
        {
            if (InputUpStatus % 20 == 0)
                return true;
        }
        else if (InputUpStatus <= (int)InputStatus.FourthPress)
        {
            if (InputUpStatus % 10 == 0)
                return true;
        }
        else if (InputUpStatus <= (int)InputStatus.LastPress)
        {
            if (InputUpStatus % 3 == 0)
                return true;
        }
        else if (InputUpStatus % 2 == 0)
            return true;
        #endregion

        return false;
    }
    public static bool InputDownPressed()
    {
        if (PlayerState.IsKeyDown(MoveDown[0]) || PlayerState.IsKeyDown(MoveDown[1]))
            InputDownStatus++;
        else
        {
            InputDownStatus = 0;
            return false;
        }

        #region Acceleration
        if (InputDownStatus == (int)InputStatus.FirstPress)
            return true;
        else if (InputDownStatus <= (int)InputStatus.SecondPress)
        {
            if (InputDownStatus % 25 == 0)
                return true;
        }
        else if (InputDownStatus <= (int)InputStatus.ThirdPress)
        {
            if (InputDownStatus % 20 == 0)
                return true;
        }
        else if (InputDownStatus <= (int)InputStatus.FourthPress)
        {
            if (InputDownStatus % 10 == 0)
                return true;
        }
        else if (InputDownStatus <= (int)InputStatus.LastPress)
        {
            if (InputDownStatus % 3 == 0)
                return true;
        }
        else if (InputDownStatus % 2 == 0)
            return true;
        #endregion
        return false;
    }
    public static bool InputConfirmPressed()
    {
        if (PlayerState.IsKeyDown(ConfirmChoice[0]) || PlayerState.IsKeyDown(ConfirmChoice[1]))
            InputConfirmStatus++;
        else
        {
            InputConfirmStatus = 0;
            return false;
        }
        #region Acceleration
        if (InputConfirmStatus == (int)InputStatus.FirstPress)
            return true;
        else if (InputConfirmStatus <= (int)InputStatus.SecondPress)
        {
            if (InputConfirmStatus % 25 == 0)
                return true;
        }
        else if (InputConfirmStatus <= (int)InputStatus.ThirdPress)
        {
            if (InputConfirmStatus % 20 == 0)
                return true;
        }
        else if (InputConfirmStatus <= (int)InputStatus.FourthPress)
        {
            if (InputConfirmStatus % 10 == 0)
                return true;
        }
        else if (InputConfirmStatus <= (int)InputStatus.LastPress)
        {
            if (InputConfirmStatus % 3 == 0)
                return true;
        }
        else if (InputConfirmStatus % 2 == 0)
            return true;
        #endregion
        return false;
    }

    /// <summary>
    /// Determine if a key is pressed.
    /// </summary>
    /// <param name="K">The key to use for the test.</param>
    /// <returns>True if the key was found; else, false.</returns>
    public static bool KeyPressed(Keys K)
    {//If the key is currently pressed and was not already pressed before
        return PlayerState.IsKeyDown(K) && PlayerStateLast.IsKeyUp(K);
    }

    public static Keys[] KeyPressed()
    {
        return Keyboard.GetState().GetPressedKeys();
    }

    /// <summary>
    /// Determine if a key is holden.
    /// </summary>
    /// <param name="K">The key to use for the test.</param>
    /// <returns>True if the key was found; else, false.</returns>
    public static bool KeyHold(Keys K)
    {
        return PlayerState.IsKeyDown(K);
    }
}

