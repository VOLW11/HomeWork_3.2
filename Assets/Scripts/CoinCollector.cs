using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    public int CoinsValue { get; private set; }

    public void AddCoins()
    {
        CoinsValue++;
    }
}
