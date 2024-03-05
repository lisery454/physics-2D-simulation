using System;

namespace PhysicsEngine2D.Engine;

public class Vector2
{
    public float X { get; set; }
    public float Y { get; set; }

    public Vector2(float x, float y)
    {
        X = x;
        Y = y;
    }


    public void Normalize()
    {
        var length = Length();
        X /= length;
        Y /= length;
    }

    public Vector2 GetNormal()
    {
        return new Vector2(Y, -X);
    }

    public float Dot(Vector2 vec)
    {
        return X * vec.X + Y * vec.Y;
    }

    public void Add(Vector2 vec)
    {
        X += vec.X;
        Y += vec.Y;
    }

    public static Vector2 operator +(Vector2 v1, Vector2 v2)
    {
        return new Vector2(v1.X + v2.X, v1.Y + v2.Y);
    }

    public void Sub(Vector2 vec)
    {
        X -= vec.X;
        Y -= vec.Y;
    }

    public static Vector2 operator -(Vector2 v1, Vector2 v2)
    {
        return new Vector2(v1.X - v2.X, v1.Y - v2.Y);
    }

    public void Scale(float scale)
    {
        X *= scale;
        Y *= scale;
    }

    public static Vector2 operator *(Vector2 v, float scale)
    {
        return new Vector2(v.X * scale, v.Y * scale);
    }

    public static Vector2 operator *(float scale, Vector2 v)
    {
        return new Vector2(v.X * scale, v.Y * scale);
    }

    public float Cross(Vector2 vec)
    {
        return X * vec.Y - Y * vec.X;
    }

    public float Length()
    {
        return (float)Math.Sqrt(LengthSquare());
    }

    public float LengthSquare()
    {
        return X * X + Y * Y;
    }

    public override string ToString()
    {
        return $"x: {X}; y: {Y}";
    }

    public Vector2 Clone()
    {
        return new Vector2(X, Y);
    }
}