using System;
using UnityEngine;

namespace Organ
{
    public class TrapPlatform : MonoBehaviour
    {
        private Animator _animator;
        private BoxCollider2D _boxCollider2D;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _boxCollider2D = GetComponent<BoxCollider2D>();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log(other.gameObject.name+":"+Time.deltaTime);
            if (other.gameObject.CompareTag("feet") && other.GetType().ToString().Equals("UnityEngine.BoxCollider2D"))
            {
                _animator.SetTrigger("Broke");
            }
        }

        public void CancelCollisionBox()
        {
            Destroy(_boxCollider2D);
        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}
