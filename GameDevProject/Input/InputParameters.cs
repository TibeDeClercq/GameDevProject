using Microsoft.Xna.Framework;

namespace GameDevProject.Input
{
    class InputParameters
    {
        #region Properties
        public Vector2 DirectionInput;
        public bool Attack;
        #endregion

        #region Constructor
        public InputParameters()
        {
            this.DirectionInput = new Vector2();
            this.Attack = false;
        }
        #endregion
    }
}
