using UnityEngine;

namespace Source.Scripts
{
    public class CatapultShooter : MonoBehaviour
    {
        [SerializeField] private float _springFireTension;
        [SerializeField] private float _springFireDamper;
        [SerializeField] private CatapultShootState _shootState;

        private SpringJoint _springJoint;
        private InputReader _inputReader;
        private Rigidbody _bucket;

        public void Initialize(InputReader inputReader, SpringJoint springJoint, Rigidbody bucket)
        {
            _inputReader = inputReader;
            _springJoint = springJoint;
            _bucket = bucket;
        }

        public void HandleShoot()
        {
            if (_inputReader.IsShootKeyPressed() && _shootState.CanShoot)
            {
                Shoot();
                _shootState.DenyShoot();
            }
        }

        private void Shoot()
        {
            _bucket.WakeUp();

            _springJoint.spring = _springFireTension;
            _springJoint.damper = _springFireDamper;
        }
    }
}