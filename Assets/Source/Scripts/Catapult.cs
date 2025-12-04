using UnityEngine;

namespace Source.Scripts
{
    [RequireComponent(typeof(CatapultShooter), typeof(CatapultReloader))]
    public class Catapult : MonoBehaviour
    {
        [SerializeField] private SpringJoint _springJoint;
        [SerializeField] private Rigidbody _bucketRigidbody;

        private InputReader _inputReader;
        private WaitForSeconds _reloadTime;
        private Coroutine _reloadCoroutine;
        private CatapultShooter _catapultShooter;
        private CatapultReloader _catapultReloader;

        private void Awake()
        {
            _inputReader = new InputReader();
        
            _catapultShooter = GetComponent<CatapultShooter>();
            _catapultReloader = GetComponent<CatapultReloader>();
        
            _catapultShooter.Initialize(_inputReader, _springJoint, _bucketRigidbody);
            _catapultReloader.Initialize(_inputReader, _springJoint, _bucketRigidbody);
        }

        private void Update()
        {
            _catapultShooter.HandleShoot();
            _catapultReloader.HandleReload();
        }
    }
}