using System;
using UnityEngine;
using Weapon;

namespace Players
{
    public class Throwable : MonoBehaviour
    {
        public GameObject projectile;
        public GameObject bomb;
        public float throwSpeedRate;

        private Rigidbody2D _rigidbody2D;
        private InputSystem _inputSystem;
        
        private void OnEnable()
        {
            _inputSystem.JumpGame.Enable();
        }

        private void OnDisable()
        {
            _inputSystem.JumpGame.Disable();
        }

        private void Awake()
        {
            _inputSystem = new InputSystem();
            _inputSystem.JumpGame.Throw.started += ctx => ThrowWeapon();
            _inputSystem.JumpGame.Bomb.started += ctx => ThrowBomb();
            
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }
        
        private void ThrowWeapon()
        {
            if (projectile==null) return;
            
            Instantiate(projectile, transform.position, Quaternion.identity, gameObject.transform);
        }

        private void ThrowBomb()
        {
            if(bomb==null) return;
            
            Instantiate(bomb, transform.position, Quaternion.identity, gameObject.transform).GetComponent<Bomb>()
                .baseSpeed = new Vector2(_rigidbody2D.velocity.x * throwSpeedRate, _rigidbody2D.velocity.y);
        }
    }
}
