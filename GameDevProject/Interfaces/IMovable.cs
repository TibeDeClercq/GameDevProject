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
        public Vector2 MaxVelocity { get; set; }
        public float MaxAcceleration { get; set; }
        public float MaxJumpHeight { get; set; }
        public IInputReader InputReader { get; set; }
        public SpriteEffects spriteEffects { get; set; }

        public void Move();
    }
}
