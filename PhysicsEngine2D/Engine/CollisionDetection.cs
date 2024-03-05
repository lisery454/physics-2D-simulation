using PhysicsEngine2D.Engine.Shapes;

namespace PhysicsEngine2D.Engine;

public class CollisionDetection
{
    public static CollisionManifold? CircleVsCircle(Circle circleA, Circle circleB)
    {
        var distance = circleA.Centroid - circleB.Centroid;
        var radiusSum = circleA.Radius + circleB.Radius;
        if (distance.LengthSquare() <= radiusSum * radiusSum)
        {
            var penetrationNormal = circleB.Centroid - circleA.Centroid;
            penetrationNormal.Normalize();
            var penetrationDepth = radiusSum - distance.Length();
            var penetrationPoint = circleA.Centroid + penetrationNormal * circleA.Radius;

            return new CollisionManifold(penetrationDepth, penetrationNormal, penetrationPoint);
        }

        return null;
    }
}