using System;
using System.Collections.Generic;
using System.Text;

using GameDevProject.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Interfaces
{
    interface IGameState
    {
        public void Update(List<Level> levels, GameTime gameTime);
        public void Draw(List<Level> levels, SpriteBatch spriteBatch);
        public int GetWindowHeight(List<Level> levels);
        public int GetWindowWidth(List<Level> levels);
    }
}
