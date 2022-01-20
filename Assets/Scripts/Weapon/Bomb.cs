using System;
using Enemies;
using UnityEngine;

namespace Weapon
{
    public class Bomb : MonoBehaviour
    {
        public Vector2 baseSpeed;
        public float boomStartTime;
        public float damage;
        
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;
        private CircleCollider2D _circleCollider2D;
        private PolygonCollider2D _polygonCollider2D;
        
        private void Awake()
        {
            _circleCollider2D = GetComponent<CircleCollider2D>();
            _polygonCollider2D = GetComponent<PolygonCollider2D>();
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void Start()
        {
            _rigidbody2D.velocity = new Vector2(baseSpeed.x,baseSpeed.y);
            transform.parent = null;
            Invoke(nameof(StartBoom), boomStartTime);
        }


        public void StartBoom()
        {
            _animator.SetTrigger("Boom");
            _rigidbody2D.isKinematic = true;
            _rigidbody2D.velocity = new Vector2(0, 0);
            _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
            transform.localRotation = new Quaternion(0, 0, 0, 0);
            Destroy(_circleCollider2D);
            _polygonCollider2D.enabled = true;
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!_polygonCollider2D.enabled) return;
            
            Debug.Log("标签："+other.tag);
            if (other.CompareTag("Enemy"))
            {
                Debug.Log("爆炸");
                other.GetComponent<Enemy>()?.BeDamaged(damage);
            }
            
            var direction = (other.transform.position - transform.position).normalized;
            other.GetComponent<Rigidbody2D>()?
                .AddForce(new Vector2(direction.x * 10, direction.y * 10), ForceMode2D.Impulse);
        }

        public void ToDestroy()
        {
            Destroy(gameObject);
        }
    }
}
