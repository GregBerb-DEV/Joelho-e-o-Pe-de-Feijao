using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerScore))]
public class PlayerWinGame : MonoBehaviour
{
    [SerializeField]
    private string _nextLevelName;
    [SerializeField]
    private int _scoreToWin = 15;

    private PlayerScore _playerScore;

    void Start()
    {
        _playerScore = GetComponent<PlayerScore>();
    }

    public void Win()
    {
        if (_playerScore._currentScore >= _scoreToWin)
        {
            _playerScore.DumpScore();
            SceneManager.LoadScene(_nextLevelName);
        }
    }
}
