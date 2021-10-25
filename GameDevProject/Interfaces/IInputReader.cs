using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace GameDevProject.Interfaces
{
    interface IInputReader
    {
        Vector2 ReadInput();
        public bool IsDestinationInput { get; }
    }
}
