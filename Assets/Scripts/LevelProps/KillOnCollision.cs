using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.GetComponent<IHaveHealth>() != null)
            other.gameObject.GetComponent<IHaveHealth>().Kill();
    }
}