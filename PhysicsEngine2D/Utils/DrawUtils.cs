using PhysicsEngine2D.Engine;
using SkiaSharp;

namespace PhysicsEngine2D.Utils;

public static class DrawUtils
{
    private static readonly SKTypeface ChillRoundGothicRegular;

    static DrawUtils()
    {
        ChillRoundGothicRegular = SKTypeface.FromFamilyName("寒蝉圆黑体");
    }

    public static void DrawPoint(SKCanvas canvas, Vector2 position, float radius, SKColor color)
    {
        canvas.DrawCircle(position.X, position.Y, radius, new SKPaint
        {
            Color = color,
            Style = SKPaintStyle.Fill,
            IsAntialias = true,
        });
    }

    public static void DrawStrokePoint(SKCanvas canvas, Vector2 position, float radius, SKColor color)
    {
        canvas.DrawCircle(position.X, position.Y, radius, new SKPaint
        {
            Color = color,
            Style = SKPaintStyle.Stroke,
            IsAntialias = true,
            StrokeWidth = 2f,
        });
    }

    public static void DrawLine(SKCanvas canvas, Vector2 startPos, Vector2 endPos, SKColor color)
    {
        canvas.DrawLine(startPos.X, startPos.Y, endPos.X, endPos.Y, new SKPaint
        {
            Color = color,
            Style = SKPaintStyle.Stroke,
            IsAntialias = true,
            StrokeWidth = 2f,
        });
    }

    public static void DrawText(SKCanvas canvas, Vector2 position, float size, SKColor color, string text)
    {
        canvas.DrawText(text, position.X, position.Y,
            new SKFont(ChillRoundGothicRegular, size), new SKPaint
            {
                Color = color,
                Style = SKPaintStyle.Fill,
                IsAntialias = true,
                TextSize = size,
            });
    }

    public static void DrawArrow(SKCanvas canvas, Vector2 startPos, Vector2 arrowHeadPos, SKColor color)
    {
        DrawLine(canvas, startPos, arrowHeadPos, color);

        var direction = arrowHeadPos - startPos;

        direction.Normalize();
        const float arrowLen = 10f;

        var midPos = (arrowHeadPos - startPos - direction * arrowLen) + startPos;
        var normal = direction.GetNormal();
        normal.Normalize();
        normal *= arrowLen * 0.7f;

        var startPos1 = midPos + normal;
        var startPos2 = midPos - normal;

        DrawLine(canvas, startPos1, arrowHeadPos, color);
        DrawLine(canvas, startPos2, arrowHeadPos, color);
    }
}