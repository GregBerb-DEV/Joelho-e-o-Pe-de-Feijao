using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _playerSpeed = 10;
    [SerializeField]
    private float _jumpStrength = 15;
    [SerializeField]
    private Transform _groundTransform = default;
    [SerializeField]
    public LayerMask GroundLayer = default;
    [SerializeField]
    private GameObject _landParticle = default;
    public float HorizontalMovement;
    public bool IsPlayerOnGround;
    private bool isJumpButtonPressed;
    private bool _hasExtraJump;
    private bool _willLand;
    private Rigidbody2D _rigidbody2D;
    private PlayerAnimation _playerAnimation;
    private PlayerInput _playerInput;
    private PlayerSpriteHandler _playerSpriteHandler;
    private PlayerAttack _playerAttack;
    private PlayerShoot _shot;
    private PlayerWallMovement _playerWallMovement;


    void Start()
    {
        _hasExtraJump = true;
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerSpriteHandler = GetComponent<PlayerSpriteHandler>();
        _playerAttack = GetComponent<PlayerAttack>();
        _shot = GetComponent<PlayerShoot>();
        _playerWallMovement = GetComponent<PlayerWallMovement>();
    }

    void Update()
    {
        HorizontalMovement = _playerInput.GetHorizontalMovement();
        isJumpButtonPressed = _playerInput.CheckForJumpButton();
        PlayerJump();
        _playerSpriteHandler.TurnPlayer(HorizontalMovement);

        SetIfIsOnGround();
        _playerWallMovement.SetIfIsOnWall();
        GetExtraJump();
        PlayerMove();
    }

    void PlayerMove()
    {
        float horizontalSpeed = HorizontalMovement * _playerSpeed;
        _rigidbody2D.velocity = new Vector2(horizontalSpeed, _rigidbody2D.velocity.y);
        _playerAnimation.SetRunning(HorizontalMovement);
    }

    void PlayerJump()
    {
        if ((isJumpButtonPressed && IsPlayerOnGround))
        {
            _rigidbody2D.velocity = Vector2.up * _jumpStrength;
            if (_landParticle)
                Instantiate(_landParticle, _groundTransform.position, Quaternion.identity);
        }
        else if (isJumpButtonPressed && _hasExtraJump)
        {
            _playerAnimation.SetDoubleJumping(true);
            _rigidbody2D.velocity = Vector2.up * _jumpStrength;
            _shot.ShotDoubleJump();
            _hasExtraJump = false;
        }
    }

    void GetExtraJump()
    {
        if (IsPlayerOnGround)
            _hasExtraJump = true;
    }

    void SetIfIsOnGround()
    {
        IsPlayerOnGround = Physics2D.Linecast(transform.position, _groundTransform.position, GroundLayer);
        _playerAnimation.SetOnGround(IsPlayerOnGround);

        if (IsPlayerOnGround)
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
            Camera.main.GetComponent<CameraShake>().Shake();
            if (_landParticle)
                Instantiate(_landParticle, _groundTransform.position, Quaternion.identity);
            _willLand = false;
        }
    }
}
