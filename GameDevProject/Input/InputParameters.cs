using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Input
{
    class InputParameters
    {
        public Vector2 DirectionInput;

        public bool Attack;

        public InputParameters()
        {
            this.DirectionInput = new Vector2();
            this.Attack = false;
        }
    }
}
