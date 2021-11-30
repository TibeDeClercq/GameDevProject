using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using GameDevProject.Entities;
using GameDevProject.Input;
using GameDevProject.Map;

namespace GameDevProject
{
    public class Game1 : Game
    {
        private RenderTarget2D _gameRenderTarget;
        private int scale = 3;

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

            _graphics.IsFullScreen = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            player = new Player(_playerTexture, new KeyboardReader());
            
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
            GraphicsDevice.SetRenderTarget(_gameRenderTarget);
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            world1.Draw(_spriteBatch);
            player.Draw(_spriteBatch);
            _spriteBatch.End();

            //renders to window
            DrawToScreen();

            base.Draw(gameTime);
        }

        private void DrawToScreen()
        {
            GraphicsDevice.SetRenderTarget(null);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(_gameRenderTarget, new Rectangle(0, 0, scale * world1.GetWorldWidth(), scale * world1.GetWorldHeight()), Color.White);
            _spriteBatch.End();
        }
    }
}
