using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerInput _playerInput;
    private PlayerAnimation _playerAnimation;

    void Start()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        if (_playerInput.CheckForKickButton())
            Attack();
    }

    void Attack()
    {
        _playerAnimation.PlayAttackAnimation();
        SoundManager.PlaySound("tapa");
    }
}
