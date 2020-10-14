using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerScore : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreDisplay = default;
    public int CurrentScore = 0;

    void Start()
    {
        CurrentScore = ScoreTracker.Instance.TotalScore;
        _scoreDisplay.SetText($"x{CurrentScore}");
    }

    public void IncreaseScore(int givenScore)
    {
        CurrentScore += givenScore;
        _scoreDisplay.SetText($"x{CurrentScore}");
    }

    public void DumpScore()
    {
        ScoreTracker.Instance.TotalScore = CurrentScore;
    }
}
