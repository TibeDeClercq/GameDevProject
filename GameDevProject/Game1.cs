using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using GameDevProject.Entities;
using GameDevProject.Input;
using System.Collections.Generic;
using GameDevProject.Managers;
using GameDevProject.Interfaces;
using GameDevProject.Levels;
using GameDevProject.States.GameStates;
using GameDevProject.Hitboxes;
using Microsoft.Xna.Framework.Audio;

namespace GameDevProject
{
    //public gamestate enum to change the gamestate in other classes
    public enum State { MainMenu, Level1, Level1Complete, GameOverLevel1, Level2, Level2Complete, GameOverLevel2}
    public class Game1 : Game
    {
        //Devmode => show hitboxes
        private bool devMode = false;

        //Scale => Size of the game
        public static float Scale = 2.5f;

        //Managers
        private HitboxManager hitboxManager;
        private LevelManager levelManager;
        private GraphicsDeviceManager graphics;

        //RenderTarget
        private RenderTarget2D gameRenderTarget;

        //SpriteBatch
        private SpriteBatch spriteBatch;

        //Textures
        private Texture2D worldTileset;
        private List<Texture2D> playerTextures;
        private List<Texture2D> type1EnemyTextures;
        private List<Texture2D> type2EnemyTextures;
        private List<Texture2D> coinTextures;

        //Active level
        private Level ActiveLevel;
        
        //Fonts
        private SpriteFont font;
        private SpriteFont scoreFont;

        //Gamestate
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
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }
            this.DevViewUpdate(); //If devView is true, show hitboxes
            this.ChangeGameState();
            this.gameState.Update(this.ActiveLevel, gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            this.DrawToFrame();
            this.DrawToScreen();
            base.Draw(gameTime);
        }

        #region Initialize
        private void SetFirstScreen()
        {
            this.levelManager = new LevelManager();

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
            this.ActiveLevel = new Level(this.worldTileset, levelManager.GetMainMenuMap());
        }

        private void LoadLevel1()
        {
            List<Entity> entities = new List<Entity>();

            Player player = new Player(this.playerTextures, new KeyboardReader(), new Vector2(3, 19));

            entities.Add(player);
            entities.AddRange(levelManager.GetLevel1Enemies(player, type1EnemyTextures, type2EnemyTextures));
            entities.AddRange(levelManager.GetLevel1Coins(coinTextures));
            
            this.ActiveLevel = new Level(this.worldTileset, entities, levelManager.GetLevel1Map());
        }

        private void LoadLevel2()
        {
            List<Entity> entities = new List<Entity>();

            Player player = new Player(this.playerTextures, new KeyboardReader(), new Vector2(3, 19));

            entities.Add(player);
            entities.AddRange(levelManager.GetLevel2Enemies(player, type1EnemyTextures, type2EnemyTextures));
            entities.AddRange(levelManager.GetLevel2Coins(coinTextures));

            this.ActiveLevel = new Level(this.worldTileset, entities, levelManager.GetLevel2Map());
        }

        private void LoadGameOver()
        {
            this.ActiveLevel = new Level(this.worldTileset, levelManager.GetGameOverMap());
        }
        private void LoadLevelCompleted()
        {
            this.ActiveLevel = new Level(this.worldTileset, levelManager.GetLevelCompletedMap());
        }
        private void ClearLevel()
        {
            this.ActiveLevel = null;
        }
        private void SetRenderer()
        {
            if (this.gameRenderTarget != null)
            {
                this.gameRenderTarget.Dispose();
            }

            this.gameRenderTarget = new RenderTarget2D(this.GraphicsDevice, this.gameState.GetWindowWidth(this.ActiveLevel), this.gameState.GetWindowHeight(this.ActiveLevel));

            this.graphics.PreferredBackBufferHeight = (int)System.Math.Round((decimal)(Game1.Scale * this.gameState.GetWindowHeight(this.ActiveLevel)));
            this.graphics.PreferredBackBufferWidth = (int)System.Math.Round((decimal)(Game1.Scale * this.gameState.GetWindowWidth(this.ActiveLevel)));
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
            this.type1EnemyTextures.Add(this.Content.Load<Texture2D>("SpritesheetsEnemies/Enemy1Walk"));
            this.type1EnemyTextures.Add(this.Content.Load<Texture2D>("SpritesheetsEnemies/Enemy1Dead"));
            this.type1EnemyTextures.Add(this.Content.Load<Texture2D>("SpritesheetsEnemies/Enemy1Idle"));

            this.type2EnemyTextures = new List<Texture2D>();
            this.type2EnemyTextures.Add(this.Content.Load<Texture2D>("SpritesheetsEnemies/Enemy2Walk"));
            this.type2EnemyTextures.Add(this.Content.Load<Texture2D>("SpritesheetsEnemies/Enemy2Dead"));
            this.type2EnemyTextures.Add(this.Content.Load<Texture2D>("SpritesheetsEnemies/Enemy2Idle"));
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
                this.hitboxManager.AddWantedHitboxes(this.ActiveLevel.Entities, this.ActiveLevel.World, graphics);
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
            this.spriteBatch.Draw(this.gameRenderTarget, new Rectangle(0, 0, (int)System.Math.Round((decimal)(Game1.Scale * this.gameState.GetWindowWidth(this.ActiveLevel))), (int)System.Math.Round((decimal)(Game1.Scale * this.gameState.GetWindowHeight(this.ActiveLevel)))), Color.White);
            
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
