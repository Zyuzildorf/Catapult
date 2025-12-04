using System.Collections;
using UnityEngine;

namespace Source.Scripts
{
    public class CatapultReloader : MonoBehaviour
    {
        [SerializeField] private float _springIdleTension;
        [SerializeField] private float _springIdleDamper;
        [SerializeField] private float _rateOfFire;
        [SerializeField] private GameObject _projectilePrefab;
        [SerializeField] private Transform _spawnSpot;
        [SerializeField] private CatapultShootState _shootState;

        private WaitForSeconds _reloadTime;
        private SpringJoint _springJoint;
        private InputReader _inputReader;
        private Coroutine _reloadCoroutine;
        private Rigidbody _bucket;

        private void Start()
        {
            _reloadTime = new WaitForSeconds(_rateOfFire);
        }

        public void Initialize(InputReader inputReader, SpringJoint springJoint, Rigidbody bucket)
        {
            _inputReader = inputReader;
            _springJoint = springJoint;
            _bucket = bucket;

            ResetSpringToIdle();
        }

        public void HandleReload()
        {
            if (_inputReader.IsReloadKeyPressed() && _shootState.CanShoot == false && _reloadCoroutine == null)
            {
                StartReload();
            }
        }

        private void StartReload()
        {
            if (_reloadCoroutine != null)
            {
                StopCoroutine(_reloadCoroutine);
            }

            _reloadCoroutine = StartCoroutine(Reload());
        }

        private IEnumerator Reload()
        {
            ResetSpringToIdle();

            yield return _reloadTime;

            SpawnProjectile();

            _shootState.AllowShoot();
            _reloadCoroutine = null;
        }

        private void ResetSpringToIdle()
        {
            _bucket.WakeUp();
            _springJoint.spring = _springIdleTension;
            _springJoint.damper = _springIdleDamper;
        }

        private void SpawnProjectile()
        {
            Instantiate(_projectilePrefab, _spawnSpot, true);
        }
    }
}