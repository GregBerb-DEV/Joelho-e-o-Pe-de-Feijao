using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private const string ATTACK_BOOL = "Attack";
    private const string ON_GROUND_TRIGGER = "OnGround";
    private const string RUNNING_BOOL = "Running";
    private const string IS_DEAD_TRIGGER = "IsDead";
    private const string TAKE_DAMAGE_TRIGGER = "TakeDamage";

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

    public void PlayAttackAnimation()
    {
        _animator.SetBool(ATTACK_BOOL, true);
    }

    public void SetOnGroundTrigger(bool onGround)
    {
        _animator.SetBool(ON_GROUND_TRIGGER, onGround);
    }

    public void SetRunning(bool isRunning)
    {
        _animator.SetBool(RUNNING_BOOL, isRunning);
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
        _animator.SetTrigger(IS_DEAD_TRIGGER);
    }

    public void SetDamageTrigger()
    {
        _animator.SetTrigger(TAKE_DAMAGE_TRIGGER);
    }
}
