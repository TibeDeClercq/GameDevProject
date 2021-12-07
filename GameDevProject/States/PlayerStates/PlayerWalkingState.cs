using GameDevProject.Entities;
using GameDevProject.Entities.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.States.PlayerStates
{
    class PlayerWalkingState : IPlayerState
    {
        public void Draw(SpriteBatch spriteBatch, List<Texture2D> textures, Vector2 Position, List<Animation> animations, SpriteEffects spriteEffects)
        {
            spriteBatch.Draw(textures[0], Position, animations[0].CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0,0), new Vector2(1, 1), spriteEffects, 0f);
        }

        public void Update(GameTime gameTime, List<Animation> animations)
        {
            animations[0].Update(gameTime);
        }
    }
}
