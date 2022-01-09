using Microsoft.Xna.Framework.Input;

using Blob.Interfaces;

namespace Blob.Input
{
    class KeyboardReader : IInputReader
    {
        #region Properties
        public bool IsDestinationInput => false;
        #endregion

        #region Public Methods
        public InputParameters ReadInput()
        {
            KeyboardState state = Keyboard.GetState();
            InputParameters inputParameters = new InputParameters();
            if (state.IsKeyDown(Keys.Left))
            {
                inputParameters.DirectionInput.X -= 1;
            }
            if (state.IsKeyDown(Keys.Right))
            {
                inputParameters.DirectionInput.X += 1;
            }
            if (state.IsKeyDown(Keys.Space))
            {
                inputParameters.DirectionInput.Y += 1;
            }
            if (state.IsKeyDown(Keys.Down))
            {
                inputParameters.DirectionInput.Y -= 1;
            }
            if (state.IsKeyDown(Keys.C))
            {
                inputParameters.Attack = true;
            }
            return inputParameters;
        }
        #endregion
    }
}
