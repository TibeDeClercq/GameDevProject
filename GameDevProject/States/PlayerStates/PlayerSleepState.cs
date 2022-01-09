using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GameDevProject.Entities;
using GameDevProject.Entities.Animations;
using GameDevProject.Interfaces;

namespace GameDevProject.States.PlayerStates
{
    class PlayerSleepState : IPlayerState
    {
        #region Public methods
        public void Draw(SpriteBatch spriteBatch, List<Texture2D> textures, Vector2 position, List<Animation> animations, SpriteEffects spriteEffects)
        {
            spriteBatch.Draw(textures[4], new Vector2(position.X - animations[4].Hitbox.X, position.Y - animations[4].Hitbox.Y), animations[4].CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), spriteEffects, 0f);
        }

        public void Update(GameTime gameTime, List<Animation> animations, Player player)
        {
            player.HitboxRectangle = new Rectangle((int)player.Position.X, (int)player.Position.Y + 1, animations[4].Hitbox.Width, animations[4].Hitbox.Height);
            animations[4].Update(gameTime);
        }
        #endregion
    }
}
