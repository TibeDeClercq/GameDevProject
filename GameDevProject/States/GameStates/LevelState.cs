using System;
using System.Collections.Generic;
using System.Text;

using GameDevProject.Entities;
using GameDevProject.Interfaces;
using GameDevProject.Levels;
using GameDevProject.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.States.GameStates
{
    class LevelState : IGameState
    {
        private SpriteFont font;
        private Player player;

        public LevelState(SpriteFont font)
        {
            this.font = font;
        }

        public void Update(Level level, GameTime gameTime)
        {
            foreach (Entity entity in level.entities)
            {
                entity.Update(gameTime, level.world);
                if (player == null && entity is Player)
                {
                    player = entity as Player;
                }
            }

            level.healthManager.UpdateHealth(level ,gameTime);            
        }

        public void Draw(Level level, SpriteBatch spriteBatch)
        {
            level.world.Draw(spriteBatch);

            foreach (Entity entity in level.entities)
            {
                entity.Draw(spriteBatch);
            }

            spriteBatch.DrawString(this.font, $"Score: {ScoreManager.Score}", new Vector2(32, 11), Color.White);

            if (player != null && !player.IsAttacking && player.AttackTimer != TimeSpan.Zero)
            {
                spriteBatch.DrawString(this.font, $"{Math.Floor((player.AttackCooldown - player.AttackTimer).TotalSeconds) + 1}", new Vector2(player.Position.X + (player.HitboxRectangle.Width/2), player.Position.Y - 10), Color.White);
            }
        }

        public int GetWindowHeight(Level level)
        {
            return level.world.GetWorldHeight(); //getWorldHeight
        }

        public int GetWindowWidth(Level level)
        {
            return level.world.GetWorldWidth(); //getWorldWidth
        }
    }
}
