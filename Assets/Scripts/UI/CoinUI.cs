using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinUI : MonoBehaviour
{
    public int startCoinQuantity;
    public int currentCoinQuantity;
    public Text coinText;

    private void Start()
    {
        currentCoinQuantity = startCoinQuantity;
        coinText.text = startCoinQuantity.ToString();
    }

    public void ChangeCoinQuantity()
    {
        coinText.text = (++currentCoinQuantity).ToString();
    }
}
