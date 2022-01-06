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
using GameDevProject.Hitboxes;
using GameDevProject.Input.EnemyAI;

namespace GameDevProject
{
    public enum State { MainMenu, Level1, Level1Complete, GameOverLevel1, Level2, Level2Complete, GameOverLevel2}
    public class Game1 : Game
    {
        private bool devMode = true;

        private RenderTarget2D gameRenderTarget;
        public static int scale = 3;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private List<Texture2D> playerTextures;
        private List<Texture2D> type1EnemyTextures;
        private List<Texture2D> type2EnemyTextures;

        private Level ActiveLevel;
        private Texture2D worldTileset;

        private SpriteFont font;

        private HitboxManager hitboxManager;

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

            this.SetFirstScreen();

            this.SetRenderer();

            this.DevView();
        }

        protected override void LoadContent()
        {
            this.AddSpriteBatch();
            this.AddTextures();
            this.AddFont();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            this.DevViewUpdate();

            this.ChangeGameState();

            this.gameState.Update(this.ActiveLevel, gameTime);

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
        private void SetFirstScreen()
        {
            Game1.State = State.MainMenu;
            this.gameState = new MainMenuState(font);
            this.LoadMainMenu();
        }
        
        private void DevView()
        {
            if (devMode)
            {
                this.hitboxManager = new HitboxManager();
                this.hitboxManager.hitboxes = new List<Hitbox>();
            }
        }

        private void LoadMainMenu()
        {
            string[,] map = {
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2"},
                                { "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3"}
                             };

            this.ActiveLevel = new Level(this.worldTileset, map);
        }

        private void LoadLevel1()
        {
            List<Entity> entities = new List<Entity>();

            Player player = new Player(this.playerTextures, new KeyboardReader(), new Vector2(1, 6));
            Type1Enemy type1Enemy = new Type1Enemy(this.type1EnemyTextures, player, new Vector2(10, 6));

            string[,] map = {
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "C2", "C2", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "F4", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2"},
                                { "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3"}
                             };            

            entities.Add(type1Enemy);
            entities.Add(player);

            this.ActiveLevel = new Level(this.worldTileset, entities, map);
        }

        private void LoadLevel2()
        {
            List<Entity> entities = new List<Entity>();

            Player player = new Player(this.playerTextures, new KeyboardReader(), new Vector2(2, 6));
            Type2Enemy type2enemy = new Type2Enemy(this.type2EnemyTextures, player, new Vector2(10, 6));

            entities.Add(type2enemy);
            entities.Add(player);

            string[,] map = {
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "C2", "C2", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "A5", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "C5", "G1"},
                                { "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2"},
                                { "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3"}
                             };

            this.ActiveLevel = new Level(this.worldTileset, entities, map);
        }
        private void LoadGameOver()
        {
            string[,] map = {
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2"},
                                { "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3"}
                             };

            this.ActiveLevel = new Level(this.worldTileset, map);
        }
        private void LoadLevelCompleted()
        {
            string[,] map = {
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2"},
                                { "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3"}
                             };

            this.ActiveLevel = new Level(this.worldTileset, map);
        }
        private void ClearLevel()
        {
            this.ActiveLevel = null;
        }
        private void SetRenderer()
        {
            this.gameRenderTarget = new RenderTarget2D(this.GraphicsDevice, this.gameState.GetWindowWidth(this.ActiveLevel), this.gameState.GetWindowHeight(this.ActiveLevel));

            this.graphics.PreferredBackBufferHeight = Game1.scale * this.gameState.GetWindowHeight(this.ActiveLevel);
            this.graphics.PreferredBackBufferWidth = Game1.scale * this.gameState.GetWindowWidth(this.ActiveLevel);
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
            this.playerTextures.Add(this.Content.Load<Texture2D>("SpritesheetsPlayer/PlayerDead"));
        }

        private void AddEnemyTextures()
        {
            this.type1EnemyTextures = new List<Texture2D>();
            this.type1EnemyTextures.Add(this.Content.Load<Texture2D>("SpritesheetsEnemies/Enemy1Walk"));
            this.type1EnemyTextures.Add(this.Content.Load<Texture2D>("SpritesheetsEnemies/Enemy1Dead"));

            this.type2EnemyTextures = new List<Texture2D>();
            this.type2EnemyTextures.Add(this.Content.Load<Texture2D>("SpritesheetsEnemies/Enemy1Walk"));
            this.type2EnemyTextures.Add(this.Content.Load<Texture2D>("SpritesheetsEnemies/Enemy1Dead"));
        }

        private void AddWorldTextures()
        {
            this.worldTileset = this.Content.Load<Texture2D>("TileSetsWorld/TilesetWorld");
        }

        private void AddFont()
        {
            this.font = Content.Load<SpriteFont>("SpriteFonts/font");
        }
        #endregion

        #region Update
        private void DevViewUpdate()
        {
            if (this.ActiveLevel != null && devMode)
            {
                this.hitboxManager.AddWantedHitboxes(this.ActiveLevel.entities, this.ActiveLevel.world, graphics);
            }
        }
        private void ChangeGameState()
        {
            switch (Game1.State)
            {
                case State.MainMenu:
                    if (this.gameState.GetType() != typeof(MainMenuState))
                    {
                        this.ClearLevel();
                        this.LoadMainMenu();
                        this.gameState = new MainMenuState(font);
                        this.SetRenderer();
                    }
                    break;
                case State.Level1:
                    if (this.gameState.GetType() != typeof(LevelState))
                    {
                        this.ClearLevel();
                        this.LoadLevel1();
                        this.gameState = new LevelState();
                        this.SetRenderer();
                    }
                    break;
                case State.Level1Complete:
                    if (this.gameState.GetType() != typeof(Level1CompletedState))
                    {
                        this.ClearLevel();
                        this.LoadLevelCompleted();
                        this.gameState = new Level1CompletedState(font);
                        this.SetRenderer();
                    }
                    break;
                case State.GameOverLevel1:
                    if (this.gameState.GetType() != typeof(GameOverLevel1State))
                    {
                        this.ClearLevel();
                        this.LoadGameOver();
                        this.gameState = new GameOverLevel1State(font);
                        this.SetRenderer();
                    }
                    break;
                case State.Level2:
                    if (this.gameState.GetType() != typeof(LevelState))
                    {
                        this.ClearLevel();
                        this.LoadLevel2();
                        this.gameState = new LevelState();
                        this.SetRenderer();
                    }
                    break;
                case State.Level2Complete:
                    if (this.gameState.GetType() != typeof(Level2CompletedState))
                    {
                        this.ClearLevel();
                        this.LoadLevelCompleted();
                        this.gameState = new Level2CompletedState(font);
                        this.SetRenderer();
                    }
                    break;
                case State.GameOverLevel2:
                    if (this.gameState.GetType() != typeof(GameOverLevel2State))
                    {
                        this.ClearLevel();
                        this.LoadGameOver();
                        this.gameState = new GameOverLevel2State(font);
                        this.SetRenderer();
                    }
                    break;
                default:
                    break;
            }
        }
        #endregion

        #region Draw
        private void DrawToFrame()
        {
            this.GraphicsDevice.SetRenderTarget(this.gameRenderTarget);
            this.GraphicsDevice.Clear(Color.CornflowerBlue);
            this.spriteBatch.Begin();

            this.gameState.Draw(this.ActiveLevel, this.spriteBatch);

            this.DrawDevView();

            this.spriteBatch.End();
        }

        private void DrawToScreen()
        {
            this.GraphicsDevice.SetRenderTarget(null);
            this.spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            this.spriteBatch.Draw(this.gameRenderTarget, new Rectangle(0, 0, Game1.scale * this.gameState.GetWindowWidth(this.ActiveLevel), Game1.scale * this.gameState.GetWindowHeight(this.ActiveLevel)), Color.White);
            
            this.spriteBatch.End();
        }

        private void DrawDevView()
        {
            if (devMode == true && ActiveLevel != null)
            {
                this.hitboxManager.DrawHitboxes(spriteBatch);
            }
        }
        #endregion
    }
}
