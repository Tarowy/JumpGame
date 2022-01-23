using System;
using Players;
using UnityEngine;

namespace Traps
{
    public class Spike : MonoBehaviour
    {
        public float damagePercent;
        public float hitForce;
        public float hitStunTime;
        public Vector2 direction;

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player") && other.GetType().ToString().Equals("UnityEngine.CapsuleCollider2D"))
            {
                Debug.Log("刺入");
                
                var playerHealth = other.GetComponent<PlayerHealth>();
                if (playerHealth.BeDamaged(playerHealth.maxHealth * damagePercent))
                {
                    return;
                }
                other.GetComponent<PlayerController>().ExecuteRestoreHitStun(hitStunTime);

                other.GetComponent<Rigidbody2D>().AddForce(direction * hitForce, ForceMode2D.Impulse);
                Debug.Log("受击力度："+hitForce);
            }
        }
    }
}
