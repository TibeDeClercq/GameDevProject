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

        private Level ActiveLevel;
        private Texture2D worldTileset;

        private SpriteFont font;

        //hitbox stuff
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

            Game1.State = State.MainMenu;
            this.gameState = new MainMenuState(font);

            this.SetRenderer();
            //PhysicsManager.tiles = this.world1. GETTILES
            this.hitboxManager = new HitboxManager();

            this.hitboxManager.hitboxes = new List<Hitbox>(); //temp
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

            //hitbox stuff
            if (this.ActiveLevel != null)
            {
                this.hitboxManager.AddWantedHitboxes(this.ActiveLevel.entities, this.ActiveLevel.world, graphics);
            }

            this.ChangeGameState();

            //Update depending on gamestate
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
        private void LoadLevel1()
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

            HealthManager healthManager = new HealthManager();
            EntityCollisionManager collisionManager = new EntityCollisionManager(entities, player);

            this.ActiveLevel = new Level(this.worldTileset, entities, map, healthManager, collisionManager);
        }

        private void LoadLevel2()
        {
            List<Entity> entities = new List<Entity>();

            Player player = new Player(this.playerTextures, new KeyboardReader());

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

            HealthManager healthManager = new HealthManager();
            EntityCollisionManager collisionManager = new EntityCollisionManager(entities, player);

            this.ActiveLevel = new Level(this.worldTileset, entities, map, healthManager, collisionManager);
        }

        private void ClearLevel()
        {
            this.ActiveLevel = null;
        }
        private void SetRenderer() //aanpassen per wereld
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
        private void ChangeGameState()
        {
            switch (Game1.State)
            {
                case State.MainMenu:
                    if (this.gameState.GetType() != typeof(MainMenuState))
                    {
                        this.ClearLevel();
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
                        this.gameState = new Level1CompletedState(font);
                        this.SetRenderer();
                    }
                    break;
                case State.GameOverLevel1:
                    if (this.gameState.GetType() != typeof(GameOverLevel1State))
                    {
                        this.ClearLevel();
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
                        this.gameState = new Level2CompletedState(font);
                        this.SetRenderer();
                    }
                    break;
                case State.GameOverLevel2:
                    if (this.gameState.GetType() != typeof(GameOverLevel2State))
                    {
                        this.ClearLevel();
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

            //Draw world and entities depending on gamestate
            this.gameState.Draw(this.ActiveLevel, this.spriteBatch);

            if(devMode == true && ActiveLevel != null)
            {
                this.hitboxManager.DrawHitboxes(spriteBatch);
            }

            this.spriteBatch.End();
        }

        private void DrawToScreen()
        {
            this.GraphicsDevice.SetRenderTarget(null);
            this.spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            this.spriteBatch.Draw(this.gameRenderTarget, new Rectangle(0, 0, Game1.scale * this.gameState.GetWindowWidth(this.ActiveLevel), Game1.scale * this.gameState.GetWindowHeight(this.ActiveLevel)), Color.White);
            
            this.spriteBatch.End();
        }
        #endregion
    }
}
