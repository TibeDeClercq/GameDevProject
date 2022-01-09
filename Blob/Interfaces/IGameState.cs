using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Blob.Levels;

namespace Blob.Interfaces
{
    interface IGameState
    {
        public void Update(Level level, GameTime gameTime);
        public void Draw(Level level, SpriteBatch spriteBatch);
        public int GetWindowHeight(Level level);
        public int GetWindowWidth(Level level);
    }
}
