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
            var direction = movable.InputReader.ReadInput().directionInput;
            PhysicsManager.AddGravity(movable, gameTime);
            //Niet de beste oplossing
            movable.Velocity = new Vector2(0, movable.Velocity.Y);

            if (direction.X == -1)
            {
                movable.spriteEffects = SpriteEffects.FlipHorizontally;
                PhysicsManager.MoveLeft(movable);
            }
            if (direction.X == 1)
            {
                movable.spriteEffects = SpriteEffects.None;
                PhysicsManager.MoveRight(movable);
            }
            if (direction.Y == 1)
            {
                PhysicsManager.Jump(movable, gameTime);
            }
            movable.Position += movable.Velocity;

            WriteDiagnostics(movable);
        }

        private void WriteDiagnostics(IMovable movable)
        {
            Debug.WriteLine(movable.Velocity);
            Debug.WriteLine(movable.Position);
        }
    }   
}
