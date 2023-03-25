﻿using Easel;
using Easel.Graphics;
using Future.Client.csharp;
using Future.Common.csharp.scenes;
using Pie.Windowing;

GameSettings settings = new GameSettings {
    Title = "Future (WIP)",
    Icon = new Bitmap("content/bitmaps/logo/logo.bmp"),
    AutoGenerateContentDirectory = null,
    TitleBarFlags = TitleBarFlags.ShowGraphicsApi,
    VSync = false,
    Border = WindowBorder.Resizable
};

using FutureClient game = new FutureClient(settings, new Earth());
game.Run();