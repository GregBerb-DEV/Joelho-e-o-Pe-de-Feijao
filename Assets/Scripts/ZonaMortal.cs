using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaMortal : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<Saude>().danoMax();
        }
        else
        {
            Object.Destroy(other.gameObject);
        }
    }

}
