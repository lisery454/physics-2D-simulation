using System.Collections.Generic;
using PhysicsEngine2D.Utils;
using SkiaSharp;

namespace PhysicsEngine2D.Engine.Shapes;

public class Circle : Shape
{
    public Vector2 Position { get; }
    public float Radius { get; }

    public Circle(Vector2 position, float radius) : base(vertices: new List<Vector2>
    {
        new (position.X, position.Y),
        new (position.X + radius, position.Y),
    })
    {
        Position = position;
        Radius = radius;
        Centroid = position;
    }

    public override void Draw(SKCanvas canvas, SKColor color)
    {
        base.Draw(canvas, color);
        DrawUtils.DrawStrokePoint(canvas, Position, Radius, color);
    }
}