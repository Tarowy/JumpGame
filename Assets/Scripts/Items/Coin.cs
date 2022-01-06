using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        Invoke("ChangeTag", 1f);
    }

    public void ChangeTag()
    {
        gameObject.tag = "Coin";
    }
}
