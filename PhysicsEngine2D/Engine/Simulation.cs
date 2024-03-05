using Avalonia.Input;
using PhysicsEngine2D.Engine.Shapes;
using SkiaSharp;
using Splat;

namespace PhysicsEngine2D.Engine;

public class Simulation
{
    public Simulation()
    {
        InputManager.Instance.KeyPress += OnKeyPress;
    }

    // private Circle _circleA = new(new Vector2(100, 300), 50, SKColors.Black);
    // private Circle _circleB = new(new Vector2(300, 300), 50, SKColors.Black);
    // private CollisionManifold? _collisionManifold;

    private Shape _polygon = new Rectangle(new Vector2(400, 400), 200, 300, SKColors.RosyBrown);

    private void OnKeyPress(Key key)
    {
        var speed = 5f;

        switch (key)
        {
            case Key.W:
                _polygon.Move(new Vector2(0, -speed));
                break;
            case Key.S:
                _polygon.Move(new Vector2(0, speed));
                break;
            case Key.D:
                _polygon.Move(new Vector2(speed, 0));
                break;
            case Key.A:
                _polygon.Move(new Vector2(-speed, 0));
                break;
            case Key.R:
                _polygon.Rotate(0.05f);
                break;
        }
    }

    public void UpdateSimulation(double deltaTime)
    {
        // _collisionManifold = CollisionDetection.CircleVsCircle(_circleA, _circleB);
        // if (_collisionManifold != null)
        // {
        //     _circleA.Color = SKColors.Red;
        //     _circleB.Color = SKColors.Red;
        //
        //     _circleB.Move(_collisionManifold.PenetrationDepth * _collisionManifold.PenetrationNormal);
        // }
        // else
        // {
        //     _circleA.Color = SKColors.Black;
        //     _circleB.Color = SKColors.Black;
        // }
    }

    public void Draw(SKCanvas canvas)
    {
        _polygon.Draw(canvas);
    }
}