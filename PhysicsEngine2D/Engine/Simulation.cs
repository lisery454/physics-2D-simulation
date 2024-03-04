using System;
using Avalonia.Input;
using PhysicsEngine2D.Engine.Shapes;
using SkiaSharp;

namespace PhysicsEngine2D.Engine;

public class Simulation
{
    public Simulation()
    {
        InputManager.Instance.KeyPress += OnKeyPress;
    }
    
    private Rectangle _rectangle =  new(new Vector2(400, 400), 500, 250);

    private void OnKeyPress(Key key)
    {
        var speed = 5f;

        switch (key)
        {
            case Key.W: _rectangle.Move(new Vector2(0, -speed)); break;
            case Key.S: _rectangle.Move(new Vector2(0, speed)); break;
            case Key.D: _rectangle.Move(new Vector2(speed, 0)); break;
            case Key.A: _rectangle.Move(new Vector2(-speed, 0)); break;
            case Key.R: _rectangle.Rotate(0.05f); break;
            default:
                throw new ArgumentOutOfRangeException(nameof(key), key, null);
        }
    }

    public void UpdateSimulation(double deltaTime)
    {
        // var mousePos = InputManager.Instance.MousePos;
        // Debug.WriteLine($"{mousePos.X} {mousePos.Y}");
    }

    public void Draw(SKCanvas canvas)
    {
        _rectangle.Draw(canvas, SKColors.Black);
    }
}