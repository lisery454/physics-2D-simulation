using Avalonia.Controls;
using Avalonia.Input;
using PhysicsEngine2D.Engine;

namespace PhysicsEngine2D.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Image_OnPointerPressed(object? sender, PointerPressedEventArgs e)
    {
        var image = (sender as Image)!;
        InputManager.Instance.OnMousePress(image, e);

    }

    private void Image_OnPointerMoved(object? sender, PointerEventArgs e)
    {
        var image = (sender as Image)!;
        InputManager.Instance.OnMouseMove(image, e);
    }

    private void Image_OnPointerReleased(object? sender, PointerReleasedEventArgs e)
    {
        var image = (sender as Image)!;
        InputManager.Instance.OnMouseRelease(image, e);

    }

    private void Window_OnKeyDown(object? sender, KeyEventArgs e)
    {
        var window = (sender as Window)!;
        InputManager.Instance.OnKeyDown(e.Key);
    }

    private void Window_OnKeyUp(object? sender, KeyEventArgs e)
    {
        var window = (sender as Window)!;
        InputManager.Instance.OnKeyUp(e.Key);
    }
}