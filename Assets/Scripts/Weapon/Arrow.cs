using UnityEngine;
using System;
using Enemies;

namespace Weapon
{
    public class Arrow : ThrowableWeapon
    {
        public override void Update()
        {
            base.Update();
            ArrowFly();
        }

        public override void Start()
        {
            base.Start();
            rigidbody2D.centerOfMass = transform.GetChild(0).position;
        }

        private void ArrowFly()
        {
            
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            // rigidbody2D.velocity = new Vector2(0, 0);
            // rigidbody2D.angularVelocity = 0;
            // Destroy(rigidbody2D);

            if (other.gameObject.CompareTag("Enemy"))
            {
                transform.parent = other.transform;
                other.gameObject.GetComponent<Enemy>()?.BeDamaged(damage);
            }
        }
    }
}
