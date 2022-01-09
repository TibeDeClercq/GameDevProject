using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Entities;
using GameDevProject.Interfaces;
using GameDevProject.Levels;
using GameDevProject.Managers;

namespace GameDevProject.States.GameStates
{
    class LevelState : IGameState
    {
        #region Properties
        private SpriteFont font;
        private Player player;
        #endregion

        #region Constructor
        public LevelState(SpriteFont font)
        {
            ScoreManager.GameTimer = TimeSpan.Zero;
            this.font = font;
        }
        #endregion

        #region Public methods
        public void Update(Level level, GameTime gameTime)
        {
            foreach (Entity entity in level.Entities)
            {
                entity.Update(gameTime, level.World);
                if (player == null && entity is Player)
                {
                    player = entity as Player;
                }
            }

            level.HealthManager.UpdateHealth(level, gameTime);
            ScoreManager.GameTimer += gameTime.ElapsedGameTime;
        }

        public void Draw(Level level, SpriteBatch spriteBatch)
        {
            level.World.Draw(spriteBatch);

            foreach (Entity entity in level.Entities)
            {
                entity.Draw(spriteBatch);
            }

            spriteBatch.DrawString(this.font, $"Score: {ScoreManager.Score}", new Vector2(32, 11), Color.White);
            spriteBatch.DrawString(this.font, $"Time: {Math.Round(ScoreManager.GameTimer.TotalSeconds, 2)}", new Vector2((level.World.GetWorldWidth() - 80), 11), Color.White);

            if (player != null && !player.IsAttacking && player.AttackTimer != TimeSpan.Zero)
            {
                spriteBatch.DrawString(this.font, $"{Math.Floor((player.AttackCooldown - player.AttackTimer).TotalSeconds) + 1}", new Vector2(player.Position.X + (player.HitboxRectangle.Width / 2), player.Position.Y - 10), Color.White);
            }
        }

        public int GetWindowHeight(Level level)
        {
            return level.World.GetWorldHeight();
        }

        public int GetWindowWidth(Level level)
        {
            return level.World.GetWorldWidth();
        }
        #endregion
    }
}
