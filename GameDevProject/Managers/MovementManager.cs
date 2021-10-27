using System;
using System.Collections.Generic;
using System.Text;
using GameDevProject.Interfaces;

namespace GameDevProject.Managers
{
    class MovementManager
    {
        public void Move(IMovable movable)
        {
            var direction = movable.InputReader.ReadInput();
            if (direction.X == -1 || direction.X == 1)
            {
                var afstand = direction * movable.Speed;
                movable.Position += afstand;
            }
            //else if (direction.Y == 1)
            //{
            //    movable.Position -= new Microsoft.Xna.Framework.Vector2(0, 20);
            //}
        }
    }   
}
