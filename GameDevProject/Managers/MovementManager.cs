using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GameDevProject.Entities;
using GameDevProject.Interfaces;
using GameDevProject.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Managers
{
    class MovementManager
    {
        #region Public methods
        public void Move(IMovable movable, GameTime gameTime, World world)
        {
            var input = movable.InputReader.ReadInput();            

            movable.Velocity = new Vector2(0, 0);
            PhysicsManager.AddGravity(movable, world);
            PhysicsManager.AddJump(movable, world);

            var entity = movable as Entity;
            if (entity.Health > 0)
            {
                if (input.DirectionInput.X == -1)
                {
                    movable.SpriteEffects = SpriteEffects.FlipHorizontally;
                    PhysicsManager.MoveLeft(movable, world);
                }
                if (input.DirectionInput.X == 1)
                {
                    movable.SpriteEffects = SpriteEffects.None;
                    PhysicsManager.MoveRight(movable, world);
                }

                if (input.DirectionInput.Y == 1)
                {
                    if (movable.CanJump)
                    {
                        movable.Acceleration = new Vector2(0, -2.7f); // power of the jump
                        movable.IsJumping = true;
                    }
                }
            }            

            movable.Velocity += movable.Acceleration;
            movable.Position += movable.Velocity;
            movable.HitboxRectangle = new Rectangle((int)movable.Position.X, (int)movable.Position.Y + 1, movable.HitboxRectangle.Width, movable.HitboxRectangle.Height);

            WriteDiagnostics(movable);
        }
        #endregion

        #region Private methods
        private void WriteDiagnostics(IMovable movable)
        {
            //Debug.WriteLine($"a: {movable.Acceleration.Y} | v: {movable.Velocity} | jumping? {movable.IsJumping} | Can jump? {movable.CanJump}");
            //Debug.WriteLine($"jumping? {movable.IsJumping}");
        }
        #endregion
    }   
}
