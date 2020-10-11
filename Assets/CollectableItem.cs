using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    [SerializeField]
    private int _score = 1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerScore>() != null)
        {
            other.GetComponent<PlayerScore>().PickUpItem(_score);
            Destroy(gameObject);
        }
    }
}
