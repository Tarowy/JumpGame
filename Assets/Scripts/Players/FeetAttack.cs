using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeetAttack : MonoBehaviour
{
    public PlayerController playerController;
    
    private void OnTriggerEnter2D (Collider2D col)
    {
        Debug.Log("碰撞："+col.gameObject);
        
        if (col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("脚部碰撞");
            playerController.god = true;
            playerController.currentInvincibleTime = playerController.invincibleTime;
            Debug.Log("无敌" + Time.time);
            col.gameObject.GetComponent<Enemy>().BeDamaged(0.5f);
        }
    }
}
