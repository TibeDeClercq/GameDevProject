using System;
using System.Collections.Generic;
using System.Text;

using GameDevProject.Entities;
using GameDevProject.Input;
using GameDevProject.Interfaces;
using GameDevProject.Levels;
using GameDevProject.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.States.GameStates
{
    class Level1State : IGameState
    {
        public void Draw(List<Level> levels, SpriteBatch spriteBatch)
        {
            levels[0].world.Draw(spriteBatch);

            foreach (Entity entity in levels[0].entities)
            {
                entity.Draw(spriteBatch);
            }
        }
        public void Update(List<Level> levels, GameTime gameTime)
        {
            foreach (Entity entity in levels[0].entities)
            {
                entity.Update(gameTime, levels[0].world);
            }
        }

    }
}
