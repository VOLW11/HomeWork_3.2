using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        CoinCollector coinCollector = other.GetComponent<CoinCollector>();

        if (coinCollector != null)
        {
            coinCollector.AddCoins();
            Destroy(gameObject);
        }
    }
}
