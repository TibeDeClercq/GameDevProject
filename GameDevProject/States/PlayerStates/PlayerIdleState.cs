using GameDevProject.Entities.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.States.PlayerStates
{
    class PlayerIdleState : PlayerState
    {
        public void Draw(SpriteBatch spriteBatch, List<Texture2D> textures, Vector2 Position, List<Animation> animations)
        {
            spriteBatch.Draw(textures[1], Position, animations[1].CurrentFrame.SourceRectangle, Color.White);
        }

        public void Update(GameTime gameTime, List<Animation> animations)
        {
            animations[1].Update(gameTime);
        }
    }
}
