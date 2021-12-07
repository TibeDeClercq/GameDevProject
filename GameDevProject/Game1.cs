using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using GameDevProject.Entities;
using GameDevProject.Input;
using GameDevProject.Map;
using System.Collections.Generic;
using GameDevProject.Managers;

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

            AddEntities();
            AddWorld();
            SetRenderer();

            PhysicsManager.entities = this.entities;
            //PhysicsManager.tiles = this.world1. GETTILES
        }

        protected override void LoadContent()
        {
            AddSpriteBatch();
            AddTextures();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

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

        #region Initialize
        private void AddEntities()
        {
            entities = new List<Entity>();

            entities.Add(new Player(_playerTextures, new KeyboardReader()));
        }

        private void AddWorld()
        {
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
        }

        private void SetRenderer()
        {
            _gameRenderTarget = new RenderTarget2D(GraphicsDevice, world1.GetWorldWidth(), world1.GetWorldHeight());

            _graphics.PreferredBackBufferHeight = scale * world1.GetWorldHeight(); //getWorldHeight
            _graphics.PreferredBackBufferWidth = scale * world1.GetWorldWidth(); //getWorldWidth
            _graphics.ApplyChanges();
        }
        #endregion

        #region LoadContent
        private void AddSpriteBatch()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        private void AddTextures()
        {
            AddPlayerTextures();
            AddWorldTextures();
        }

        private void AddPlayerTextures()
        {
            _playerTextures = new List<Texture2D>();

            _playerTextures.Add(Content.Load<Texture2D>("SpritesheetsPlayer/PlayerIdle"));
            _playerTextures.Add(Content.Load<Texture2D>("SpritesheetsPlayer/PlayerWalk"));
            _playerTextures.Add(Content.Load<Texture2D>("SpritesheetsPlayer/PlayerJump"));
            _playerTextures.Add(Content.Load<Texture2D>("SpritesheetsPlayer/PlayerSpin"));
            _playerTextures.Add(Content.Load<Texture2D>("SpritesheetsPlayer/PlayerSleep"));
        }

        private void AddWorldTextures()
        {
            _worldTileset = Content.Load<Texture2D>("TileSetsWorld/TilesetWorld");
        }
        #endregion

        #region Update
        private void UpdateEntities(GameTime gameTime)
        {
            foreach (Entity entity in entities)
            {
                entity.Update(gameTime);
            }
        }
        #endregion

        #region Draw
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
        #endregion
    }
}
