using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreText : MonoBehaviour
{
    void Start()
    {
        GetComponent<TextMeshProUGUI>().SetText($"Sua pontuação: {DataTrackerPlayer.Instance.TotalScore}");
    }
}
