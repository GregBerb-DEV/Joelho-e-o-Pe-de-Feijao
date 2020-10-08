using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float playerSpeed = 10;
    [SerializeField]
    private float jumpStrength = 50;
    [SerializeField]
    private Transform groundTransform;
    [SerializeField]
    private LayerMask groundLayer;
    [SerializeField]
    private GameObject LandParticle;

    //dustEffect

    private float horizontalMovement;
    private bool isPlayerOnGround;
    private bool isJumpButton;
    private bool extraJump;
    private bool land;

    private Rigidbody2D _rigidbody2D;
    private PlayerAnimation _playerAnimation;
    private PlayerInput _playerInput;
    private PlayerSpriteHandler _playerSpriteHandler;
    private PlayerAttack _playerAttack;

    void Start()
    {
        extraJump = true;
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

        SetIfIsOnGround();
        GetExtraJump();
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
        if ((isJumpButton && isPlayerOnGround)){
            _rigidbody2D.velocity = Vector2.up * jumpStrength;
            if(LandParticle)
                Instantiate(LandParticle, groundTransform.position, Quaternion.identity);
        } else if(isJumpButton && extraJump){
            _playerAnimation.SetDoubleJumping(true);
            Debug.Log("setei pra true");
            _rigidbody2D.velocity = Vector2.up * jumpStrength;
            extraJump = false;
            
        }
    }

    void GetExtraJump(){
        if(isPlayerOnGround)
            extraJump = true;
    }

    void SetIfIsOnGround(){
        isPlayerOnGround = Physics2D.Linecast(transform.position, groundTransform.position, groundLayer);
        _playerAnimation.SetOnGroundBool(isPlayerOnGround);

        if(isPlayerOnGround){
            _playerAnimation.SetDoubleJumping(false);
            Land();

        }else{
            land = true;
        }  
    }

    void Land(){
        if(land){
            _playerAnimation.SetCamShakeTrigger();
            if(LandParticle)
                Instantiate(LandParticle, groundTransform.position, Quaternion.identity);
            land = false;
        }
    }

}
