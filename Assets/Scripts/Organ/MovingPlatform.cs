using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class MovingPlatform : MonoBehaviour
{
    public float moveSpeed;
    public float waitTime;
    [HideInInspector] public float currentWaitTime;
    public Transform[] movePos;
    private int _posIndex;

    private Transform _playerParent;
    
    // Start is called before the first frame update
    void Start()
    {
        _posIndex = Random.Range(0, movePos.Length);
        currentWaitTime = waitTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (KeepMove())
        {
            if (ReduceTime())
            {
                _posIndex = ++_posIndex > (movePos.Length - 1) ? 0 : _posIndex;
            }
        }
    }

    private bool KeepMove()
    {
        
        if (Vector2.Distance(transform.position, movePos[_posIndex].position) <= 0.1f)
        {
            return true;
        }
        transform.position =
            Vector2.MoveTowards(transform.position, movePos[_posIndex].position, moveSpeed * Time.deltaTime);
        return false;
    }

    private bool ReduceTime()
    {
        if (currentWaitTime <= 0)
        {
            currentWaitTime = waitTime;
            return true;
        }
        currentWaitTime -= Time.deltaTime;
        return false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("feet") && other.GetType().ToString().Equals("UnityEngine.BoxCollider2D"))
        {
            Debug.Log("................................");
            _playerParent = other.transform.parent.parent;
            other.transform.parent.parent = transform;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("feet") && other.GetType().ToString().Equals("UnityEngine.BoxCollider2D"))
        {
            other.gameObject.transform.parent.parent = _playerParent;
        }
    }
}
