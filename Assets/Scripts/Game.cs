using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private CoinCollector _coinCollector;
    [SerializeField] private float _roundTime;

    private int _coinsToWin = 10;
    private float _currentTime;
    private string _winGame = "Вы победили! Собрано необходимое колличество монет: ";
    private string _gameOver = "Время вышло! Конец игры.";
    private bool _isPlaying;

    private void Awake()
    {
        _isPlaying = true;
    }

    private void Update()
    {
        TimeCount();

        if (_coinCollector.CoinsValue == _coinsToWin && _isPlaying)
            WinTheGame();

        if (_currentTime >= _roundTime && _isPlaying)
            GameOver();
    }

    private void TimeCount()
    {
        if (_currentTime < _roundTime && _isPlaying)
        {
            _currentTime += Time.deltaTime;

            Debug.Log("Time: " + _currentTime);
        }
    }

    private void WinTheGame()
    {
        _playerController.RemoveForces();
        _isPlaying = false;
        Debug.Log(_winGame + _coinsToWin);
    }

    private void GameOver()
    {
        Debug.Log(_gameOver);
        Destroy(_playerController.gameObject);
        _isPlaying = false;
    }
}
