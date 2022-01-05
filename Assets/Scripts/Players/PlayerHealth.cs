using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Players
{
    public class PlayerHealth : MonoBehaviour
    {
        //血量相关
        public float maxHealth;
        [HideInInspector]
        public float currentHealth;
        private PlayerHealthBar _playerHealthBar;
        //受伤相关
        public int blinkTimes;
        public float blinkInterval;
        public Image screenFlash;
        private Animator _screenFlashAnimator;
        private bool _isDeath;
        //无敌相关
        public float invincibleTime;
        [HideInInspector]
        public float currentInvincibleTime;
        public bool god;
        //组件
        [HideInInspector]
        public Animator animator;
        private Renderer _renderer;

        // Start is called before the first frame update
        public void Start()
        {
            _playerHealthBar = GetComponent<PlayerHealthBar>();
            _screenFlashAnimator = screenFlash.GetComponent<Animator>();
            _renderer = GetComponent<Renderer>();
            _playerHealthBar.ChangeHealthBar(currentHealth);
            
            currentInvincibleTime = invincibleTime;
            currentHealth = maxHealth;
            _playerHealthBar.maxHealth = maxHealth;
            _playerHealthBar.ChangeHealthBar(currentHealth);
        }

        // Update is called once per frame
        void Update()
        {
            ReduceInvincibleTime();
        }
        
        /// <summary>
        /// 受伤行为
        /// </summary>
        /// <param name="damage"></param> 敌人施加的伤害值
        public bool BeDamaged(float damage)
        {
            // Debug.Log("无敌");
            if (!god && !_isDeath)
            {
                currentHealth -= damage;
                _playerHealthBar.ChangeHealthBar(currentHealth);
                god = true;
                // Debug.Log("当前血量：" + currentHealth);
                //如果当前血量太低屏幕会闪红
                if (currentHealth <= maxHealth * 0.25)
                {
                    _screenFlashAnimator.SetTrigger("flash");
                }
                if (currentHealth <= 0)
                {
                    _isDeath = true;
                    animator.SetTrigger("Death");
                }
                BlinkPlayer();
                CameraFollow.cameraInfo.Shake();
            }
            return _isDeath;
        }
        public void ReduceInvincibleTime()
        {
            if (god)
            {
                currentInvincibleTime -= Time.deltaTime;
                if (currentInvincibleTime <= 0)
                {
                    god = false;
                }
            }
        }

        /// <summary>
        /// 受伤后闪烁
        /// </summary>
        public void BlinkPlayer()
        {
            StartCoroutine(MultiplyBlink());
        }
    
        IEnumerator MultiplyBlink()
        {
            for (int i = 0; i < blinkTimes * 2; i++)
            {
                _renderer.enabled = !_renderer.enabled;
                yield return new WaitForSeconds(blinkInterval);
            }
        }
    }
}
