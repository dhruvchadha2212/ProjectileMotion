using System;
using UnityEngine;

public class PhysicsUtil
{
    public static double GetProjectileMaxHeight(double initialVelocity, double initialAngle)
    {
        return Math.Pow(initialVelocity * Math.Sin(initialAngle * Math.PI / 180), 2) / (2 * Math.Abs(Physics.gravity.y));
    }

    public static double GetProjectileRange(double initialVelocity, double initialAngle)
    {
        return Math.Pow(initialVelocity, 2) * Math.Sin(2 * initialAngle * Math.PI / 180) / Math.Abs(Physics.gravity.y);
    }

    public static double GetInitialAngleInDegrees(double deltaY, double deltaX)
    {
        return 180 * Math.Atan(deltaY / deltaX) / Math.PI;
    }
}
