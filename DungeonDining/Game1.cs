using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using static System.Collections.Specialized.BitVector32;
using Color = Microsoft.Xna.Framework.Color;

namespace DungeonDining
{
    public class Game1 : Game
    {
        private static readonly int _screenWidth = 1280;
        private static readonly int _screenHeight = 960;
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        /*
        private Viewport _inventoryViewport;
        private Viewport _mapViewport;
        private Viewport _actionViewport;
        private Viewport _portraitViewport;
        private Viewport _terminalViewport;
        */
        Texture2D loopy;
        Texture2D gui;
        Texture2D tiles;
        GUI inventory;
        GUI portrait;
        GUI textBox;
        GUI camera;
        GUI action;
        Map map;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = _screenWidth;
            _graphics.PreferredBackBufferHeight = _screenHeight;
            _graphics.ApplyChanges();

            //_inventoryViewport = new Viewport(0, 00, _screenWidth, _screenHeight/6);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            loopy = Content.Load<Texture2D>("loopy");
            gui = Content.Load<Texture2D>("yion");
            tiles = Content.Load <Texture2D>("tiles");

            LoadGUI();

            
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            //Viewport original = GraphicsDevice.Viewport;


            // TODO: Add your drawing code here
            DrawGUI();
            map.Draw();


            base.Draw(gameTime);
        }


        private void DrawGUI()
        {
            inventory.Draw();
            portrait.Draw();
            textBox.Draw();
            camera.Draw();
            action.Draw();
        }

        private void LoadGUI()
        {
            Rectangle inventoryPos = new Rectangle(0, 0, _screenWidth * 4 / 6, _screenHeight / 5);
            Rectangle portraitPos = new Rectangle(_screenWidth * 4 / 6, 0, _screenWidth / 3, _screenWidth / 3);
            Rectangle textPos = new Rectangle(_screenWidth * 4 / 6, _screenWidth / 3, _screenWidth / 3, _screenHeight - _screenWidth / 3);
            Rectangle mapPos = new Rectangle(0, _screenHeight / 5, _screenWidth * 4 / 6, _screenHeight * 3 / 5);
            Rectangle actionPos = new Rectangle(0, _screenHeight * 4 / 5, _screenWidth * 4 / 6, _screenHeight / 5);


            map = new Map(ref _spriteBatch, ref tiles, mapPos);
            //map = new Map(ref _spriteBatch, ref tiles, new Rectangle(32, _screenHeight / 5, _screenWidth * 2 / 6, _screenWidth * 2 / 6));

            inventory = new GUI(ref _spriteBatch, ref gui, inventoryPos, new Rectangle(0, 0, 16 * 3, 16 * 2));
            portrait = new GUI(ref _spriteBatch, ref gui, portraitPos, new Rectangle(0, 16 * 2, 16 * 2, 16 * 2));
            textBox = new GUI(ref _spriteBatch, ref gui, textPos, new Rectangle(16 * 6, 0, 16 * 2, 16 * 3));
            camera = new GUI(ref _spriteBatch, ref gui, mapPos, new Rectangle(16 * 3, 0, 16 * 3, 16 * 2));
            action = new GUI(ref _spriteBatch, ref gui, actionPos, new Rectangle(0, 0, 16 * 3, 16 * 2));
        }

    }
}
