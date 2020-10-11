using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int CurrentScore = 0;

    void Start()
    {
        CurrentScore = ScoreTracker.Instance.TotalScore;
    }
    public void PickUpItem(int givenScore)
    {
        CurrentScore += givenScore;
    }

    public void DumpScore()
    {
        ScoreTracker.Instance.TotalScore = CurrentScore;
    }
}
