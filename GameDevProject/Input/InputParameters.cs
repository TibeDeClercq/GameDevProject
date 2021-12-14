using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Input
{
    class InputParameters
    {
        public Vector2 directionInput;

        public bool Attack;

        public InputParameters()
        {
            directionInput = new Vector2();
            Attack = false;
        }
    }
}
