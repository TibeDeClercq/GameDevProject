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
        public void Update(List<Level> levels, GameTime gameTime)
        {
            foreach (Entity entity in levels[0].entities)
            {
                entity.Update(gameTime, levels[0].world);
            }

            levels[0].healthManager.UpdateHealth(levels[0].collisionManager);
            ClearDeadEntities(levels);
        }

        public void Draw(List<Level> levels, SpriteBatch spriteBatch)
        {
            levels[0].world.Draw(spriteBatch);

            foreach (Entity entity in levels[0].entities)
            {
                entity.Draw(spriteBatch);
            }
        }

        public int GetWindowHeight(List<Level> levels)
        {
            return levels[0].world.GetWorldHeight(); //getWorldHeight
        }

        public int GetWindowWidth(List<Level> levels)
        {
            return levels[0].world.GetWorldWidth(); //getWorldWidth
        }

        private void ClearDeadEntities(List<Level> levels)
        {
            List<Entity> entities = new List<Entity>(levels[0].entities);

            foreach (Entity entity in entities)
            {
                if(entity.Health <= 0)
                {
                    levels[0].entities.Remove(entity);
                }
            }
        }
    }
}
