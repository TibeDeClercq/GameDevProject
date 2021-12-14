using GameDevProject.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Interfaces
{
    interface IInputReader
    {
        //Vector2 ReadInput();
        InputParameters ReadInput();
        public bool IsDestinationInput { get; }
    }
}
