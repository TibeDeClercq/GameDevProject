﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using GameDevProject.Entities;
using GameDevProject.Input;
using GameDevProject.Map;

namespace GameDevProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Player player;
        private Texture2D _playerTexture;

        private World world1;
        private Texture2D _worldTileset;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            player = new Player(_playerTexture, new KeyboardReader());
            
            //test to make world
            char[,] test = { { 'A', 'A', 'A', 'A', 'A', 'A' }, 
                             { 'A', 'A', 'A', 'A', 'A', 'A' },
                             { 'A', 'A', 'A', 'A', 'A', 'A' }
                            };
            world1 = new World(_worldTileset, test);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _playerTexture = Content.Load<Texture2D>("SpritesheetPlayer");
            _worldTileset = Content.Load<Texture2D>("TilesetWorld");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            player.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            //var scaleX = (float)this.GraphicsDevice.Viewport.Width / 300;
            //var scaleY = (float)this.GraphicsDevice.Viewport.Height / 200;
            //var matrix = Matrix.CreateScale(scaleX, scaleY, 1.0f);

            //_spriteBatch.Begin(transformMatrix: matrix);
            _spriteBatch.Begin();
            // TODO: Add your drawing code here
            world1.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
