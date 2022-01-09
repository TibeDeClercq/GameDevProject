using Microsoft.Xna.Framework;

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
