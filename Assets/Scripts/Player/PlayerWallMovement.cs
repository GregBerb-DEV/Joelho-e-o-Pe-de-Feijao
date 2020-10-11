using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField]
    private Transform _wallTransform;
    [SerializeField]
    private float _wallSidingSpeed = 5f;
    [SerializeField]
    private float checkRadius;
    [SerializeField]
    private float yWallForce;
    [SerializeField]
    private float wallJumpTime;
    [SerializeField]
    private float _xWallForce;
    private float _xNumeroCalculated;
    private bool _isPlayerWallSliding;
    private bool _isPlayerWallJumping;
    private bool _isPlayerOnWall;
    private PlayerMovement _playerMovement = default;
    private PlayerInput _playerInput = default;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInput = GetComponent<PlayerInput>();
    }


    public void SetIfIsOnWall()
    {

        _isPlayerOnWall = Physics2D.OverlapCircle(_wallTransform.position, checkRadius, _playerMovement.GroundLayer);

        SetPlayerToSliding();

        SetPlayerToWallJump();
    }

    private void SetPlayerToSliding()
    {
        if (_isPlayerOnWall && !(_playerMovement.IsPlayerOnGround) && _playerMovement.HorizontalMovement != 0)
        {
            _isPlayerWallSliding = true;
        }
        else
        {
            _isPlayerWallSliding = false;
        }

        if (_isPlayerWallSliding)
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, Mathf.Clamp(_rigidbody2D.velocity.y, -_wallSidingSpeed, float.MaxValue));
        }
    }

    private void SetPlayerToWallJump()
    {
        if (_isPlayerWallSliding && _playerInput.CheckForJumpButton())
        {
            _isPlayerWallJumping = true;
            _xNumeroCalculated = _xWallForce * -(_playerMovement.HorizontalMovement);
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }

        if (_isPlayerWallJumping)
        {
            _rigidbody2D.AddForce(new Vector2(_xNumeroCalculated, yWallForce));
        }
    }


    void SetWallJumpingToFalse()
    {
        _isPlayerWallJumping = false;

    }

}
