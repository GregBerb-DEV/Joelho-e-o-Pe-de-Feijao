using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    #region Declaração
    [SerializeField]
    private float _jumpStrength = 15;
    [SerializeField]
    private Transform _groundTransform = default;
    [SerializeField]
    private GameObject _landParticle = default;
    [SerializeField]
    private float rememberGroundedFor = 0.1f;
    [SerializeField]
    private float checkGroundedRadius = 1f;

    public LayerMask _groundLayer = default;
    public bool IsGrounded;
    private bool _isJumpButtonPressed;
    private bool _hasExtraJump;
    private bool _willLand;
    private float _lastTimeGrounded;

    private Rigidbody2D _rigidbody2D;
    private PlayerAnimation _playerAnimation = default;
    private PlayerInput _playerInput = default;
    private PlayerSpriteHandler _playerSpriteHandler = default;
    private PlayerAttack _playerAttack = default;
    private PlayerShoot _playerShoot = default;
    private PlayerWallMovement _playerWallMovement = default;
    private PlayerHealth _playerHealth = default;
    #endregion

    void Start()
    {
        #region Instanciando
        _hasExtraJump = true;
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerSpriteHandler = GetComponent<PlayerSpriteHandler>();
        _playerAttack = GetComponent<PlayerAttack>();
        _playerShoot = GetComponent<PlayerShoot>();
        _playerWallMovement = GetComponent<PlayerWallMovement>();
        _playerHealth = GetComponent<PlayerHealth>();
        #endregion
    }
    void Update()
    {
        if (_playerHealth.IsDead)
            return;
        SetIfIsOnGround();
        GetExtraJump();
        _isJumpButtonPressed = _playerInput.CheckForJumpButton();
        Jump();
    }

    void Jump()
    {
        if (_isJumpButtonPressed && (IsGrounded || Time.time - _lastTimeGrounded <= rememberGroundedFor))
        {
            _rigidbody2D.velocity = Vector2.up * _jumpStrength;
            if (_landParticle)
                Instantiate(_landParticle, _groundTransform.position, Quaternion.identity);
        }
        else if (_isJumpButtonPressed && _hasExtraJump && !_playerWallMovement._isWallJumping)
        {
            _playerAnimation.SetDoubleJumping(true);
            _rigidbody2D.velocity = Vector2.up * _jumpStrength;
            _playerShoot.DoubleJumpShoot();
            _hasExtraJump = false;
        }
    }

    void GetExtraJump()
    {
        if (IsGrounded || Time.time - _lastTimeGrounded <= rememberGroundedFor)
            _hasExtraJump = true;
    }

    void SetIfIsOnGround()
    {
        RaycastHit2D colliders = Physics2D.Linecast(transform.position, _groundTransform.position, _groundLayer); ;
        if (colliders)
        {
            IsGrounded = true;
        }
        else
        {
            if (IsGrounded)
                _lastTimeGrounded = Time.time;
            IsGrounded = false;
        }

        _playerAnimation.SetOnGround(IsGrounded);

        if (IsGrounded)
        {
            _playerAnimation.SetDoubleJumping(false);
            LandPlayer();
        }
        else
        {
            _willLand = true;
        }
    }

    void LandPlayer()
    {
        if (_willLand)
        {
            CameraShake.Shake();
            if (_landParticle)
                Instantiate(_landParticle, _groundTransform.position, Quaternion.identity);
            _willLand = false;
        }
    }
}
