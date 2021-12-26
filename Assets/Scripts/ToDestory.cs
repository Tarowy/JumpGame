using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToDestory : MonoBehaviour
{
    public float destoryTime;
    
    // Start is called before the first frame update
    public void Start()
    {
        Destroy(gameObject,destoryTime);
    }
}
