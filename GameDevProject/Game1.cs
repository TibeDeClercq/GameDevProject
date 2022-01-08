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
using Microsoft.Xna.Framework.Audio;

namespace GameDevProject
{
    public enum State { MainMenu, Level1, Level1Complete, GameOverLevel1, Level2, Level2Complete, GameOverLevel2}
    public class Game1 : Game
    {
        private bool devMode = true;

        private RenderTarget2D gameRenderTarget;
        public static float scale = 2.5f;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private List<Texture2D> playerTextures;
        private List<Texture2D> type1EnemyTextures;
        private List<Texture2D> type2EnemyTextures;
        private List<Texture2D> coinTextures;

        private Level ActiveLevel;
        private Texture2D worldTileset;

        private SpriteFont font;
        private SpriteFont scoreFont;

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
            this.AddSounds();
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
                                { "A1", "A2", "A2", "A2", "A2", "A2", "A3", "A1", "A2", "A2", "A2", "A2", "A2", "A3", "A1", "A2", "A2", "A2", "A2", "A2", "A3"},
                                { "B1", "E1", "C2", "C2", "C2", "C2", "C3", "C1", "C2", "C2", "C2", "C2", "C2", "C3", "C1", "C2", "C2", "C2", "C2", "E2", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "A1", "A2", "A2", "A3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "A1", "A2", "A2", "A3", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "C1", "C2", "C2", "C3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "C1", "C2", "C2", "C3", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "F1", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "F2", "B3"},
                                { "C1", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C3"}
                             };

            this.ActiveLevel = new Level(this.worldTileset, map);
        }

        private void LoadLevel1()
        {
            List<Entity> entities = new List<Entity>();

            Player player = new Player(this.playerTextures, new KeyboardReader(), new Vector2(1, 6));
            Type1Enemy type1Enemy = new Type1Enemy(this.type1EnemyTextures, player, new Vector2(10, 6));
            Coin coin1 = new Coin(this.coinTextures, new Vector2(7, 5));

            string[,] map = {
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "C2", "C2", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "C1", "C2", "D5", "D6", "D7", "C2", "C3", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "F4", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2"},
                                { "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3"}
                             };            

            entities.Add(type1Enemy);
            entities.Add(coin1);
            entities.Add(player);

            this.ActiveLevel = new Level(this.worldTileset, entities, map);
        }

        private void LoadLevel2()
        {
            List<Entity> entities = new List<Entity>();

            Player player = new Player(this.playerTextures, new KeyboardReader(), new Vector2(2, 6));
            Type2Enemy type2enemy = new Type2Enemy(this.type2EnemyTextures, player, new Vector2(10, 6));
            Coin coin1 = new Coin(this.coinTextures, new Vector2(7, 5));

            entities.Add(type2enemy);
            entities.Add(coin1);
            entities.Add(player);

            string[,] map = {
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "C2", "C2", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "A1", "A2", "A2", "A3", "D5", "D6", "D7", "A1", "A2","A3", "G1", "G1", "G1", "A5", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "C5", "G1"},
                                { "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2"},
                                { "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3"}
                             };

            this.ActiveLevel = new Level(this.worldTileset, entities, map);
        }
        private void LoadGameOver()
        {
            string[,] map = {
                                { "A1", "A2", "A2", "A2", "A2", "A3", "A1", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A3", "A1", "A2", "A2", "A2", "A2", "A3"},
                                { "B1", "E1", "C2", "C2", "C2", "C3", "B1", "E4", "E4", "E4", "E4", "E4", "E4", "E4", "B3", "C1", "C2", "C2", "C2", "E2", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "C1", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C3", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "A1", "A2", "A2", "A3", "G1", "G1", "G1", "G1", "G1", "A1", "A2", "A2", "A2", "A2", "A3", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "C1", "C2", "C2", "C3", "G1", "G1", "G1", "G1", "G1", "C1", "C2", "C2", "C2", "C2", "C3", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "F1", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "F2", "B3"},
                                { "C1", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C3"}
                             };

            this.ActiveLevel = new Level(this.worldTileset, map);
        }
        private void LoadLevelCompleted()
        {
            string[,] map = {
                                { "A1", "A2", "A2", "A2", "A2", "A3", "A1", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A3", "A1", "A2", "A2", "A2", "A2", "A3"},
                                { "B1", "E1", "C2", "C2", "C2", "C3", "B1", "E4", "E4", "E4", "E4", "E4", "E4", "E4", "B3", "C1", "C2", "C2", "C2", "E2", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "C1", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C3", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "A1", "A2", "A2", "A2", "A3", "G1", "G1", "G1", "G1", "A1", "A2", "A2", "A2", "A2", "A3", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "C1", "C2", "C2", "C2", "C3", "G1", "G1", "G1", "G1", "C1", "C2", "C2", "C2", "C2", "C3", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "B3", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "B1", "B3"},
                                { "B1", "F1", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "F2", "B3"},
                                { "C1", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C2", "C3"}
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

            this.graphics.PreferredBackBufferHeight = (int)System.Math.Round((decimal)(Game1.scale * this.gameState.GetWindowHeight(this.ActiveLevel)));
            this.graphics.PreferredBackBufferWidth = (int)System.Math.Round((decimal)(Game1.scale * this.gameState.GetWindowWidth(this.ActiveLevel)));
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
            this.AddItemTextures();
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
            this.type1EnemyTextures.Add(this.Content.Load<Texture2D>("SpritesheetsEnemies/Enemy2Walk"));
            this.type1EnemyTextures.Add(this.Content.Load<Texture2D>("SpritesheetsEnemies/Enemy2Dead"));
            this.type1EnemyTextures.Add(this.Content.Load<Texture2D>("SpritesheetsEnemies/Enemy2Idle"));

            this.type2EnemyTextures = new List<Texture2D>();
            this.type2EnemyTextures.Add(this.Content.Load<Texture2D>("SpritesheetsEnemies/Enemy1Walk"));
            this.type2EnemyTextures.Add(this.Content.Load<Texture2D>("SpritesheetsEnemies/Enemy1Dead"));
            this.type2EnemyTextures.Add(this.Content.Load<Texture2D>("SpritesheetsEnemies/Enemy1Idle"));
        }

        private void AddItemTextures()
        {
            this.coinTextures = new List<Texture2D>();
            this.coinTextures.Add(this.Content.Load<Texture2D>("SpritesheetsCoin/Coin"));
        }

        private void AddWorldTextures()
        {
            this.worldTileset = this.Content.Load<Texture2D>("TileSetsWorld/TilesetWorld");
        }

        private void AddFont()
        {
            this.font = Content.Load<SpriteFont>("SpriteFonts/font");
            this.scoreFont = Content.Load<SpriteFont>("SpriteFonts/ScoreFont");
        }

        private void AddSounds()
        {
            SoundManager.SoundEffects = new List<SoundEffect>();
            SoundManager.SoundEffects.Add(this.Content.Load<SoundEffect>("SoundEffects/CoinSound"));
            SoundManager.SoundEffects.Add(this.Content.Load<SoundEffect>("SoundEffects/Spike"));
            SoundManager.SoundEffects.Add(this.Content.Load<SoundEffect>("SoundEffects/JumpSound"));
            SoundManager.SoundEffects.Add(this.Content.Load<SoundEffect>("SoundEffects/EnemyJumpSound"));
            SoundManager.SoundEffects.Add(this.Content.Load<SoundEffect>("SoundEffects/SpinSound"));
            SoundManager.SoundEffects.Add(this.Content.Load<SoundEffect>("SoundEffects/DeathSound"));
            SoundManager.SoundEffects.Add(this.Content.Load<SoundEffect>("SoundEffects/WinSound"));
            SoundManager.SoundEffects.Add(this.Content.Load<SoundEffect>("SoundEffects/LoseSound"));
            SoundManager.SoundEffects.Add(this.Content.Load<SoundEffect>("SoundEffects/WalkSound"));
            SoundManager.SoundEffects.Add(this.Content.Load<SoundEffect>("SoundEffects/WalkSound"));
            SoundManager.SoundEffects.Add(this.Content.Load<SoundEffect>("SoundEffects/DungeonSound"));
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
                        SoundManager.StopSound(Sound.Dungeon);
                        this.gameState = new MainMenuState(font);
                        this.SetRenderer();
                    }
                    break;
                case State.Level1:
                    if (this.gameState.GetType() != typeof(LevelState))
                    {
                        this.ClearLevel();
                        this.LoadLevel1();
                        SoundManager.PlaySound(Sound.Dungeon);
                        this.gameState = new LevelState(scoreFont);
                        this.SetRenderer();
                    }
                    break;
                case State.Level1Complete:
                    if (this.gameState.GetType() != typeof(Level1CompletedState))
                    {
                        this.ClearLevel();
                        this.LoadLevelCompleted();
                        SoundManager.PlaySound(Sound.Victory);
                        SoundManager.StopSound(Sound.PlayerWalk);
                        SoundManager.StopSound(Sound.EnemyWalk);
                        SoundManager.StopSound(Sound.Dungeon);
                        this.gameState = new Level1CompletedState(font);
                        this.SetRenderer();
                    }
                    break;
                case State.GameOverLevel1:
                    if (this.gameState.GetType() != typeof(GameOverLevel1State))
                    {
                        this.ClearLevel();
                        this.LoadGameOver();
                        SoundManager.PlaySound(Sound.Defeat);
                        SoundManager.StopSound(Sound.PlayerWalk);
                        SoundManager.StopSound(Sound.EnemyWalk);
                        SoundManager.StopSound(Sound.Dungeon);
                        this.gameState = new GameOverLevel1State(font);
                        this.SetRenderer();
                    }
                    break;
                case State.Level2:
                    if (this.gameState.GetType() != typeof(LevelState))
                    {
                        this.ClearLevel();
                        this.LoadLevel2();
                        SoundManager.PlaySound(Sound.Dungeon);
                        this.gameState = new LevelState(scoreFont);
                        this.SetRenderer();
                    }
                    break;
                case State.Level2Complete:
                    if (this.gameState.GetType() != typeof(Level2CompletedState))
                    {
                        this.ClearLevel();
                        this.LoadLevelCompleted();
                        SoundManager.PlaySound(Sound.Victory);
                        SoundManager.StopSound(Sound.PlayerWalk);
                        SoundManager.StopSound(Sound.EnemyWalk);
                        SoundManager.StopSound(Sound.Dungeon);
                        this.gameState = new Level2CompletedState(font);
                        this.SetRenderer();
                    }
                    break;
                case State.GameOverLevel2:
                    if (this.gameState.GetType() != typeof(GameOverLevel2State))
                    {
                        this.ClearLevel();
                        this.LoadGameOver();
                        SoundManager.PlaySound(Sound.Defeat);
                        SoundManager.StopSound(Sound.EnemyWalk);
                        SoundManager.StopSound(Sound.PlayerWalk);
                        SoundManager.StopSound(Sound.Dungeon);
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
            this.spriteBatch.Draw(this.gameRenderTarget, new Rectangle(0, 0, (int)System.Math.Round((decimal)(Game1.scale * this.gameState.GetWindowWidth(this.ActiveLevel))), (int)System.Math.Round((decimal)(Game1.scale * this.gameState.GetWindowHeight(this.ActiveLevel)))), Color.White);
            
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
