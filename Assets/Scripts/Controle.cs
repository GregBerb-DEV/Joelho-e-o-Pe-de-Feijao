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

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MovePlayer();
        TurnPlayer();
    }

    void MovePlayer()
    {
        _movementHorizontalDirection = Input.GetAxis("Horizontal");
        if (_rigidbody2D)
            _rigidbody2D.velocity = new Vector2(_movementHorizontalDirection * _moveSpeed, _rigidbody2D.velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            Jump();
        }

    }

    void Jump()
    {
        if (_rigidbody2D)
            _rigidbody2D.AddForce(Vector2.up * _jumpStrength);
    }

    void TurnPlayer()
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
