using GameDevProject.Input;

namespace GameDevProject.Interfaces
{
    interface IInputReader
    {
        public InputParameters ReadInput();
        public bool IsDestinationInput { get; }
    }
}
