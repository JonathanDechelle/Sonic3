using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

public static class RectangleHelper
{
    #region First RectangleHelper
    const int PenetrationMargin = 13;
    public static bool isOnTopOf(this Rectangle r1, Rectangle r2)
    {
        return (r1.Bottom >= r2.Top - PenetrationMargin &&
            r1.Bottom <= r2.Top + 1 &&
            r1.Right >= r2.Left + PenetrationMargin &&
            r1.Left <= r2.Right - PenetrationMargin);
    }

    public static bool isOnBottomOf(this Rectangle r1, Rectangle r2)
    {
        return (r1.Top < r2.Bottom + PenetrationMargin &&
            r1.Top > r2.Bottom - 1 &&
          r1.Right >= r2.Left + PenetrationMargin &&
            r1.Left <= r2.Right - PenetrationMargin);
    }

    public static bool isOnRightOf(this Rectangle r1, Rectangle r2)
    {
        return (r1.Top < r2.Bottom + PenetrationMargin &&
         r1.Bottom > r2.Top + 1 &&
         r1.Left >= r2.Right - 1 &&
         r1.Left <= r2.Right + 1);
    }

    public static bool isOnLeftOf(this Rectangle r1, Rectangle r2)
    {
        return (r1.Top < r2.Bottom + PenetrationMargin &&
          r1.Bottom > r2.Top + 1 &&
          r1.Right >= r2.Left - 1 &&
          r1.Right <= r2.Left + PenetrationMargin);
    }
    #endregion
}

