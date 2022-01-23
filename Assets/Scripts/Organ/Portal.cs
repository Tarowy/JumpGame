using System;
using UnityEngine;

namespace Organ
{
    public class Portal : MonoBehaviour
    {
        private BoxCollider2D _doorFir;
        private BoxCollider2D _doorSec;
        
        public float activeCd;
        private float _currentActiveCd;

        private void Awake()
        {
            _doorFir = transform.GetChild(0).gameObject.GetComponent<BoxCollider2D>();
            _doorSec = transform.GetChild(1).gameObject.GetComponent<BoxCollider2D>();
        }

        private void Start()
        {
            _currentActiveCd = activeCd;
        }

        private void Update()
        {
            if (_currentActiveCd > 0)
            {
                _currentActiveCd -= Time.deltaTime;
            }
        }

        public void DeliverPlayer(Transform target)
        {
            if (_currentActiveCd > 0) return;

            target.position = _doorFir.IsTouchingLayers(LayerMask.GetMask("Player"))
                ? _doorSec.transform.position
                : _doorFir.transform.position;
            
            _currentActiveCd = activeCd;
        }
    }
}
