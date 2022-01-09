using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Hitboxes
{
    class Hitbox
    {
        #region Properties
        public Texture2D Texture { get; set; } 
        public Vector2 Position { get; set; }
        #endregion

        #region Constructor
        public Hitbox(Texture2D texture, Vector2 position)
        {
            this.Texture = texture;
            this.Position = position;
        }
        #endregion
    }
}
