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
    private Rigidbody2D _rigidbody2D;
    private ICharacterInput _characterInput;
    private ICharacterMovement _characterMovement;
    private ICharacterSpriteManager _characterSpriteManager;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _characterInput = GetComponent<ICharacterInput>();
        _characterMovement = GetComponent<ICharacterMovement>();
        _characterSpriteManager = GetComponent<ICharacterSpriteManager>();
    }

    //FixedUpdate não depende da framerate pra ser chamado
    void FixedUpdate()
    {
        CharacterMove();
        if (_characterInput.InputJump())
            CharacterJump();
        _characterSpriteManager.TurnCharacterSprite(_movementHorizontalDirection);
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
}
