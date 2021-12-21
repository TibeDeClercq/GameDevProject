using GameDevProject.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Interfaces
{
    interface IMovable
    {
        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 MaxVelocity { get; set; }
        public float Acceleration { get; set; }
        public float MaxAcceleration { get; set; }
        public float MaxJumpHeight { get; set; }
        public IInputReader InputReader { get; set; }
        public SpriteEffects SpriteEffects { get; set; }
        public Rectangle Hitbox { get; set; }

        public void Move(GameTime gameTime, World world);
    }
}
