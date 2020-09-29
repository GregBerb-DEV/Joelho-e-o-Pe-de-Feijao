using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controle : MonoBehaviour
{
    [SerializeField] //mostra no editor mesmo sem estar público
    private int _moveSpeed = 10;
    [SerializeField]
    private int _jumpStrength = 1250;
    private float _movementHorizontalDirection;
    private bool _isGoingRight = true;
    private Rigidbody2D _rigidbody2D;
    private ICharacterController _characterController;
    private ICharacterMovement _characterMovement;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _characterController = GetComponent<ICharacterController>();
        _characterMovement = GetComponent<ICharacterMovement>();
    }

    //FixedUpdate não depende da framerate pra ser chamado
    void FixedUpdate()
    {
        _characterMovement.MovePlayer();
        TurnPlayerSprite(); //Extrair para componente no próprio sprite talvez
    }

    void MovePlayer()
    {
        _movementHorizontalDirection = _characterController.InputHorizontalMovement();
        if (_rigidbody2D)
            _rigidbody2D.velocity = new Vector2(_movementHorizontalDirection * _moveSpeed, _rigidbody2D.velocity.y);
        _characterController.InputJump();

    }

    void Jump()
    {
        if (_rigidbody2D)
            _rigidbody2D.AddForce(Vector2.up * _jumpStrength);
    }

    void TurnPlayerSprite()
    {
        Vector2 scale = transform.localScale;
        if (_movementHorizontalDirection > 0)
        {
            _isGoingRight = true;
        }
        else if (_movementHorizontalDirection < 0)
        {
            _isGoingRight = false;
        }
        if ((scale.x > 0 && !_isGoingRight) || (scale.x < 0 && _isGoingRight))
        {
            scale.x = scale.x * -1;
            transform.localScale = scale;
        }
    }
}
