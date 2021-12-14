using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

using GameDevProject.Interfaces;
using System.Diagnostics;

namespace GameDevProject.Input
{
    class KeyboardReader : IInputReader
    {
        public bool IsDestinationInput => false;
        public InputParameters ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            InputParameters inputParameters = new InputParameters();
            //Vector2 direction = Vector2.Zero;
            if (state.IsKeyDown(Keys.Left))
            {
                inputParameters.directionInput.X -= 1;
                //direction.X -= 1;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                inputParameters.directionInput.X += 1;
                //direction.X += 1;
            }
            if (state.IsKeyDown(Keys.Space))
            {
                inputParameters.directionInput.Y += 1;
                //direction.Y += 1;
            }
            if (state.IsKeyDown(Keys.C))
            {
                inputParameters.Attack = true;
                //Debug.WriteLine("pressed C");
                //direction.Y += 1;
            }
            return inputParameters;
        }
    }
}
