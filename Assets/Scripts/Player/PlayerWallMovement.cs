using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallMovement : MonoBehaviour
{
    [SerializeField]
    private Transform _wallTransform;
    [SerializeField]
    private float _wallSlideSpeed = 5f;
    [SerializeField]
    private float checkRadius = 0.5f;
    [SerializeField]
    private float yWallForce;
    [SerializeField]
    private float wallJumpTime = 0.1f;
    [SerializeField]
    private float _xWallForce;

    public bool _isWallJumping;
    public bool _isPlayerColliding;

    private Rigidbody2D _rigidbody2D;
    private Collider2D _collider2D;
    private float _calculatedXForce;
    private bool _isPlayerWallSliding;
    private PlayerJump _playerJump = default;
    private PlayerMovement _playerMovement = default;
    private PlayerInput _playerInput = default;
    private PlayerHealth _playerHealth = default;
    private PlayerAnimation _playerAnimation = default;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerJump = GetComponent<PlayerJump>();
        _playerInput = GetComponent<PlayerInput>();
        _collider2D = GetComponent<Collider2D>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerHealth = GetComponent<PlayerHealth>();
        _playerAnimation = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        if (_playerHealth.IsDead)
            return;
        _isPlayerColliding = Physics2D.OverlapCircle(_wallTransform.position, checkRadius, _playerJump._groundLayer);
        SlideOnWall();
        WallJump();
        _playerAnimation.SetOnWall(_isPlayerWallSliding);
    }

    private void SlideOnWall()
    {
        _isPlayerWallSliding = (_isPlayerColliding && !(_playerJump.IsGrounded) && _playerMovement.horizontalMovement != 0);
        if (_isPlayerWallSliding){
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, Mathf.Clamp(_rigidbody2D.velocity.y, -_wallSlideSpeed, float.MaxValue));
            SoundManager.PlaySound("wallSliding");
        }
    }

    private void WallJump()
    {
        if (_isPlayerWallSliding && _playerInput.CheckForJumpButton())
        {
            _isWallJumping = true;
            _calculatedXForce = _xWallForce * -(_playerMovement.horizontalMovement);
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }

        if (_isWallJumping)
            _rigidbody2D.velocity = new Vector2(_calculatedXForce, yWallForce);
    }

    void SetWallJumpingToFalse()
    {
        _isWallJumping = false;
    }
}
