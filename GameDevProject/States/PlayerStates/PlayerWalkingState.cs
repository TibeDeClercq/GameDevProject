using GameDevProject.Entities;
using GameDevProject.Entities.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.States.PlayerStates
{
    class PlayerWalkingState : PlayerState
    {
        public void Draw(SpriteBatch spriteBatch, List<Texture2D> textures, Vector2 Position, List<Animation> animations)
        {
            spriteBatch.Draw(textures[0], Position, animations[0].CurrentFrame.SourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime, List<Animation> animations)
        {
            animations[0].Update(gameTime);
        }
    }
}
