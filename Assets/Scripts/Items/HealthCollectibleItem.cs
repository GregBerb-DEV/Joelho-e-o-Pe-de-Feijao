using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectibleItem : MonoBehaviour
{
    [SerializeField]
    private int _givenHealth = 1;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerHealth>() != null)
        {
            other.GetComponent<PlayerHealth>().IncreaseHealth(_givenHealth);
            Destroy(gameObject);
        }
    }
}