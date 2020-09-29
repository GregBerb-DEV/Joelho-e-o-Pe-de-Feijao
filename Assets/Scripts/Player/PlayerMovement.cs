using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, ICharacterMovement
{
    [SerializeField] //mostra no editor mesmo sem estar público
    private int _moveSpeed = 10;
    [SerializeField]
    private int _jumpStrength = 1250;
    private float _movementHorizontalDirection;
    private bool _isGoingRight = true;
    private Rigidbody2D _rigidbody2D;
    private ICharacterInput _characterInput;
    private ICharacterMovement _characterMovement;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _characterInput = GetComponent<ICharacterInput>();
        _characterMovement = GetComponent<ICharacterMovement>();
    }

    //FixedUpdate não depende da framerate pra ser chamado
    void FixedUpdate()
    {
        CharacterMove();
        if (_characterInput.InputJump())
            CharacterJump();
        TurnPlayerSprite(); //Extrair para componente no próprio sprite talvez
    }

    public void CharacterMove()
    {
        _movementHorizontalDirection = _characterInput.InputHorizontalMovement();
        if (_rigidbody2D)
            _rigidbody2D.velocity = new Vector2(_movementHorizontalDirection * _moveSpeed, _rigidbody2D.velocity.y);

    }

    public void CharacterJump()
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
