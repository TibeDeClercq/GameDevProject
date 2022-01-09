using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Entities;
﻿using GameDevProject.Entities.Animations;
using GameDevProject.Interfaces;

namespace GameDevProject.States.PlayerStates
{
    class PlayerIdleState : IPlayerState
    {
        #region Public methods
        public void Draw(SpriteBatch spriteBatch, List<Texture2D> textures, Vector2 position, List<Animation> animations, SpriteEffects spriteEffects)
        {
            spriteBatch.Draw(textures[0], new Vector2(position.X - animations[0].Hitbox.X, position.Y - animations[0].Hitbox.Y), animations[0].CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), spriteEffects, 0f);
        }

        public void Update(GameTime gameTime, List<Animation> animations, Player player)
        {
            player.HitboxRectangle = new Rectangle((int)player.Position.X, (int)player.Position.Y + 1, animations[0].Hitbox.Width, animations[0].Hitbox.Height);
            animations[0].Update(gameTime);
        }
        #endregion
    }
}
