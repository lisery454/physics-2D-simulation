using System;

namespace PhysicsEngine2D.Utils;

public static class TimeUtils
{
    public static DateTime GetCurrentTime()
    {
        return DateTime.Now;
    }
    
    public static double GetTimeDistance(DateTime time1, DateTime time2)
    {
        var timeSpan = time1 - time2;
        return timeSpan.TotalSeconds;
    }
}