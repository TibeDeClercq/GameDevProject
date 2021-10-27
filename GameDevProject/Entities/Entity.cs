using GameDevProject.Entities.Animations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Entities
{
    class Entity
    {
        private Texture2D texture;
        private Animation animation;

        public Vector2 Speed { get; set; }
        public Vector2 Position { get; set; }

    }
}
