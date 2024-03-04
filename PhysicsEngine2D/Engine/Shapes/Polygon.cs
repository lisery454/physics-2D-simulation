using System.Collections.Generic;
using PhysicsEngine2D.Utils;
using SkiaSharp;

namespace PhysicsEngine2D.Engine.Shapes;

public class Polygon : Shape
{
    public Polygon(List<Vector2> vertices) : base(vertices)
    {
    }
    
}