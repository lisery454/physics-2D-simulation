using System;
using System.Threading;
using PhysicsEngine2D.Engine;
using PhysicsEngine2D.Utils;
using SkiaSharp;

namespace PhysicsEngine2D.Engine;

public class MainLooper
{
    private Simulation _simulation = new();
    public Action<SKSurface> Draw { get; }
    public Func<ValueTuple<SKCanvas, SKSurface>> GetCanvasSurface { get; }

    public MainLooper(Action<SKSurface> draw, Func<ValueTuple<SKCanvas, SKSurface>> getCanvasSurface)
    {
        Draw = draw;
        GetCanvasSurface = getCanvasSurface;
    }

    public void Start()
    {
        _simulation = new Simulation();
        new Thread(() =>
        {
            Thread.CurrentThread.IsBackground = true;
            MainLoop();
        }).Start();
    }

    private void MainLoop()
    {
        const int fps = 60;
        const double secondsPerFrame = 1d / fps; // seconds
        var lastTime = TimeUtils.GetCurrentTime();

        while (true)
        {
            var currentTime = TimeUtils.GetCurrentTime();
            var deltaTime = TimeUtils.GetTimeDistance(currentTime, lastTime); // seconds

            if (deltaTime < secondsPerFrame)
            {
                Thread.Sleep(TimeSpan.FromSeconds(secondsPerFrame - deltaTime));
                deltaTime = secondsPerFrame;
            }

            lastTime = TimeUtils.GetCurrentTime();

            _simulation.UpdateSimulation(deltaTime);
            var (canvas, surface) = GetCanvasSurface();
            _simulation.Draw(canvas);
            Draw(surface);
        }
        // ReSharper disable once FunctionNeverReturns
    }
}