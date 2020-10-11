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
    private float xWallForce;
    private bool _isPlayerWallSliding;
    private bool _wallJumping;
    private bool _isPlayerOnWall;
    private PlayerMovement _playerMovement;
    private PlayerInput _playerInput = default;


    // Start is called before the first frame update
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _playerMovement = GetComponent<PlayerMovement>();
        _playerInput = GetComponent<PlayerInput>();
    }

    // Update is called once per frame

    public void SetIfIsOnWall()
    {

        _isPlayerOnWall = Physics2D.OverlapCircle(_wallTransform.position, checkRadius, _playerMovement.GroundLayer);

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

        if (_isPlayerWallSliding && _playerInput.CheckForJumpButton())
        {
            _wallJumping = true;
            Invoke("SetWallJumpingToFalse", wallJumpTime);
        }

        if (_wallJumping)
        {
            float numero = xWallForce * -(_playerMovement.HorizontalMovement);
            Debug.Log(_playerMovement.HorizontalMovement + "entrei " + numero);
            _rigidbody2D.AddForce(new Vector2(numero, yWallForce));

        }
    }

    void SetWallJumpingToFalse()
    {
        _wallJumping = false;
    }

}
