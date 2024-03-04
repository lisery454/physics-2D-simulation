using System.Collections.Generic;
using PhysicsEngine2D.Utils;
using SkiaSharp;

namespace PhysicsEngine2D.Engine.Shapes;

public abstract class Shape
{
    protected List<Vector2> _vertices;
    public Vector2 Centroid { get; protected set; }

    protected Shape(List<Vector2> vertices)
    {
        _vertices = vertices;
        Centroid = MathUtils.CalcCentroid(vertices);
    }

    public virtual void Draw(SKCanvas canvas, SKColor color)
    {
        for (var i = 1; i < _vertices.Count; i++)
        {
            DrawUtils.DrawLine(canvas, _vertices[i - 1], _vertices[i], color);
        }

        DrawUtils.DrawLine(canvas, _vertices[^1], _vertices[0], color);
        
        DrawUtils.DrawPoint(canvas, Centroid,3, color);
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