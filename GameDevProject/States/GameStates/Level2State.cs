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
        public void Update(List<Level> levels, GameTime gameTime)
        {
            foreach (Entity entity in levels[1].entities)
            {
                entity.Update(gameTime, levels[1].world);
            }
        }

        public void Draw(List<Level> levels, SpriteBatch spriteBatch)
        {
            levels[1].world.Draw(spriteBatch);

            foreach (Entity entity in levels[1].entities)
            {
                entity.Draw(spriteBatch);
            }
        }

        public int GetWindowHeight(List<Level> levels)
        {
            return levels[1].world.GetWorldHeight(); //getWorldHeight
        }

        public int GetWindowWidth(List<Level> levels)
        {
            return levels[1].world.GetWorldWidth(); //getWorldWidth
        }
    }
}
