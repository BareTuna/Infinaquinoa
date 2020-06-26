using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infinaquinoa
{
    class Screen
    {
        // These to change the pixel canvas' size.
        // Defaulted to 320x180 (16:9) 
        private static readonly int _pixelWindowWidth = 320;
        private static readonly int _pixelWindowHeight = 180;

        public static int Width { get { return _window.X; } }
        public static int Height { get { return _window.Y; } }

        public static int PixelWidth { get { return _pixelWindowWidth; } }
        public static int PixelHeight { get { return _pixelWindowHeight; } }

        public static int ResolutionWidth { get { return ScreenResolution.X; } }
        public static int ResolutionHeight { get { return ScreenResolution.Y; } }


        private static readonly Point preferredStartingResolution = new Point(ResolutionWidth - 1, ResolutionHeight - 1);

        private static Point _window = ToNearestRatio(PixelWindow, preferredStartingResolution);

        

        private static Point ScreenResolution
        {
            get
            {
                return new Point(//320, 180);
                    GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width,
                    GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height
                    );
            }
        }


        private static Point PixelWindow
        {
            get
            {
                return new Point(_pixelWindowWidth, _pixelWindowHeight);
            }
        }


        /// <summary>
        /// This only changes the window variable. Use this in combination with void OnResize in Game1.cs
        /// </summary>
        public static void ResizeWindow(Point targetResolution)
        {
            _window = ToNearestRatio(PixelWindow, targetResolution);
        }

        public static Point ToNearestRatio(Point p1, Point p2)
        {
            int r = Math.Min(p2.X / p1.X, p2.Y / p1.Y);
            return new Point(p1.X * r, p1.Y * r);
        }

    }



}
