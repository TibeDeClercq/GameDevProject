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
    class Level1State : IGameState
    {
        public void Update(Level level, GameTime gameTime)
        {
            foreach (Entity entity in level.entities)
            {
                entity.Update(gameTime, level.world);
            }

            level.healthManager.UpdateHealth(level.collisionManager);
            ClearDeadEntities(level);
        }

        public void Draw(Level level, SpriteBatch spriteBatch)
        {
            level.world.Draw(spriteBatch);

            foreach (Entity entity in level.entities)
            {
                entity.Draw(spriteBatch);
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

        private void ClearDeadEntities(Level level)
        {
            var entities = new List<Entity>(level.entities);

            foreach (Entity entity in entities)
            {
                if(entity.Health <= 0)
                {
                    if(entity is Player)
                    {
                        Game1.State = State.GameOver;
                    }
                    level.entities.Remove(entity);
                    level.collisionManager.entities.Remove(entity);
                }
            }
        }
    }
}
