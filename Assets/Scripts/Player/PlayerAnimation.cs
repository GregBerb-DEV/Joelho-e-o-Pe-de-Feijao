using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private const string ATTACK_BOOL = "Attack";
    private const string ON_GROUND_BOOL = "OnGround";
    private const string RUNNING_BOOL = "Running";
    private const string DOUBLE_JUMPING_BOOL = "DoubleJump";
    private const string IS_DEAD_TRIGGER = "IsDead";
    private const string TAKE_DAMAGE_TRIGGER = "TakeDamage";
    private const string CAM_SHAKE_TRIGGER = "CamShake";

    // Start is called before the first frame update
    void Start()
    {
        _animator = gameObject.GetComponent<Animator>();
    }

#region bools

    public void PlayAttackAnimation()
    {
        _animator.SetBool(ATTACK_BOOL, true);
    }

    public void SetOnGround(bool isGrounded)
    {
        _animator.SetBool(ON_GROUND_BOOL, isGrounded);
    }

    public void SetDoubleJumping(bool isJumping)
    {
        _animator.SetBool(DOUBLE_JUMPING_BOOL, isJumping);
    }

    public void SetRunning(float movementDirection)
    {
        bool isRunning = movementDirection != 0;
        _animator.SetBool(RUNNING_BOOL, isRunning);
    }

#endregion bools

#region triggers

    public void SetDeathTrigger()
    {
        _animator.SetTrigger(IS_DEAD_TRIGGER);
    }

    public void SetDamageTrigger()
    {
        _animator.SetTrigger(TAKE_DAMAGE_TRIGGER);
    }

    public void SetCamShakeTrigger()
    {
        _animator.SetTrigger(CAM_SHAKE_TRIGGER);
    }
}

#endregion triggers

