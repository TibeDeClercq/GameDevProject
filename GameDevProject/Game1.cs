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

namespace GameDevProject
{
    public class Game1 : Game
    {
        private RenderTarget2D gameRenderTarget;
        private int scale = 3;

        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private List<Entity> entities;
        //private Player player;
        private List<Texture2D> playerTextures;
        private List<Texture2D> type1EnemyTextures;

        private World world1;
        private Texture2D worldTileset;

        private List<IHitbox> items;
        private List<Hitbox> hitboxes;

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

            this.AddEntities();
            this.AddWorld();
            this.SetRenderer();

            PhysicsManager.entities = this.entities;
            //PhysicsManager.tiles = this.world1. GETTILES

            this.hitboxes = new List<Hitbox>();
        }

        protected override void LoadContent()
        {
            this.AddSpriteBatch();
            this.AddTextures();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                this.Exit();
            }

            //Update entities
            this.UpdateEntities(gameTime);

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
        private void AddEntities()
        {
            this.entities = new List<Entity>();

            Player player = new Player(this.playerTextures, new KeyboardReader());
            Type1Enemy type1Enemy = new Type1Enemy(this.type1EnemyTextures);
            type1Enemy.InputReader = new Type1EnemyAI(player, type1Enemy);


            this.entities.Add(player);
            this.entities.Add(type1Enemy);
            
        }

        private void AddWorld()
        {
            string[,] test = {
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "C2", "C2", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1", "G1","G1", "G1", "G1", "G1", "G1", "G1"},
                                { "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2", "A2","A2", "A2", "A2", "A2", "A2", "A2"},
                                { "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3", "E3","E3", "E3", "E3", "E3", "E3", "E3"}
                             };

            this.world1 = new World(this.worldTileset, test);
        }

        private void SetRenderer()
        {
            this.gameRenderTarget = new RenderTarget2D(this.GraphicsDevice, this.world1.GetWorldWidth(), this.world1.GetWorldHeight());

            this.graphics.PreferredBackBufferHeight = this.scale * this.world1.GetWorldHeight(); //getWorldHeight
            this.graphics.PreferredBackBufferWidth = this.scale * this.world1.GetWorldWidth(); //getWorldWidth
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
        private void UpdateEntities(GameTime gameTime)
        {
            foreach (Entity entity in this.entities)
            {
                entity.Update(gameTime, this.world1);
            }
        }
        #endregion

        #region Draw
        private void DrawToFrame()
        {
            this.GraphicsDevice.SetRenderTarget(this.gameRenderTarget);
            this.GraphicsDevice.Clear(Color.CornflowerBlue);
            this.spriteBatch.Begin();
            //Draw world
            this.world1.Draw(this.spriteBatch);
            //Draw entities
            this.DrawEntities();

            this.DrawHitboxes();

            this.spriteBatch.End();
        }

        private void DrawToScreen()
        {
            this.GraphicsDevice.SetRenderTarget(null);
            this.spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            this.spriteBatch.Draw(this.gameRenderTarget, new Rectangle(0, 0, this.scale * this.world1.GetWorldWidth(), this.scale * this.world1.GetWorldHeight()), Color.White);
            
            this.spriteBatch.End();
        }

        private void DrawEntities()
        {
            foreach (Entity entity in this.entities)
            {
                entity.Draw(this.spriteBatch);
            }
        }

        private void DrawHitboxes()
        {
            this.GetHitboxes();

            foreach (Hitbox hitbox in hitboxes)
            {
                spriteBatch.Draw(hitbox.Texture, hitbox.Position, Color.White);
            }
        }

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
            foreach (IHitbox entity in entities)
            {
                items.Add(entity);
            }
            foreach (IHitbox tile in world1.GetTiles())
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
