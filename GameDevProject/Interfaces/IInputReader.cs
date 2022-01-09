using Blob.Input;

namespace Blob.Interfaces
{
    interface IInputReader
    {
        public InputParameters ReadInput();
        public bool IsDestinationInput { get; }
    }
}
