using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GameDevProject.Interfaces;
using GameDevProject.Map;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Managers
{
    class MovementManager
    {
        public void Move(IMovable movable, GameTime gameTime, World world)
        {
            var input = movable.InputReader.ReadInput();

            PhysicsManager.AddGravity(movable, world, gameTime);
            
            //Niet de beste oplossing
            movable.Velocity = new Vector2(0, movable.Velocity.Y);

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
                PhysicsManager.Jump(movable, world, gameTime);
            }

            movable.Position += movable.Velocity;
            movable.HitboxRectangle = new Rectangle((int)movable.Position.X, (int)movable.Position.Y, movable.HitboxRectangle.Width, movable.HitboxRectangle.Height);

            //WriteDiagnostics(movable);
        }

        private void WriteDiagnostics(IMovable movable)
        {
            Debug.WriteLine(movable.Velocity);
            Debug.WriteLine(movable.Position);
        }
    }   
}
