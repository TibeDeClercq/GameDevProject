﻿using System;
using System.Collections.Generic;
using System.Text;

using GameDevProject.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Interfaces
{
    interface IGameState
    {
        public void Update(Level level, GameTime gameTime);
        public void Draw(Level level, SpriteBatch spriteBatch);
        public int GetWindowHeight(Level level);
        public int GetWindowWidth(Level level);
    }
}
