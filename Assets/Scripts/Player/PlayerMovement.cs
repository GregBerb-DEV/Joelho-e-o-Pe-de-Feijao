using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 10;
    [SerializeField]
    private float jumpStrength = 800;
    [SerializeField]
    private Transform groundTransform;
    [SerializeField]
    private LayerMask groundLayer;

    private float horizontalMovement;
    private bool isPlayerOnGround;
    private bool isJumpButton;
    private Rigidbody2D _rigidbody2D;
    private PlayerAnimation _playerAnimation;
    private PlayerInput _playerInput;
    private PlayerSpriteHandler _playerSpriteHandler;
    private PlayerAttack _playerAttack;

    void Start()
    {
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerSpriteHandler = GetComponent<PlayerSpriteHandler>();
        _playerAttack = GetComponent<PlayerAttack>();
    }

    void Update()
    {
        horizontalMovement = _playerInput.GetHorizontalMovement();
        isJumpButton = _playerInput.GetJumpButton();
        PlayerJump();
        _playerSpriteHandler.TurnPlayer(horizontalMovement);
        isPlayerOnGround = Physics2D.Linecast(transform.position, groundTransform.position, groundLayer);
        _playerAnimation.SetOnGroundTrigger(isPlayerOnGround);
        PlayerMove();
    }

    void PlayerMove()
    {
        float horizontalSpeed = horizontalMovement * playerSpeed;
        _rigidbody2D.velocity = new Vector2(horizontalSpeed, _rigidbody2D.velocity.y);
        _playerAnimation.CheckForRunning(horizontalMovement);
    }

    void PlayerJump()
    {
        if (isJumpButton && isPlayerOnGround)
            _rigidbody2D.AddForce(Vector2.up * jumpStrength);
    }
}
