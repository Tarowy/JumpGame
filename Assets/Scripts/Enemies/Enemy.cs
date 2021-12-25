using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    public float health;
    public float damage;
    public float speed;
    public float hitForce;
    public GameObject bloodEffect;

    protected SpriteRenderer _spriteRenderer;
    protected Color _originalColor;

    public virtual void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originalColor = _spriteRenderer.color;
    }
    
    public virtual void Start()
    {
        
    }

    public virtual void Update()
    {
        
    }

    public virtual void OnCollisionEnter2D(Collision2D col)
    {
        var collision = col.gameObject;
        if (collision.CompareTag("Player"))
        {
            Vector2 direction = collision.transform.position - transform.position;
            collision.GetComponent<Rigidbody2D>().AddForce(direction * hitForce, ForceMode2D.Impulse);
            Debug.Log(gameObject.name+"对"+collision.name+"产生了击退");
            collision.GetComponent<PlayerController>().BeDamaged(damage);
        }
    }

    public void BeDamaged(float damage)
    {
        health -= damage;
        FlashRed();
        Debug.Log(gameObject+"当前血量："+health);
        if (health <= 0)
        {
            Destroy(transform.parent.gameObject);
        }

        Instantiate(bloodEffect, transform.position, Quaternion.identity);
    }

    public void FlashRed()
    {
        _spriteRenderer.color = Color.red;
        Invoke("ResetColor",0.5f);
    }

    public void ResetColor()
    {
        _spriteRenderer.color = _originalColor;
    }
}
