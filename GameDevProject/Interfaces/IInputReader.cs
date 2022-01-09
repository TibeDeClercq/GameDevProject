using GameDevProject.Input;

namespace GameDevProject.Interfaces
{
    interface IInputReader
    {
        //Vector2 ReadInput();
        InputParameters ReadInput();
        public bool IsDestinationInput { get; }
    }
}
