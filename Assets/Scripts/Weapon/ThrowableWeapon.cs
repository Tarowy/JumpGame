using Enemies;
using UnityEngine;

namespace Weapon
{
    public class ThrowableWeapon : MonoBehaviour
    {
        public float speed;
        public float damage;
        public float deadTime;

        private float _lifeTime;
        protected Transform playerTransform;
        
        protected Vector2 startSpeed;
        protected Rigidbody2D rigidbody2D;
        
        public virtual void Start()
        {
            playerTransform = transform.parent.transform;
            gameObject.transform.parent = null;
            
            rigidbody2D = GetComponent<Rigidbody2D>();
            rigidbody2D.velocity = playerTransform.right * speed;
            startSpeed = rigidbody2D.velocity;
        }
        
        
        public virtual void Update()
        {
            _lifeTime += Time.deltaTime;
            if (_lifeTime >= deadTime)
            {
                Destroy(gameObject);
            }
        }
        
        public virtual void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("触发");
            if (other.CompareTag("Enemy"))
            {
                other.GetComponent<Enemy>().BeDamaged(damage);
            }
        }
    }
}
