using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private static Animator _animator;

    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public static void Shake()
    {
        _animator.SetTrigger("CamShake");
    }
}