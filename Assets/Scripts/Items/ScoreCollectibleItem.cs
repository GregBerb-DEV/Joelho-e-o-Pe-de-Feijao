using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCollectibleItem : MonoBehaviour
{
    [SerializeField]
    private int _score = 1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerScore>() != null)
        {
            other.GetComponent<PlayerScore>().IncreaseScore(_score);
            Destroy(gameObject);
        }
    }
}