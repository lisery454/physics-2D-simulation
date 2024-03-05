using System.Collections.Generic;
using PhysicsEngine2D.Utils;
using SkiaSharp;

namespace PhysicsEngine2D.Engine.Shapes;

public class Circle : Shape
{
    public Vector2 Position => Centroid;

    public float Radius { get; }

    public Circle(Vector2 position, float radius, SKColor color) : base(vertices: new List<Vector2>
    {
        new(position.X, position.Y),
        new(position.X + radius, position.Y),
    }, color)
    {
        Radius = radius;
        Centroid = position;
    }

    public override void Draw(SKCanvas canvas)
    {
        base.Draw(canvas);
        DrawUtils.DrawStrokePoint(canvas, Position, Radius, Color);
    }
}