using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Organ
{
    public class TreasureBox : MonoBehaviour
    {
        public GameObject reward;
        public int rewardNumbers;
        
        private Animator _animator;
        private bool _isOpened;
        private bool _canOpen;

        public float radius;
        public float angleDegree; //角度

        private void Start()
        {
            _animator = transform.GetComponent<Animator>();
        }

        private void Update()
        {
            if (_canOpen && Input.GetKeyDown(KeyCode.W))
            {
                OpenBox();
            }
        }
        
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _canOpen = true;
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _canOpen = false;
            }
        }

        public void OpenBox()
        {
            if (!_isOpened)
            {
                _animator.SetTrigger("Open");
                _isOpened = true;
            }
        }

        public void GiveRewardExecutor()
        {
            StartCoroutine(GiveReward());
        }

        private IEnumerator GiveReward()
        {
            //角度转弧度
            float angle = angleDegree * Mathf.Deg2Rad; //扇形弧度
            float currentAngle = (90 + angleDegree/2) * Mathf.Deg2Rad; //第一个三角形的起始弧度
            //每份三角形的圆心角度数
            float deltaAngle = angle / (rewardNumbers-1); 
            
            for (var i = 0; i < rewardNumbers; i++)
            {
                //对金币在一个扇形之内的随机径向方向施加力
                var rewardIns = Instantiate(reward, transform.position, Quaternion.identity,transform);

                float x = radius * Mathf.Cos(currentAngle);
                float y = radius * Mathf.Sin(currentAngle);

                rewardIns.GetComponent<Rigidbody2D>().AddForce(new Vector2(x,y), ForceMode2D.Impulse);

                currentAngle -= deltaAngle;
                
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
