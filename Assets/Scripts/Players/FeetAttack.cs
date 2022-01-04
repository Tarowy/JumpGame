using System;
using Enemies;
using UnityEngine;

namespace Players
{
    public class FeetAttack : MonoBehaviour
    {
        public PlayerHealth playerHealth;
        public float feetDamage;
        private bool _isPlatform;

        private void Update()
        {
            DownPlatform();
        }

        private void OnTriggerEnter2D (Collider2D col)
        {
            if (_isPlatform)
            {
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Platform"), false);
            }
            
            Debug.Log("碰撞："+col.gameObject);
            if (col.gameObject.CompareTag("Enemy"))
            {
                // Debug.Log("脚部碰撞");
                playerHealth.god = true;
                playerHealth.currentInvincibleTime = playerHealth.invincibleTime;
                col.gameObject.GetComponent<Enemy>().BeDamaged(feetDamage);
            }
        }
        
        public void DownPlatform()
        {
            if (Input.GetKeyDown(KeyCode.S) )
            {
                Debug.Log("下楼梯");
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Platform"), true);
                _isPlatform = true;
            }
        }
    }
}
