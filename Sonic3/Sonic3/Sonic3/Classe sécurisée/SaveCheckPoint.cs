using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

static class SaveCheckPoint
{
    public static int CheckPointID = 1;
    public static int Life = 3;

    public static void Update(int ID)
    {
        CheckPointID = ID;
    }
}

