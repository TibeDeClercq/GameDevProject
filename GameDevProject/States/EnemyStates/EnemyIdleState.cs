﻿using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Blob.Entities;
using Blob.Entities.Animations;
using Blob.Interfaces;

namespace Blob.States.EnemyStates
{
    class EnemyIdleState : IEntityState
    {
        #region Public methods
        public void Draw(SpriteBatch spriteBatch, List<Texture2D> textures, Vector2 position, List<Animation> animations, SpriteEffects spriteEffects)
        {
            spriteBatch.Draw(textures[2], new Vector2(position.X - animations[2].Hitbox.X, position.Y - animations[2].Hitbox.Y), animations[2].CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), spriteEffects, 0f);
        }

        public void Update(GameTime gameTime, List<Animation> animations, Entity entity)
        {
            Enemy enemy = entity as Enemy;
            enemy.HitboxRectangle = new Rectangle((int)enemy.Position.X, (int)enemy.Position.Y + 1, animations[2].Hitbox.Width, animations[2].Hitbox.Height);
            animations[2].Update(gameTime);
        }
        #endregion
    }
}
