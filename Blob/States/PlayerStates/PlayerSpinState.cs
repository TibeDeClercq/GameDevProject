using System.Collections.Generic;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using Blob.Entities;
using Blob.Entities.Animations;
using Blob.Interfaces;

namespace Blob.States.PlayerStates
{
    class PlayerSpinState : IPlayerState
    {
        #region Public methods
        public void Draw(SpriteBatch spriteBatch, List<Texture2D> textures, Vector2 position, List<Animation> animations, SpriteEffects spriteEffects)
        {
            spriteBatch.Draw(textures[3], new Vector2(position.X - animations[3].Hitbox.X, position.Y - animations[3].Hitbox.Y), animations[3].CurrentFrame.SourceRectangle, Color.White, 0f, new Vector2(0, 0), new Vector2(1, 1), spriteEffects, 0f);
        }

        public void Update(GameTime gameTime, List<Animation> animations, Player player)
        {
            player.HitboxRectangle = new Rectangle((int)player.Position.X, (int)player.Position.Y + 1, animations[3].Hitbox.Width, animations[3].Hitbox.Height);
            animations[3].Update(gameTime);
        }
        #endregion
    }
}
