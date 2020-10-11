using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
#region variaveis
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
    private bool IsJumpButtonPressed;
    private bool HasExtraJump;
    private bool WillLand;
    private Rigidbody2D _rigidbody2D;
    private PlayerAnimation _playerAnimation;
    private PlayerInput _playerInput;
    private PlayerSpriteHandler _playerSpriteHandler;
    private PlayerAttack _playerAttack;
    private PlayerShoot _shot;
    private PlayerWallMovement _playerWallMovement;

#endregion variaveis

    void Start()
    {
        #region instanciando
        HasExtraJump = true;
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerSpriteHandler = GetComponent<PlayerSpriteHandler>();
        _playerAttack = GetComponent<PlayerAttack>();
        _shot = GetComponent<PlayerShoot>();
        _playerWallMovement = GetComponent<PlayerWallMovement>();
        #endregion instanciando
    }

    void Update()
    {
        HorizontalMovement = _playerInput.GetHorizontalMovement();

        _playerSpriteHandler.TurnPlayer(HorizontalMovement);

        SetIfIsOnGround();
        _playerWallMovement.SetIfIsOnWall();
        GetExtraJump();
        PlayerMove();

        IsJumpButtonPressed = _playerInput.CheckForJumpButton();
        PlayerJump();
    }

    void PlayerMove()
    {
        if(!_playerWallMovement._isPlayerWallJumping){
            float horizontalSpeed = HorizontalMovement * _playerSpeed;
            _rigidbody2D.velocity = new Vector2(horizontalSpeed, _rigidbody2D.velocity.y);
            _playerAnimation.SetRunning(HorizontalMovement);
        }
    }

    void PlayerJump()
    {
        if ((IsJumpButtonPressed && IsPlayerOnGround))
        {
            _rigidbody2D.velocity = Vector2.up * _jumpStrength;
            if (_landParticle)
                Instantiate(_landParticle, _groundTransform.position, Quaternion.identity);
        }
        else if (IsJumpButtonPressed && HasExtraJump && !_playerWallMovement._isPlayerWallJumping)
        {
            _playerAnimation.SetDoubleJumping(true);
            _rigidbody2D.velocity = Vector2.up * _jumpStrength;
            _shot.ShotDoubleJump();
            HasExtraJump = false;
        }
    }

    void GetExtraJump()
    {
        if (IsPlayerOnGround )
            HasExtraJump = true;
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
            WillLand = true;
        }
    }

    void LandPlayer()
    {
        if (WillLand)
        {
            Camera.main.GetComponent<CameraShake>().Shake();
            if (_landParticle)
                Instantiate(_landParticle, _groundTransform.position, Quaternion.identity);
            WillLand = false;
        }
    }
}
