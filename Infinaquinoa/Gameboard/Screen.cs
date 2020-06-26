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

        public static int PixelWidth { get; } = 320;
        public static int PixelHeight { get; } = 180;

        public static int Width { get { return _window.X; } }
        public static int Height { get { return _window.Y; } }


        public static int ResolutionWidth
        {
            get { return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width; }
        }
        public static int ResolutionHeight
        {
            get { return GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height; }
        }


        private static readonly Point preferredStartingResolution = new Point(ResolutionWidth - 1, ResolutionHeight - 1);

        private static Point _window = ToNearestRatio(new Point(PixelWidth, PixelHeight), preferredStartingResolution);

        


        /// <summary>
        /// This only changes the window variable. Use this in combination with void OnResize in Game1.cs
        /// </summary>
        public static void ResizeWindow(Point targetResolution)
        {
            _window = ToNearestRatio(new Point(PixelWidth, PixelHeight), targetResolution);
        }

        public static Point ToNearestRatio(Point p1, Point p2)
        {
            int r = Math.Min(p2.X / p1.X, p2.Y / p1.Y);
            return new Point(p1.X * r, p1.Y * r);
        }

    }



}
