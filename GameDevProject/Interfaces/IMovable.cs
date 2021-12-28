using GameDevProject.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Interfaces
{
    interface IMovable : IHitbox
    {
        public bool CanJump { get; set; }
        public bool IsJumping { get; set; }

        public Vector2 Position { get; set; }
        public Vector2 Velocity { get; set; }
        public Vector2 MaxVelocity { get; set; }
        public Vector2 Acceleration { get; set; }
        public IInputReader InputReader { get; set; }
        public SpriteEffects SpriteEffects { get; set; }
        
        //public Rectangle HitboxRectangle { get; set; }

        public void Move(GameTime gameTime, World world);
    }
}
