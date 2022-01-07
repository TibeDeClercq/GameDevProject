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

        public LevelState(SpriteFont font)
        {
            this.font = font;
        }

        public void Update(Level level, GameTime gameTime)
        {
            foreach (Entity entity in level.entities)
            {
                entity.Update(gameTime, level.world);
            }

            level.healthManager.UpdateHealth(level ,gameTime);
        }

        public void Draw(Level level, SpriteBatch spriteBatch)
        {
            level.world.Draw(spriteBatch);

            Player player = null;

            foreach (Entity entity in level.entities)
            {
                if (entity is Player)
                {
                    player = entity as Player;
                }
                entity.Draw(spriteBatch);
            }

            spriteBatch.DrawString(this.font, $"Score: {player.Score}", new Vector2(3, 3), Color.White);            
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
