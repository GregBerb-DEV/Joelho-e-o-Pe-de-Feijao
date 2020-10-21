using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WinText : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI scoreText = default;

    void Start()
    {
        scoreText.SetText($"Sua pontuação: {DataTrackerPlayer.Instance.TotalScore}");
    }
}
