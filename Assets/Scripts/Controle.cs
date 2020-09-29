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

    void Update()
    {
        MovePlayer();
    }

    private void LateUpdate()
    {
        TurnPlayer();
    }

    void MovePlayer()
    {
        _movementHorizontalDirection = Input.GetAxis("Horizontal");
        _rigidbody2D.velocity = new Vector2(_movementHorizontalDirection * _moveSpeed,
                                                                     gameObject.GetComponent<Rigidbody2D>().velocity.y);
        if (Input.GetButtonDown("Jump"))
        {
            pula();
        }

    }

    void pula()
    {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * _jumpStrength);
    }

    void TurnPlayer()
    {
        if (_movementHorizontalDirection > 0)
        {
            _isGoingRight = true;
        }
        else if (_movementHorizontalDirection < 0)
        {
            _isGoingRight = false;
        }
        Vector2 escala = transform.localScale;
        if ((escala.x > 0 && !_isGoingRight) || (escala.x < 0 && _isGoingRight))
        {
            escala.x = escala.x * -1;
            transform.localScale = escala;
        }
    }
}
