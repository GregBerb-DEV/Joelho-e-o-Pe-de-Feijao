using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region variaveis
    [SerializeField]
    private float _playerSpeed = 10;

    public LayerMask _groundLayer = default;
    public float horizontalMovement;
    public bool IsGrounded;
    private bool _isPlayingStep = false;

    private Rigidbody2D _rigidbody2D;
    private PlayerAnimation _playerAnimation;
    private PlayerInput _playerInput;
    private PlayerSpriteHandler _playerSpriteHandler;
    private PlayerWallMovement _playerWallMovement;
    private PlayerHealth _playerHealth;
    #endregion

    void Start()
    {
        #region instanciando
        _playerAnimation = GetComponent<PlayerAnimation>();
        _playerInput = GetComponent<PlayerInput>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerSpriteHandler = GetComponent<PlayerSpriteHandler>();
        _playerWallMovement = GetComponent<PlayerWallMovement>();
        _playerHealth = GetComponent<PlayerHealth>();
        #endregion instanciando
    }

    void Update()
    {
        if (_playerHealth.IsDead)
            return;

        horizontalMovement = _playerInput.GetHorizontalMovement();
        _playerSpriteHandler.TurnPlayer(horizontalMovement);
        Move();
    }

    void Move()
    {
        if (_playerWallMovement._isWallJumping)
            return;
        float horizontalSpeed = horizontalMovement * _playerSpeed;
        _rigidbody2D.velocity = new Vector2(horizontalSpeed, _rigidbody2D.velocity.y);
        _playerAnimation.SetRunning(horizontalMovement);
        StartCoroutine(playStep());

        
    }

    IEnumerator playStep(){

        if(!_isPlayingStep){
            SoundManager.PlaySound("step");
            _isPlayingStep = true;
            yield return new WaitForSeconds(0.41f);
            _isPlayingStep = false;
        }

    }
}
