using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using PhysicsEngine2D.Engine;

namespace PhysicsEngine2D.Engine;

public class InputManager
{
    private static readonly Lazy<InputManager> _instance = new(() => new InputManager());
    public static InputManager Instance => _instance.Value;

    public Vector2 MousePos { get; private set; } = new(0, 0);
    public bool IsLeftMouseDown { get; private set; }
    public bool IsRightMouseDown { get; private set; }

    public event Action<PointerPressedEventArgs>? MousePress;
    public event Action<PointerReleasedEventArgs>? MouseRelease;
    public event Action<Key>? KeyPress;
    public event Action<Key>? KeyRelease;


    public void OnMouseMove(Image image, PointerEventArgs pointerEventArgs)
    {
        var (x, y) = pointerEventArgs.GetPosition(image);
        MousePos = new Vector2((float)x, (float)y);
    }

    public void OnMousePress(Image image, PointerPressedEventArgs pointerPressedEventArgs)
    {
        var pointerPointProperties = pointerPressedEventArgs.GetCurrentPoint(image).Properties;
        if (pointerPointProperties.IsLeftButtonPressed)
        {
            IsLeftMouseDown = true;
        }

        if (pointerPointProperties.IsRightButtonPressed)
        {
            IsRightMouseDown = true;
        }

        MousePress?.Invoke(pointerPressedEventArgs);
    }

    public void OnMouseRelease(Image image, PointerReleasedEventArgs pointerReleasedEventArgs)
    {
        var initialPressMouseButton = pointerReleasedEventArgs.InitialPressMouseButton;
        if (initialPressMouseButton == MouseButton.Left)
        {
            IsLeftMouseDown = false;
        }

        if (initialPressMouseButton == MouseButton.Right)
        {
            IsRightMouseDown = false;
        }

        MouseRelease?.Invoke(pointerReleasedEventArgs);
    }

    public void OnKeyDown(Key key)
    {
        KeyPress?.Invoke(key);
    }

    public void OnKeyUp(Key key)
    {
        KeyRelease?.Invoke(key);
    }
}