using System;
using System.Collections.Generic;
using System.Diagnostics;
using Avalonia.Controls.Shapes;
using PhysicsEngine2D.Engine;

namespace PhysicsEngine2D.Utils;

public class MathUtils
{
    public static Vector2 CalcCentroid(List<Vector2> vertices)
    {
        var area = CalcArea(vertices);
        var centroidX = 0f;
        var centroidY = 0f;
        for (var i = 0; i < vertices.Count; i++)
        {
            var iNext = IndexNext(i, vertices.Count);
            var a = vertices[i].X * vertices[iNext].Y - vertices[i].Y * vertices[iNext].X;
            centroidX += a * (vertices[i].X + vertices[iNext].X);
            centroidY += a * (vertices[i].Y + vertices[iNext].Y);
        }

        centroidX /= 6 * area;
        centroidY /= 6 * area;

        return new Vector2(centroidX, centroidY);
    }

    public static float CalcArea(List<Vector2> vertices)
    {
        var area = 0f;

        for (var i = 0; i < vertices.Count; i++)
        {
            var iNext = IndexNext(i, vertices.Count);
            area += vertices[i].X * vertices[iNext].Y - vertices[i].Y * vertices[iNext].X;
        }

        return area / 2f;
    }


    public static int IndexNext(int originIndex, int arrayCount)
    {
        originIndex += 1;
        while (originIndex < 0)
        {
            originIndex += arrayCount;
        }

        return originIndex % arrayCount;
    }


    public static Vector2 Rotate(Vector2 rotatePoint, Vector2 fixedPoint, float radians)
    {
        var rotated = new Vector2(0, 0);

        var direction = rotatePoint - fixedPoint;

        rotated.X = direction.X * (float)Math.Cos(radians) - direction.Y * (float)Math.Sin(radians);
        rotated.Y = direction.X * (float)Math.Sin(radians) + direction.Y * (float)Math.Cos(radians);

        rotated += fixedPoint;

        return rotated;
    }

    public static List<Vector2> CalcNormals(List<Vector2> vertices)
    {
        var normals = new List<Vector2>();
        for (var i = 0; i < vertices.Count; i++)
        {
            var direction = vertices[IndexNext(i, vertices.Count)] - vertices[i];
            direction.Normalize();
            var normal = direction.GetNormal();
            normals.Add(normal);
        }

        return normals;
    }
}