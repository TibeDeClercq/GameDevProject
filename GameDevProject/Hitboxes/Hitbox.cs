using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject
{
    class Hitbox
    {
        public Texture2D Texture { get; set; } 
        public Vector2 Position { get; set; }

        public Hitbox(Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            this.Position = position;
        }
    }
}
