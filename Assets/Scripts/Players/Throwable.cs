using System;
using UnityEngine;

namespace Players
{
    public class Throwable : MonoBehaviour
    {
        public GameObject projectile;

        private void Update()
        {
            if (projectile != null)
            {
                ThrowWeapon();
            }
        }

        private void ThrowWeapon()
        {
            if(Input.GetKeyDown(KeyCode.I))
            {
                Instantiate(projectile, transform.position, Quaternion.identity, gameObject.transform);
            }
        }
    }
}
