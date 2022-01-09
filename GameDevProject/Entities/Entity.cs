using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using GameDevProject.Entities.Animations;
using GameDevProject.Map;

namespace GameDevProject.Entities
{
    abstract class Entity : Interfaces.IDrawable
    {
        protected List<Texture2D> textures;
        protected List<Animation> animations = new List<Animation>();

        public Vector2 Position { get; set; }
        public int Health { get; set; }

        abstract public void Draw(SpriteBatch spriteBatch);
        abstract public void Update(GameTime gameTime, World world);
    }
}
