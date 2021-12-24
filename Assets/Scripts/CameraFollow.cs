using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform playerPos;
    public float smoothing;

    private void LateUpdate()
    {
        if (playerPos != null && (playerPos.position != transform.position))
        {
            transform.position = Vector3.Lerp(transform.position, playerPos.position+new Vector3(0,1,0), smoothing);
        }
    }
}
