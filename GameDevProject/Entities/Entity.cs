using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

using GameDevProject.Interfaces;
using GameDevProject.Entities.Animations;

namespace GameDevProject.Entities
{
    abstract class Entity
    {
        protected Texture2D texture;
        protected Animation animation;
        protected IInputReader inputReader;
        public Vector2 Speed { get; set; }
        public Vector2 Position { get; set; }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, animation.CurrentFrame.SourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime)
        {
            animation.Update(gameTime);
        }

    }
}
