using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Blob.Entities;
using Blob.Entities.Animations;
using Blob.Interfaces;

namespace Blob.States.PlayerStates
{
    class PlayerWalkState : IPlayerState
    {
        #region Public methods
        public void Draw(SpriteBatch spriteBatch, List<Texture2D> textures, Vector2 position, List<Animation> animations, SpriteEffects spriteEffects)
        {
            spriteBatch.Draw(textures[1], new Vector2(position.X - animations[1].Hitbox.X, position.Y - animations[1].Hitbox.Y), animations[1].CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), spriteEffects, 0f);
        }

        public void Update(GameTime gameTime, List<Animation> animations, Player player)
        {
            player.HitboxRectangle = new Rectangle((int)player.Position.X, (int)player.Position.Y + 1, animations[1].Hitbox.Width, animations[1].Hitbox.Height);
            animations[1].Update(gameTime);
        }
        #endregion
    }
}
