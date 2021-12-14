﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameDevProject.Managers
{
    class MovementManager
    {
        public void Move(IMovable movable, GameTime gameTime)
        {
            var direction = movable.InputReader.ReadInput().directionInput;
            PhysicsManager.AddGravity(movable, gameTime);

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
        }
    }   
}
