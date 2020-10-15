using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreDisplay = default;
    private int _currentScore = 0;

    void Start()
    {
        _currentScore = DataTrackerPlayer.Instance.TotalScore;
        _scoreDisplay.SetText($"x{_currentScore}");
    }

    public void IncreaseScore(int givenScore)
    {
        _currentScore += givenScore;
        _scoreDisplay.SetText($"x{_currentScore}");
    }

    public void DumpScore()
    {
        DataTrackerPlayer.Instance.TotalScore = _currentScore;
    }
}
