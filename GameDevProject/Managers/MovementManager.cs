using System;
using System.Collections.Generic;
using System.Text;
using GameDevProject.Interfaces;
using Microsoft.Xna.Framework;

namespace GameDevProject.Managers
{
    class MovementManager
    {
        public void Move(IMovable movable)
        {
            var direction = movable.InputReader.ReadInput();

            if (direction.X == -1)
            {
                PhysicsManager.MoveLeft(movable);
            }
            if (direction.X == 1)
            {
                PhysicsManager.MoveRight(movable);
            }
            if (direction.Y == 1)
            {
                PhysicsManager.Jump(movable);
            }
            PhysicsManager.AddGravity(movable);
        }
    }   
}
