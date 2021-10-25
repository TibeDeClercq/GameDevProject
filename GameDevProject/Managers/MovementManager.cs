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
            if (movable.InputReader.IsDestinationInput)
            {
                direction -= movable.Position;
                direction.Normalize();
            }

            var afstand = direction * movable.Speed;
            movable.Position += afstand;
        }
    }
}
