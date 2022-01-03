using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using GameDevProject.Entities;
using GameDevProject.Input;
using GameDevProject.Map;
using System.Collections.Generic;
using GameDevProject.Managers;
using GameDevProject.Interfaces;
using System.Diagnostics;
using GameDevProject.Levels;
using GameDevProject.States.GameStates;

namespace GameDevProject
{
    public enum State { MainMenu, Level1}
    public class Game1 : Game
    {
        private RenderTarget2D gameRenderTarget;
        private int scale = 3;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private List<Texture2D> playerTextures;
        private List<Texture2D> type1EnemyTextures;

        private List<Level> levels;
        private Texture2D worldTileset;

        private SpriteFont font;

        //hitbox stuff
        private List<IHitbox> items;
        private List<Hitbox> hitboxes;

        private IGameState gameState;
        public static State State;

        public Game1()
        {
            this.graphics = new GraphicsDeviceManager(this);

            this.Content.RootDirectory = "Content";
            this.IsMouseVisible = true;

            this.graphics.IsFullScreen = false;
        }

        protected override void Initialize()
        {
            base.Initialize();

            this.gameState = new MainMenuState(this.font);

            this.CreateLevels();

            this.SetRenderer();

            PhysicsManager.entities = this.levels[0].entities; //aanpassen per level
            //PhysicsManager.tiles = this.world1. GETTILES

            this.hitboxes = new List<Hitbox>(); //temp
        }

        protected override void LoadContent()
        {
            this.AddSpriteBatch();
            this.AddTextures();

            //add font
            this.font = Content.Load<SpriteFont>("SpriteFonts/font");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            switch (Game1.State)
            {
                case State.MainMenu:
                    this.gameState = new MainMenuState(font);
                    this.SetRenderer();
                    break;
                case State.Level1:
                    this.gameState = new Level1State();
                    this.SetRenderer();
                    break;
                default:
                    break;
            }

            //Update depending on gamestate
            this.gameState.Update(this.levels, gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //Draw all objects to a frame
            this.DrawToFrame();
            //Draw frame to window => rescale
            this.DrawToScreen();
            base.Draw(gameTime);
        }

        #region Initialize
        private void CreateLevels()
        {
            this.levels = new List<Level>();

            this.CreateLevel1();
            this.CreateLevel2();
        }

        private void CreateLevel1()
        {
            List<Entity> entities = new List<Entity>();

            Player player = new Player(this.playerTextures, new KeyboardReader());
            Type1Enemy type1Enemy = new Type1Enemy(this.type1EnemyTextures, player);

            entities.Add(type1Enemy);
            entities.Add(player);

            string[,] map = {
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "C2", "C2", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2"},
                                { "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3"}
                             };

            this.levels.Add(new Level(this.worldTileset, entities, map));
        }

        private void CreateLevel2()
        {
            List<Entity> entities = new List<Entity>();

            Player player = new Player(this.playerTextures, new KeyboardReader());
            Type1Enemy type1Enemy = new Type1Enemy(this.type1EnemyTextures, player);

            entities.Add(type1Enemy);
            entities.Add(player);

            string[,] map = {
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "C2", "C2", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2"},
                                { "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3"}
                             };

            this.levels.Add(new Level(this.worldTileset, entities, map));
        }

        private void SetRenderer() //aanpassen per wereld
        {
            this.gameRenderTarget = new RenderTarget2D(this.GraphicsDevice, this.gameState.GetWindowWidth(levels), this.gameState.GetWindowHeight(levels));

            this.graphics.PreferredBackBufferHeight = this.scale * this.gameState.GetWindowHeight(this.levels);
            this.graphics.PreferredBackBufferWidth = this.scale * this.gameState.GetWindowWidth(this.levels);
            this.graphics.ApplyChanges();
        }
        #endregion

        #region LoadContent
        private void AddSpriteBatch()
        {
            this.spriteBatch = new SpriteBatch(this.GraphicsDevice);
        }

        private void AddTextures()
        {
            this.AddPlayerTextures();
            this.AddEnemyTextures();
            this.AddWorldTextures();
        }

        private void AddPlayerTextures()
        {
            this.playerTextures = new List<Texture2D>();

            this.playerTextures.Add(this.Content.Load<Texture2D>("SpritesheetsPlayer/PlayerIdle"));
            this.playerTextures.Add(this.Content.Load<Texture2D>("SpritesheetsPlayer/PlayerWalk"));
            this.playerTextures.Add(this.Content.Load<Texture2D>("SpritesheetsPlayer/PlayerJump"));
            this.playerTextures.Add(this.Content.Load<Texture2D>("SpritesheetsPlayer/PlayerSpin"));
            this.playerTextures.Add(this.Content.Load<Texture2D>("SpritesheetsPlayer/PlayerSleep"));
        }

        private void AddEnemyTextures()
        {
            this.type1EnemyTextures = new List<Texture2D>();

            this.type1EnemyTextures.Add(this.Content.Load<Texture2D>("SpritesheetsPlayer/PlayerIdle"));
        }

        private void AddWorldTextures()
        {
            this.worldTileset = this.Content.Load<Texture2D>("TileSetsWorld/TilesetWorld");
        }
        #endregion

        #region Update

        #endregion

        #region Draw
        private void DrawToFrame()
        {
            this.GraphicsDevice.SetRenderTarget(this.gameRenderTarget);
            this.GraphicsDevice.Clear(Color.CornflowerBlue);
            this.spriteBatch.Begin();

            //Draw world and entities depending on gamestate
            this.gameState.Draw(this.levels, this.spriteBatch);

            //this.DrawHitboxes();

            this.spriteBatch.End();
        }

        private void DrawToScreen()
        {
            this.GraphicsDevice.SetRenderTarget(null);
            this.spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            this.spriteBatch.Draw(this.gameRenderTarget, new Rectangle(0, 0, this.scale * this.gameState.GetWindowWidth(this.levels), this.scale * this.gameState.GetWindowHeight(this.levels)), Color.White);
            
            this.spriteBatch.End();
        }


        //in hitbox thingie
        private void DrawHitboxes()
        {
            this.GetHitboxes();

            foreach (Hitbox hitbox in hitboxes)
            {
                spriteBatch.Draw(hitbox.Texture, hitbox.Position, Color.White);
            }
        }
        #endregion

        //in hitbox manager??
        #region Hitbox stuff
        private void GetHitboxes()
        {
            this.hitboxes = new List<Hitbox>();
            this.items = new List<IHitbox>();

            this.AddWantedHitboxes();

            foreach (IHitbox item in items)
            {
                int itemWidth = item.HitboxRectangle.Width;
                int itemHeight = item.HitboxRectangle.Height;
                Vector2 position = new Vector2(item.HitboxRectangle.X, item.HitboxRectangle.Y);

                Texture2D texture = new Texture2D(graphics.GraphicsDevice, itemWidth, itemHeight);
                int pixels = itemWidth * itemHeight;
                Color[] outline = new Color[pixels];

                for (int i = 0; i < pixels; i++)
                {
                    if (i < itemWidth || i % itemWidth == 0 || i % itemWidth == itemWidth - 1 || i > pixels - itemWidth)
                    {
                        outline[i] = Color.White;
                    }
                    else
                    {
                        outline[i] = Color.Transparent;
                    }
                }

                texture.SetData(outline);

                hitboxes.Add(new Hitbox(texture, position));
            }
        }

        public void AddWantedHitboxes()
        {
            foreach (IHitbox entity in levels[0].entities)
            {
                items.Add(entity);
            }
            foreach (IHitbox tile in levels[0].world.GetTiles())
            {
                Tile test = (Tile)tile;
                if (test.IsTopCollide || test.IsRightCollide || test.IsLeftCollide || test.IsBottomCollide)
                {
                    items.Add(tile);
                }
            }
        }
        #endregion
    }
}
