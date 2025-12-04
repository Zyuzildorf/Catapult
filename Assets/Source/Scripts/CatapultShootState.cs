using UnityEngine;

namespace Source.Scripts
{
    public class CatapultShootState : MonoBehaviour
    {
        public bool CanShoot { get; private set; }

        public void AllowShoot()
        {
            CanShoot = true;
        }

        public void DenyShoot()
        {
            CanShoot = false;
        }
    }
}