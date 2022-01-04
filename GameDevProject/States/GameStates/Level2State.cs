using System;
using System.Collections.Generic;
using System.Text;

using GameDevProject.Entities;
using GameDevProject.Interfaces;
using GameDevProject.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.States.GameStates
{
    class Level2State : IGameState
    {
        public void Update(Level level, GameTime gameTime)
        {
            foreach (Entity entity in level.entities)
            {
                entity.Update(gameTime, level.world);
            }
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
    }
}
