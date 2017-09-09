using System;

public static class ActionHelper
{
    public static void SafeInvoke(this Action aAction)
    {
        if (aAction == null)
        {
            return;
        }

        aAction.Invoke();
    }
}

