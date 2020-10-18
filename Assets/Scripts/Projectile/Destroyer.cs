using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    [SerializeField]
    private float _timeToDestroy = 1f;
    void Start()
    {
        Destroy(gameObject, _timeToDestroy);
    }
}
