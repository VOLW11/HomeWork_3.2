using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private float _roundTime;

    private int _coinsToWin = 10;
    private float _currentTime;
    private string _WinGame = "Вы победили! Собрано необходимое колличество монет: ";
    private string _gameOver = "Время вышло! Конец игры.";
    private bool _isPlaying;

    private void Awake()
    {
        _isPlaying = true;
    }

    private void Update()
    {
        StartedTheGame();
        GameOver();
    }

    private void StartedTheGame()
    {
        if (_currentTime < _roundTime && _isPlaying)
        {
            _currentTime += Time.deltaTime;

            Debug.Log("Time: " + _currentTime);

            WinTheGame();
        }
    }

    private void WinTheGame()
    {
        if (_ball.CoinsValue == _coinsToWin)
        {
            _ball.enabled = false;
            _isPlaying = false;
            Debug.Log(_WinGame + _coinsToWin);
        }
    }

    private void GameOver()
    {
        if (_currentTime >= _roundTime && _isPlaying)
        {
            Debug.Log(_gameOver);
            Destroy(_ball.gameObject);
            _isPlaying = false;
        }
    }
}
