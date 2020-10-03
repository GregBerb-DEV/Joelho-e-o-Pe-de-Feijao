using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void PlayAttackAnimation()
    {
        _animator.SetBool("Attack", true);
    }

    public void SetOnGroundTrigger(bool onGround)
    {
        _animator.SetBool("OnGround", onGround);
    }

    public void SetRunning(bool isRunning)
    {
        _animator.SetBool("Running", isRunning);
    }

    public void CheckForRunning(float movementDirection)
    {
        if (movementDirection != 0)
        {
            SetRunning(true);
        }
        else
        {
            SetRunning(false);
        }
    }

    public void PlayDeathAnimation()
    {
        _animator.SetTrigger("IsDead");
    }
}
