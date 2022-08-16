using UnityEngine;

namespace Assets.Scripts.Services
{
    public class InputService : IInputService
    {
        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        public Vector3 Axis => InputAxis();

        private Vector3 InputAxis() =>
            new Vector3(
                SimpleInput.GetAxisRaw(HorizontalAxis), 
                0.0f,
                SimpleInput.GetAxisRaw(VerticalAxis));
    }
}
