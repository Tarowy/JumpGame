using System;
using System.Collections;
using System.Collections.Generic;
using Enemies;
using Organ;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int damage;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy"))
        {
            col.GetComponent<Enemy>().BeDamaged(damage);
        }

        if (col.CompareTag("TreasureBox"))
        {
            col.GetComponent<TreasureBox>()?.OpenBox();
        }
    }
}
