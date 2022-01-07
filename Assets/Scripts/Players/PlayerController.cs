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
        private bool _isPlatform;
        private float _currentAttackCd;
        private bool _isLadder;
        private bool _isClimbing;

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
        private void Run()
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
            _rigidbody2D.velocity = new Vector2(runSpeed * axisH, _rigidbody2D.velocity.y);
        }

        private void Jump()
        {
            //如果按住S或者没按space就不执行
            if (!Input.GetKeyDown(KeyCode.Space) || Input.GetKey(KeyCode.S)) return;
            
            if (_isGround)
            {
                currentJumpTimes = maxJumpTimes;
            }

            //跳跃次数为0也不执行
            if (currentJumpTimes <= 0) return;
            
            _animator.SetBool("Jump",true);
            _animator.SetBool("Fall",false);
            _rigidbody2D.velocity = Vector2.up * new Vector2(0, jumpSpeed);
            currentJumpTimes--;
        }
        
        public void DownPlatform()
        {
            if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Space))
            {
                Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Platform"), true);
                Invoke(nameof(RestoreCollision),0.5f);
            }
        }
        
        public void RestoreCollision()
        {
            Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Platform"), false);
        }
        
        public void ClimbLadder()
        {
            if (_isLadder)
            {
                var axisV = Input.GetAxis("Vertical");
                //如果处于梯子处，且有垂直输出，说明要爬梯子，但是脚部位于地面速度还向下的话就不会进入爬梯子状态
                if (axisV > 0 && !_isClimbing && !_isPlatform) //为了让其在爬梯子的时候只执行一次
                {
                    _rigidbody2D.gravityScale = 0f;
                    _animator.SetBool("Climb",true);
                    _animator.SetBool("Jump",false); //防止跳跃途中上梯子导致下梯子后jump为true而处于跳跃动画
                    _isClimbing = true;
                }
                if (_isClimbing)
                {
                    if (Math.Abs(axisV) < 0.5f)
                    {
                        _rigidbody2D.velocity = new Vector2(0, 0);
                        _animator.speed = 0; //暂停动画
                        return;
                    }
                    _animator.speed = 1;
                    _rigidbody2D.velocity = new Vector2(0, climbSpeed * axisV);
                    if (_isGround && axisV < 0)
                    {
                        _animator.SetBool("Climb",false);
                        _isClimbing = false;
                    }
                }
            }
        }

        /// <summary>
        /// 当前状态检测
        /// </summary>
        private void CheckStatus()
        {
            _isPlatform = _feet.IsTouchingLayers(LayerMask.GetMask("Platform"));
            _isGround = _feet.IsTouchingLayers(LayerMask.GetMask("Ground")) || _isPlatform;

            //如果用是不是0来判断，速度很小无限趋近于静止的时候也会导致无法变为静止状态
            if (Math.Abs(_rigidbody2D.velocity.x) < 0.5f && Math.Abs(_rigidbody2D.velocity.y) < 0.5f)
            {
                // Debug.Log("静止" + Time.time);
                _animator.SetBool("Idle",true);
            }
            else
            {
                _animator.SetBool("Idle",false);
            }
        
            if (_isGround)
            {
                _animator.SetBool("Fall",false);
                //防止刚开始爬的时候脚部还在地面导致一直无法切换攀爬变量
                if (!_isClimbing)
                { 
                    _animator.SetBool("Climb", false);
                }
                return;
            }

            if (!(_rigidbody2D.velocity.y < 0.1f) || _isGround) return;
            _animator.SetBool("Jump",false);
            _animator.SetBool("Fall", true);
        }

        /// <summary>
        /// 攻击行为
        /// </summary>
        private void Attack()
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

        /// <summary>
        /// 硬直
        /// </summary>
        /// <param name="recoverTime"></param>
        public void ExecuteRestoreHitStun(float recoverTime)
        {
            canControl = false;
            Invoke(nameof(RestoreFromHitStun), recoverTime);
        }

        private void RestoreFromHitStun() //从硬直中恢复
        {
            canControl = true;
        }
        
        /// <summary>
        /// Unity组件
        /// </summary>
        /// <param name="other"></param>
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Ladder"))
            {
                _isLadder = true;
                _gravityScale = _rigidbody2D.gravityScale;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Ladder"))
            {
                Debug.Log("脱离");
                //清除梯子相关的变量
                _isLadder = false;
                _isClimbing = false;
                _rigidbody2D.gravityScale = _gravityScale;
                //重置梯子相关的动画变量，并给予速度缓冲
                _animator.speed = 1;
                _animator.SetBool("Climb", false);
                _rigidbody2D.velocity = new Vector2(0, _rigidbody2D.velocity.y * 0.45f);
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
