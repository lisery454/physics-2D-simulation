using PhysicsEngine2D.Utils;
using SkiaSharp;

namespace PhysicsEngine2D.Engine;

public class CollisionManifold
{
    public float PenetrationDepth { get; }
    public Vector2 PenetrationNormal { get; }
    public Vector2 PenetrationPoint { get; }

    public CollisionManifold(float penetrationDepth, Vector2 penetrationNormal, Vector2 penetrationPoint)
    {
        PenetrationDepth = penetrationDepth;
        PenetrationNormal = penetrationNormal;
        PenetrationPoint = penetrationPoint;
    }


    public void Draw(SKCanvas canvas)
    {
        var startPoint = PenetrationPoint - PenetrationNormal * PenetrationDepth;

        DrawUtils.DrawArrow(canvas, startPoint, PenetrationPoint, SKColors.Aquamarine);
        DrawUtils.DrawPoint(canvas, PenetrationNormal, 3, SKColors.Gray);
    }
}