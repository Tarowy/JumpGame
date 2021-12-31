using System;
using Players;
using UnityEngine;

namespace Traps
{
    public class Spike : MonoBehaviour
    {
        public float damagePercent;
        public float hitForce;
        public Vector2 direction;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                // Debug.Log(gameObject.name+"伤害了"+other.gameObject.name);
                var playerHealth = other.GetComponent<PlayerHealth>();
                var isDeath = playerHealth.BeDamaged(playerHealth.maxHealth * damagePercent);
                if (isDeath)
                {
                    return;
                }
                
                other.GetComponent<Rigidbody2D>().AddForce(direction * hitForce, ForceMode2D.Impulse);
            }
        }
    }
}
