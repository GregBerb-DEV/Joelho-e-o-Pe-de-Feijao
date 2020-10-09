using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject Projectile;
    public Transform ShootPoint;
    [SerializeField]
    private float _startTimeBetweenShots = 0.5f;
    private float _timeBetweenShots;
    private int quaternionZ;
    private PlayerSpriteHandler _playerSpriteHandler;
    private PlayerInput _playerInput;

    void Start()
    {
        _playerSpriteHandler = GetComponent<PlayerSpriteHandler>();
        _playerInput = GetComponent<PlayerInput>();
    }

    void Update()
    {
        CheckLookDirection();
        WaitBetweenShots();
    }

    void CheckLookDirection()
    {
        if (_playerSpriteHandler.isRight)
        {
            quaternionZ = 0;
        }
        else
        {
            quaternionZ = 90;
        }
    }


    void WaitBetweenShots()
    {
        if (_timeBetweenShots <= 0)
        {
            if (_playerInput.CheckForShootButton())
            {
                Instantiate(Projectile, ShootPoint.position, Quaternion.Euler(0, 0, quaternionZ));
                _timeBetweenShots = _startTimeBetweenShots;
            }
        }
        else
        {
            _timeBetweenShots -= Time.deltaTime;
        }
    }

    public void ShotDoubleJump()
    {
        Instantiate(Projectile, ShootPoint.position, Quaternion.Euler(0, 0, 135));
    }
}
