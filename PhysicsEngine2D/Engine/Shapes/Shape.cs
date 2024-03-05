using System.Collections.Generic;
using PhysicsEngine2D.Utils;
using SkiaSharp;

namespace PhysicsEngine2D.Engine.Shapes;

public abstract class Shape
{
    protected List<Vector2> _vertices;
    public Vector2 Centroid { get; protected set; }

    public SKColor Color { get; set; }

    protected Shape(List<Vector2> vertices, SKColor color)
    {
        _vertices = vertices;
        Centroid = MathUtils.CalcCentroid(vertices);
        Color = color;
    }

    public virtual void Draw(SKCanvas canvas)
    {
        for (var i = 1; i < _vertices.Count; i++)
        {
            DrawUtils.DrawLine(canvas, _vertices[i - 1], _vertices[i], Color);
        }

        DrawUtils.DrawLine(canvas, _vertices[^1], _vertices[0], Color);

        DrawUtils.DrawPoint(canvas, Centroid, 3, Color);
    }

    public virtual void Move(Vector2 delta)
    {
        for (var i = 0; i < _vertices.Count; i++)
        {
            _vertices[i] += delta;
        }

        Centroid += delta;
    }

    public virtual void Rotate(float deltaRadians)
    {
        for (var i = 0; i < _vertices.Count; i++)
        {
            _vertices[i] = MathUtils.Rotate(_vertices[i], Centroid, deltaRadians);
        }
    }
}