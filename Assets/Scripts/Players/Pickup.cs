using System.Collections;
using System.Collections.Generic;
using Items;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public CoinUI coinUI;
    public float flySpeed;

    private void OnTriggerStay2D(Collider2D other)
    {
        //玩家在触发范围内会自动飞向玩家
        if (other.CompareTag("Coin"))
        {
            other.transform.position = Vector2.MoveTowards(other.transform.position, gameObject.transform.position,
                flySpeed * Time.deltaTime);
            if (Vector2.Distance(gameObject.transform.position, other.transform.position) <= 0.5)
            {
                AudioSource.PlayClipAtPoint(other.GetComponent<Coin>().coinSound, other.transform.position);
                Destroy(other.gameObject);
                coinUI.ChangeCoinQuantity();
            }
        }
    }
}
