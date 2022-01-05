using System;
using Enemies;
using UnityEngine;

namespace Players
{
    public class FeetAttack : MonoBehaviour
    {
        public PlayerHealth playerHealth;
        public float feetDamage;
        
        private void OnTriggerEnter2D (Collider2D col)
        {
            // Debug.Log("碰撞："+col.gameObject);
            if (col.gameObject.CompareTag("Enemy"))
            {
                // Debug.Log("脚部碰撞");
                playerHealth.god = true;
                playerHealth.currentInvincibleTime = playerHealth.invincibleTime;
                col.gameObject.GetComponent<Enemy>().BeDamaged(feetDamage);
            }
        }
    }
}
