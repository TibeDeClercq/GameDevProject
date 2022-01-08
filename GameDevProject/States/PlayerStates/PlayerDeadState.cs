using GameDevProject.Entities;
﻿using GameDevProject.Entities.Animations;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.States.PlayerStates
{
    class PlayerDeadState : IPlayerState
    {
        #region Public methods
        public void Draw(SpriteBatch spriteBatch, List<Texture2D> textures, Vector2 position, List<Animation> animations, SpriteEffects spriteEffects)
        {
            spriteBatch.Draw(textures[5], new Vector2(position.X - animations[5].Hitbox.X, position.Y - animations[5].Hitbox.Y), animations[5].CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), spriteEffects, 0f);
        }

        public void Update(GameTime gameTime, List<Animation> animations, Player player)
        {
            player.HitboxRectangle = new Rectangle((int)player.Position.X, (int)player.Position.Y + 1, animations[5].Hitbox.Width, animations[5].Hitbox.Height);
            animations[5].Update(gameTime);
        }
        #endregion
    }
}
