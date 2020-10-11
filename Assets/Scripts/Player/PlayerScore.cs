using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public void PickUpItem(int givenScore)
    {
        ScoreTracker.Instance.Score += givenScore;
        Debug.Log(ScoreTracker.Instance.Score);
    }
}
