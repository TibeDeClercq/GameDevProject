using GameDevProject.Entities;
using GameDevProject.Entities.Animations;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.States.EnemyStates
{
    class EnemyDeadState : IEntityState
    {
        public void Draw(SpriteBatch spriteBatch, List<Texture2D> textures, Vector2 position, List<Animation> animations, SpriteEffects spriteEffects)
        {
            spriteBatch.Draw(textures[1], new Vector2(position.X - animations[2].Hitbox.X, position.Y - animations[2].Hitbox.Y), animations[1].CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), spriteEffects, 0f);
        }

        public void Update(GameTime gameTime, List<Animation> animations, Entity entity)
        {
            Enemy enemy = entity as Enemy;
            enemy.HitboxRectangle = new Rectangle((int)enemy.Position.X, (int)enemy.Position.Y + 1, animations[1].Hitbox.Width, animations[1].Hitbox.Height);
            animations[1].Update(gameTime);
        }
    }
}
