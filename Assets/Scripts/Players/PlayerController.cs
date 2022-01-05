using System;
using System.Collections;
using Tools;
using UnityEngine;
using UnityEngine.UI;

namespace Players
{
    public class PlayerController : MonoBehaviour
    {
        //行动相关
        public float runSpeed;
        public int maxJumpTimes;
        // [HideInInspector]
        public int currentJumpTimes;
        public float jumpSpeed;
        public bool canControl;
        public float climbSpeed;
        private float _gravityScale;
        //攻击相关
        public float attackCd;
        //组件
        private Rigidbody2D _rigidbody2D;
        private Animator _animator;
        private BoxCollider2D _feet;
        private PolygonCollider2D _attackCollider2D;
        private PlayerHealth _playerHealth;
        //判断变量
        private bool _isGround;
        private float _currentAttackCd;
        private bool _isLadder;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _feet = transform.GetChild(1).GetComponent<BoxCollider2D>();
            _attackCollider2D = transform.GetChild(0).GetComponent<PolygonCollider2D>();
            _playerHealth = GetComponent<PlayerHealth>();
            _playerHealth.animator = _animator;

            canControl = true;
        }

        // Update is called once per frame
        void Update()
        {
            if (canControl)
            {
                Jump();
                Attack();
                DownPlatform();
                ClimbLadder();
            }
            CheckStatus();
        }

        private void FixedUpdate()
        {
            if (canControl)
            {
                Run();
            }
        }

        /// <summary>
        /// 行动控制
        /// </summary>
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
            if (!Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.S))
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

        /// <summary>
        /// 当前状态检测
        /// </summary>
        public void CheckStatus()
        {
            _isGround = _feet.IsTouchingLayers(LayerMask.GetMask("Ground")) 
                        || _feet.IsTouchingLayers(LayerMask.GetMask("Platform"));

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

        public void RestoreCollision()
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Platform"), false);
        }

        /// <summary>
        /// 攻击行为
        /// </summary>
        public void Attack()
        {
            if (_currentAttackCd > 0)
            {
                _currentAttackCd -= Time.deltaTime;
            }

            if (!_animator.GetCurrentAnimatorStateInfo(0).IsName("Attack") && Input.GetKey(KeyCode.J) && _currentAttackCd <= 0)
            {
                _animator.SetTrigger("Attack");
                _currentAttackCd = attackCd;
            }
        }

        public void ExecuteRestoreHitStun(float recoverTime)
        {
            canControl = false;
            Invoke(nameof(RestoreFromHitStun), recoverTime);
        }

        private void RestoreFromHitStun() //从硬直中恢复
        {
            canControl = true;
        }
        
        public void DownPlatform()
        {
            if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Space))
            {
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Platform"), true);
                Invoke(nameof(RestoreCollision),0.5f);
            }
        }

        public void ClimbLadder()
        {
            if (_isLadder)
            {
                var axisV = Input.GetAxis("Vertical");
                if (Math.Abs(axisV) > 0.5f)
                {
                    Debug.Log("攀爬...");
                    _rigidbody2D.isKinematic = true;
                    // _rigidbody2D.gravityScale = 0.1f;
                    _rigidbody2D.velocity = new Vector2(0, climbSpeed * axisV);
                    _animator.SetBool("Climb",true);
                }
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("TriggerEnter2D："+other.name+"---"+Time.time);
            if (other.CompareTag("Ladder"))
            {
                _isLadder = true;
                // _gravityScale = _rigidbody2D.gravityScale;
                Debug.Log("_gravityScaleStart:"+_gravityScale+"---"+Time.time);
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            Debug.Log("TriggerExit2D："+other.name+"---"+Time.time);
            if (other.CompareTag("Ladder"))
            {
                _isLadder = false;
                // _rigidbody2D.gravityScale = _gravityScale;
                _rigidbody2D.isKinematic = false;
                Debug.Log("_gravityScaleExit:"+_gravityScale+"---"+Time.time);
                _animator.SetBool("Climb",false);
            }
        }

        /// <summary>
        /// 动画使用的事件
        /// </summary>
        public void EnableHitBox()
        {
            _attackCollider2D.enabled = true;
        }
    
        public void DisableHitBox()
        {
            _attackCollider2D.enabled = false;
        }

        public void DisableControl()
        {
            canControl = false;
            _feet.enabled = false;
        }

        public void BeKilled()
        {
            Debug.Log("玩家已死亡");
            _rigidbody2D.velocity = new Vector2(0, 0);
            // Destroy(gameObject);
        }
    }
}
