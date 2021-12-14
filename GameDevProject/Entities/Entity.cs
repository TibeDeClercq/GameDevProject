using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

using GameDevProject.Interfaces;
using GameDevProject.Entities.Animations;
using GameDevProject.Map;

namespace GameDevProject.Entities
{
    abstract class Entity : Interfaces.IDrawable
    {
        protected List<Texture2D> textures;
        protected List<Animation> animations = new List<Animation>();
        protected IInputReader inputReader;
        public Vector2 Position { get; set; }

        abstract public void Draw(SpriteBatch spriteBatch);
        //{
        //    spriteBatch.Draw(texture, Position, animation[0].CurrentFrame.SourceRectangle, Color.White);
        //}

        abstract public void Update(GameTime gameTime, World world);
        //{
        //    animation.Update(gameTime);
        //}
    }
}
