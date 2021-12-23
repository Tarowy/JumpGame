using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runSpeed;
    [HideInInspector]
    public int maxJumpTimes;
    public int currentJumpTimes;
    public float jumpSpeed;
    public float attackCD;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private BoxCollider2D _feet;
    private PolygonCollider2D _attackCollider2D;

    private bool _isGround;
    private float _currentAttackCD;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _feet = GetComponent<BoxCollider2D>();
        _attackCollider2D = transform.GetChild(0).GetComponent<PolygonCollider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        CheckStatus();
        Attack();
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

    public void Jump()
    {
        if (!Input.GetKeyDown(KeyCode.Space))
        {
            return;
        }
        
        if (_isGround)
        {
            currentJumpTimes = maxJumpTimes;
        }
        
        if (currentJumpTimes > 0)
        {
            _animator.SetBool("Jump",true);
            _animator.SetBool("Fall",false);
            _rigidbody2D.velocity = Vector2.up * new Vector2(0, jumpSpeed);
            currentJumpTimes--;
        }
    }

    public void CheckStatus()
    {
        _isGround = _feet.IsTouchingLayers(LayerMask.GetMask("Ground"));
        
        if (_rigidbody2D.velocity == new Vector2(0, 0))
        {
            _animator.SetBool("Idle",true);
        }
        else
        {
            _animator.SetBool("Idle",false);
        }
        
        if (_isGround)
        {
            _animator.SetBool("Fall",false);
            return;
        }

        if (_rigidbody2D.velocity.y < 0f && !_isGround)
        {
            _animator.SetBool("Jump",false);
            _animator.SetBool("Fall", true);
        }
    }

    public void Attack()
    {
        if (_currentAttackCD > 0)
        {
            _currentAttackCD -= Time.deltaTime;
        }

        if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && Input.GetKey(KeyCode.J) && _currentAttackCD <= 0)
        {
            _animator.SetTrigger("Attack");
            _currentAttackCD = attackCD;
        }
    }

    public void EnableHitBox()
    {
        _attackCollider2D.enabled = true;
    }

    public void DisableHitBox()
    {
        _attackCollider2D.enabled = false;
    }
}
