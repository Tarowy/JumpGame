using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Run();
    }

    private void FixedUpdate()
    {
        Run();
    }

    public void Run()
    {
        var axisH = Input.GetAxis("Horizontal");
        if (axisH == 0)
        {
            _animator.SetBool("Run",false);
            return;
        }
        _animator.SetBool("Run",true);

        if (axisH > 0.1f)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        if (axisH < -0.1f)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }

        //直接改变刚体速度
        Vector2 speed = new Vector2(runSpeed * axisH, _rigidbody2D.velocity.y);
        _rigidbody2D.velocity = speed;
    }
}
