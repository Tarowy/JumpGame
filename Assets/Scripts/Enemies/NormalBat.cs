using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBat : Enemy
{
    public Transform leftDownPos;
    public Transform rightUpPos;
    [HideInInspector]
    public Vector2 movePos;

    public float startWaitTime;
    [HideInInspector]
    public float waitTime;

    public override void Start()
    {
        base.Start();
        waitTime = startWaitTime;
        movePos = GenerateRandomPos();
    }

    public override void Update()
    {
        base.Update();
        MoveToPos();
    }

    public void MoveToPos()
    {
        transform.position = Vector2.MoveTowards(transform.position, movePos, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, movePos) < 0.1f)
        {
            waitTime -= Time.deltaTime;
            if (waitTime <= 0)
            {
                movePos = GenerateRandomPos();
                waitTime = startWaitTime;
            }
        }
    }

    public Vector2 GenerateRandomPos()
    {
        return new Vector2(Random.Range(leftDownPos.position.x, rightUpPos.position.x),
            Random.Range(leftDownPos.position.y, rightUpPos.position.y));
    }
}
