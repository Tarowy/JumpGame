using System.Globalization;
using Players;
using UnityEngine;

namespace Enemies
{
    public abstract class Enemy : MonoBehaviour
    {
        public float health;
        public float damage;
        public float speed;
        public float hitForce;
        public GameObject bloodEffect;
        public GameObject floatDamage;

        protected SpriteRenderer SpriteRenderer;
        protected Color OriginalColor;
        protected EnemyHealth EnemyHealth;
        
        public GameObject coin;

        public virtual void Awake()
        {
            SpriteRenderer = GetComponent<SpriteRenderer>();
            OriginalColor = SpriteRenderer.color;
            EnemyHealth = GetComponent<EnemyHealth>();
            EnemyHealth.maxHealth = health;
        }

        public virtual void Update()
        {
        
        }

        public virtual void OnCollisionEnter2D(Collision2D col)
        {
            Debug.Log(gameObject.name + "与" + col.gameObject.name + "碰撞了");
            var collision = col.gameObject;
            if (collision.CompareTag("Player"))
            {
                Vector2 direction = collision.transform.position - transform.position;
                collision.GetComponent<Rigidbody2D>().AddForce(direction * hitForce, ForceMode2D.Impulse);
                // Debug.Log(gameObject.name+"对"+collision.name+"产生了击退");
                collision.GetComponent<PlayerHealth>().BeDamaged(damage);
            }
        }

        public void BeDamaged(float damage)
        {
            Instantiate(floatDamage, transform.position + new Vector3(0, 1, 0), Quaternion.identity).transform
                .GetChild(0).GetComponent<TextMesh>().text = damage.ToString(CultureInfo.InvariantCulture);
            health -= damage;
            EnemyHealth.ChangeHealth(health);
            FlashRed();
            // Debug.Log(gameObject+"当前血量："+health);
            if (health <= 0)
            {
                Destroy(EnemyHealth.healthIns);
                Destroy(transform.parent.gameObject);
                if (gameObject != null)
                {
                    Instantiate(coin, transform.position, Quaternion.identity);
                }
            }

            Instantiate(bloodEffect, transform.position, Quaternion.identity);
        }

        public void FlashRed()
        {
            SpriteRenderer.color = Color.red;
            Invoke("ResetColor",0.5f);
        }

        public void ResetColor()
        {
            SpriteRenderer.color = OriginalColor;
        }
    }
}
