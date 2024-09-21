using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private CoinCollector _coinCollector;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController playerController = other.GetComponent<PlayerController>();

        if (playerController != null)
        {
            _coinCollector.AddCoins();
            Destroy(gameObject);
        }
    }
}
