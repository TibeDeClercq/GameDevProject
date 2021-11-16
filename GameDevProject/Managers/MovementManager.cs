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
            if (direction.X == -1 || direction.X == 1)
            {
                var distance = direction * movable.Speed;
                movable.Position += distance;
            }
            else if (direction.Y == 1)
            {
                movable.Position -= new Vector2(0, 20);
            }
        }
    }   
}
