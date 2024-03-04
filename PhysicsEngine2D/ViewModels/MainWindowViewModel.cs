using System.IO;
using Avalonia;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using PhysicsEngine2D.Engine;
using SkiaSharp;

namespace PhysicsEngine2D.ViewModels;

public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty] private ImageDrawing _image;
    [ObservableProperty] private int _height;
    [ObservableProperty] private int _width;


    public MainWindowViewModel()
    {
        _height = 720;
        _width = 1280;

        _image = new ImageDrawing
        {
            ImageSource = null,
            Rect = new Rect(0, 0, _width, _height)
        };

        var mainLooper = new MainLooper(draw: Draw, getCanvasSurface: GetCanvasSurface);
        mainLooper.Start();
    }

    private (SKCanvas canvas, SKSurface surface) GetCanvasSurface()
    {
        var imageInfo = new SKImageInfo(
            width: Width,
            height: Height,
            colorType: SKColorType.Rgba8888,
            alphaType: SKAlphaType.Premul);
        var surface = SKSurface.Create(imageInfo);
        var canvas = surface.Canvas;
        canvas.Clear(SKColor.Parse("#eeeeee"));
        return (canvas, surface);
    }

    private void Draw(SKSurface surface)
    {
        using var image = surface.Snapshot();
        using var data = image.Encode();
        using var mStream = new MemoryStream(data.ToArray());
        var bitmap = new Bitmap(mStream);
        Dispatcher.UIThread.Invoke(() =>
        {
            Image = new ImageDrawing
            {
                ImageSource = bitmap,
                Rect = new Rect(0, 0, Width, Height)
            };
        });
    }
}