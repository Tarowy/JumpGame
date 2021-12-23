using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public int health;
    public int damage;

    public virtual void Start()
    {
        
    }

    public virtual void Update()
    {
        
    }

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
       
    }

    public void BeDamaged(int damage)
    {
        health -= damage;
        Debug.Log(gameObject+"当前血量："+health);
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
