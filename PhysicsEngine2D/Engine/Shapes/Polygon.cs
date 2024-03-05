using System.Collections.Generic;
using PhysicsEngine2D.Utils;
using SkiaSharp;

namespace PhysicsEngine2D.Engine.Shapes;

public class Polygon : Shape
{
    public List<Vector2> Normals { get; private set; }

    public Polygon(List<Vector2> vertices, SKColor color) : base(vertices, color)
    {
        Normals = MathUtils.CalcNormals(vertices);
    }

    public override void Rotate(float deltaRadians)
    {
        base.Rotate(deltaRadians);
        Normals = MathUtils.CalcNormals(_vertices);
    }


    public override void Draw(SKCanvas canvas)
    {
        base.Draw(canvas);

        for (var i = 0; i < Normals.Count; i++)
        {
            var begin = (_vertices[i] + _vertices[MathUtils.IndexNext(i, _vertices.Count)]) * 0.5f;
            var end = begin + Normals[i] * 15;

            DrawUtils.DrawLine(canvas, begin, end, Color);
        }
    }
}