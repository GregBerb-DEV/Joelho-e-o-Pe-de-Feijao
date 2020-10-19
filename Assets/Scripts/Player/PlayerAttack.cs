using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{

    [SerializeField]
    private float _initialTimeBetweenKicks = 0.5f;
    private float _currentTimeBetweenKicks;
    private PlayerInput _playerInput;
    private PlayerAnimation _playerAnimation;

    void Start()
    {
        _currentTimeBetweenKicks = _initialTimeBetweenKicks;
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {   
        if(_currentTimeBetweenKicks <= 0f){
            if (_playerInput.CheckForKickButton()){
                Attack();
                _currentTimeBetweenKicks = _initialTimeBetweenKicks;
            }
        }else{
            _currentTimeBetweenKicks -= Time.deltaTime;    
        }
            
    }

    void Attack()
    {
        _playerAnimation.PlayAttackAnimation();
        SoundManager.PlaySound("kick");
    }
}
