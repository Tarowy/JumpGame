using System;
using Enemies;
using UnityEngine;

namespace Weapon
{
    public class Sickle : MonoBehaviour
    {
        public float speed;
        public float rotateSpeed;
        public float damage;
        public bool isBacking;
        public float deadTime;

        private Vector2 _startSpeed;
        private Rigidbody2D _rigidbody2D;
        public Transform _playerTransform;
        private float _lifeTime;
        private Vector2 _direction;

        private void Start()
        {
            _playerTransform = transform.parent.transform;
            gameObject.transform.parent = null;
            
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _rigidbody2D.velocity = _playerTransform.right * speed;
            _startSpeed = _rigidbody2D.velocity;
        }

        private void Update()
        {
            _lifeTime += Time.deltaTime;
            if (_lifeTime >= deadTime)
            {
                Destroy(gameObject);
            }
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
                    _direction = (_playerTransform.position - transform.position).normalized;
                    _rigidbody2D.velocity = new Vector2(_direction.x * speed, _direction.y * speed);
                    
                    if (Vector2.Distance(transform.position, _playerTransform.position) <= 0.2f)
                    {
                        Destroy(gameObject);
                    }
                    break;
                }
                //当飞镖的x,y轴的速度都接近0的时候，就会反向
                case false :
                    _rigidbody2D.velocity -= _startSpeed * Time.deltaTime;
                    if (Math.Abs(_rigidbody2D.velocity.x) <=0.1f && Math.Abs(_rigidbody2D.velocity.y) <=0.1f)
                    {
                        isBacking = true;
                    }
                    break;
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().BeDamaged(damage);
            }
        }
    }
}
