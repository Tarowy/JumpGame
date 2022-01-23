using System;
using UnityEngine;

namespace Weapon
{
    public class Sickle : ThrowableWeapon
    {
        public float rotateSpeed;
        public bool isBacking;
        
        private Vector2 _direction;

        public override void Update()
        {
            base.Update();
            transform.Rotate(0, 0, rotateSpeed);
            SickleFly();
        }

        private void SickleFly()
        {
            switch (isBacking)
            {
                //飞镖反向则追踪玩家
                case true:
                {
                    _direction = (playerTransform.position - transform.position).normalized;
                    rigidbody2D.velocity = new Vector2(_direction.x * speed, _direction.y * speed);
                    
                    if (Vector2.Distance(transform.position, playerTransform.position) <= 0.2f)
                    {
                        Destroy(gameObject);
                    }
                    break;
                }
                //当飞镖的x,y轴的速度都接近0的时候，就会反向
                case false :
                    rigidbody2D.velocity -= startSpeed * Time.deltaTime;
                    if (Math.Abs(rigidbody2D.velocity.x) <= 0.5f && Math.Abs(rigidbody2D.velocity.y) <= 0.5f)
                    {
                        isBacking = true;
                    }
                    break;
            }
        }
    }
}
