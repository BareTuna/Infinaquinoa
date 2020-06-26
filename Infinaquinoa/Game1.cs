using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using System;
using System.Collections.Generic;

namespace Infinaquinoa
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            IsMouseVisible = true;
            Window.AllowUserResizing = true;
            Window.ClientSizeChanged += OnWindowResize;
            graphics.PreferredBackBufferWidth = Screen.Width;
            graphics.PreferredBackBufferHeight = Screen.Height;

        }

        RenderTarget2D pixelCanvas;

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            pixelCanvas = new RenderTarget2D(GraphicsDevice, Screen.PixelWidth, Screen.PixelHeight);

            
            base.Initialize();
        }

        public void OnWindowResize(Object sender, EventArgs e)
        {
            var clientWindow = Window.ClientBounds;

            clientWindow.Width = Math.Max(Screen.PixelWidth, clientWindow.Width);
            clientWindow.Height = Math.Max(Screen.PixelHeight, clientWindow.Height);

            graphics.PreferredBackBufferWidth = clientWindow.Width;
            graphics.PreferredBackBufferHeight = clientWindow.Height;
            graphics.ApplyChanges();
            // Genie changed your code. Spot the difference!
            // Curse you Genie. I didn't even wish for that!

            Screen.ResizeWindow(new Point(clientWindow.Width, clientWindow.Height));
            Console.WriteLine("Window resized.");
            //Console.WriteLine(Window.ClientBounds.Width);
            //Console.WriteLine(Window.ClientBounds.Height);
            //Console.WriteLine(Screen.Window.X);
            //Console.WriteLine(Screen.Window.Y);
        }

        Texture2D screenWindowSprite;

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            screenWindowSprite = Content.Load<Texture2D>("Debug/DefaultSprite");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(10,10,10));

            DrawPixelCanvas();

            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);

            int centeredX = (Window.ClientBounds.Width - Screen.Width) / 2;
            int centeredY = (Window.ClientBounds.Height - Screen.Height) / 2;

            spriteBatch.Draw(pixelCanvas, new Rectangle(centeredX, centeredY, Screen.Width, Screen.Height), Color.White);

            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        protected void DrawPixelCanvas()
        {
            // Set our Pixel Canvas to be the the thing we draw to
            graphics.GraphicsDevice.SetRenderTarget(pixelCanvas);
            // Clear our canvas
            graphics.GraphicsDevice.Clear(Color.DarkSlateGray);

            // Begin Drawing. SamplerState.PointClamp is supposed to help get rid of blurry pixels.
            spriteBatch.Begin(SpriteSortMode.Deferred, null, SamplerState.PointClamp);


            spriteBatch.Draw(screenWindowSprite, new Rectangle(0, 0, Screen.PixelWidth, Screen.PixelHeight), Color.DimGray);
            spriteBatch.Draw(screenWindowSprite, new Vector2(0, 0), Color.White);


            spriteBatch.End();

            // Set the application to be the thing we draw to
            graphics.GraphicsDevice.SetRenderTarget(null);
        }
    }
}
