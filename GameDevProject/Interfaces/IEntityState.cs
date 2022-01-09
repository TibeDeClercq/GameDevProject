using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Blob.Entities;
using Blob.Entities.Animations;

namespace Blob.Interfaces
{
    interface IEntityState
    {
        public void Draw(SpriteBatch spriteBatch, List<Texture2D> textures, Vector2 position, List<Animation> animations, SpriteEffects spriteEffects);
        public void Update(GameTime gameTime, List<Animation> animations, Entity enemy);
    }
}
