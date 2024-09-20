using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
   [SerializeField] private Ball _ball;
    private int _coinsToWin = 10;
    private float _currentTime;
    private string _WinGame = "Вы победили!";
    private string _gameOver = "Время вышло!";
    private bool _isPlaying = true;

    [SerializeField] private float _roundTime;

    private void Update()
    {
        if (_currentTime < _roundTime)
        {
            _currentTime += Time.deltaTime;

            Debug.Log("Time: " + _currentTime);

        }

        if (_currentTime >= _roundTime && _isPlaying)
        {
            Debug.Log(_gameOver);
            Destroy(_ball.gameObject);
            _isPlaying = false;
        }

        if (_ball.Coin == _coinsToWin)
        {
            _ball.enabled = false;
            Debug.Log(_WinGame);
        }
    }
}
