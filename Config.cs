using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTemplate
{
    static class Config
    {
        public static class Window
        {
            public const int Width = 640;
            public const int Height = 480;
            public static asd.Vector2DI Size { get; } = new asd.Vector2DI(Width, Height);

            public static string Title { get; } = "Game Template";
        }

        public static bool isQuit = false;
    }
}
