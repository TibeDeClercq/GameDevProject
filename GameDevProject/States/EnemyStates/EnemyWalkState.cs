﻿using GameDevProject.Entities;
using GameDevProject.Entities.Animations;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameDevProject.States.EnemyStates
{
    class EnemyWalkState : IEntityState
    {
        public void Draw(SpriteBatch spriteBatch, List<Texture2D> textures, Vector2 position, List<Animation> animations, SpriteEffects spriteEffects)
        {
            spriteBatch.Draw(textures[0], position, animations[0].CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), spriteEffects, 0f);
        }

        public void Update(GameTime gameTime, List<Animation> animations, Entity entity)
        {
            Enemy enemy = entity as Enemy;
            enemy.HitboxRectangle = new Rectangle((int)enemy.Position.X, (int)enemy.Position.Y + 1, animations[0].Hitbox.Width, animations[0].Hitbox.Height);
            animations[0].Update(gameTime);
        }
    }
}