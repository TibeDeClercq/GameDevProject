using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using GameDevProject.Entities;
using GameDevProject.Input;
using GameDevProject.Map;
using System.Collections.Generic;

namespace GameDevProject
{
    public class Game1 : Game
    {
        private RenderTarget2D _gameRenderTarget;
        private int scale = 3;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private List<Entity> entities;
        //private Player player;
        private List<Texture2D> _playerTextures;

        private World world1;
        private Texture2D _worldTileset;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.IsFullScreen = false;
        }

        protected override void Initialize()
        {
            base.Initialize();

            entities = new List<Entity>();
            entities.Add(new Player(_playerTextures, new KeyboardReader()));
            
            //test to make world
            string[,] test = {
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2"},
                                { "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3"}
                             };

            world1 = new World(_worldTileset, test);

            _gameRenderTarget = new RenderTarget2D(GraphicsDevice, world1.GetWorldWidth(), world1.GetWorldHeight());

            _graphics.PreferredBackBufferHeight = scale * world1.GetWorldHeight(); //getWorldHeight
            _graphics.PreferredBackBufferWidth = scale * world1.GetWorldWidth(); //getWorldWidth
            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _playerTextures = new List<Texture2D>();

            _playerTextures.Add(Content.Load<Texture2D>("SpritesheetsPlayer/PlayerWalking"));
            _playerTextures.Add(Content.Load<Texture2D>("SpritesheetsPlayer/PlayerIdle"));

            _worldTileset = Content.Load<Texture2D>("TileSetsWorld/TilesetWorld");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Update entities
            UpdateEntities(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //Draw all objects to a frame
            DrawToFrame();
            //Draw frame to window => rescale
            DrawToScreen();
            base.Draw(gameTime);
        }



        private void DrawToFrame()
        {
            GraphicsDevice.SetRenderTarget(_gameRenderTarget);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            //Draw world
            world1.Draw(_spriteBatch);
            //Draw entities
            DrawEntities();
            _spriteBatch.End();
        }

        private void DrawToScreen()
        {
            GraphicsDevice.SetRenderTarget(null);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(_gameRenderTarget, new Rectangle(0, 0, scale * world1.GetWorldWidth(), scale * world1.GetWorldHeight()), Color.White);
            _spriteBatch.End();
        }

        private void DrawEntities()
        {
            foreach (Entity entity in entities)
            {
                entity.Draw(_spriteBatch);
            }
        }

        private void UpdateEntities(GameTime gameTime)
        {
            foreach (Entity entity in entities)
            {
                entity.Update(gameTime);
            }
        }
    }
}
