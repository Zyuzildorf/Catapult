using UnityEngine;

namespace Source.Scripts
{
    public class Swing : MonoBehaviour
    {
        [SerializeField] private Vector3 _forceDirection;
        [SerializeField] private Rigidbody _seat;

        private InputReader _inputReader;

        private void Awake()
        {
            _inputReader = new InputReader();
        }

        private void FixedUpdate()
        {
            if (_inputReader.IsSwingKeyPressed())
            {
                _seat.AddRelativeForce(_forceDirection, ForceMode.Impulse);
            }
        }
    }
}