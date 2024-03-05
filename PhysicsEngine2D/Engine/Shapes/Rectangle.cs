using System.Collections.Generic;
using SkiaSharp;

namespace PhysicsEngine2D.Engine.Shapes;

public class Rectangle : Polygon
{
    public Vector2 Position { get; }
    public float Width { get; }
    public float Height { get; }

    public Rectangle(Vector2 position, float width, float height, SKColor color) : base(
        new List<Vector2>
        {
            new(position.X - width / 2, position.Y - height / 2),
            new(position.X + width / 2, position.Y - height / 2),
            new(position.X + width / 2, position.Y + height / 2),
            new(position.X - width / 2, position.Y + height / 2),
        }, color)
    {
        Position = position;
        Width = width;
        Height = height;
    }
}