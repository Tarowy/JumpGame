using System;
using UnityEngine;
using Weapon;

namespace Players
{
    public class Throwable : MonoBehaviour
    {
        public GameObject projectile;
        public GameObject bomb;
        public float throwSpeedRate;

        private Rigidbody2D _rigidbody2D;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

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

            if (Input.GetKeyDown(KeyCode.O))
            {
                Instantiate(bomb, transform.position, Quaternion.identity, gameObject.transform).GetComponent<Bomb>()
                    .baseSpeed = new Vector2(_rigidbody2D.velocity.x * throwSpeedRate, _rigidbody2D.velocity.y);
            }
        }
    }
}
