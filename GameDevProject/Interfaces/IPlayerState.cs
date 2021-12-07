using GameDevProject.Entities;
using GameDevProject.Entities.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.States.PlayerStates
{
    interface IPlayerState
    {
        public void Draw(SpriteBatch spriteBatch, List<Texture2D> textures, Vector2 Position, List<Animation> animations, SpriteEffects spriteEffects);
        public void Update(GameTime gameTime, List<Animation> animations);
    }
}
