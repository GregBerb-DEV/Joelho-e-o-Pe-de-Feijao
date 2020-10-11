using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<PlayerScore>() != null)
        {
            Debug.Log("Coletado");
            Destroy(gameObject);
        }
    }
}
