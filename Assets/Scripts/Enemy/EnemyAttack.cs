using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public bool IsAttacking = false;
    [SerializeField]
    private int _forca = 1;
    [SerializeField]
    private float _initialTimeBetweenKicks = 1f;
    private EnemyAnimation _enemyAnimation;
    private float _currentTimeBetweenKicks;


    void Start()
    {
        _currentTimeBetweenKicks = _initialTimeBetweenKicks;
        _enemyAnimation = GetComponent<EnemyAnimation>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            _currentTimeBetweenKicks = _initialTimeBetweenKicks / 3f;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (_currentTimeBetweenKicks <= 0)
        {
            if (other.tag == "Player")
            {
                Attack(other);
                _currentTimeBetweenKicks = _initialTimeBetweenKicks;
            }

        }
        else
        {
            _currentTimeBetweenKicks -= Time.deltaTime;
        }
    }

    void Attack(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerHealth>())
        {
            SoundManager.PlaySound("kickHit");
            PlayerHealth playerHealth = other.gameObject.GetComponent<PlayerHealth>();
            _enemyAnimation.EnemyAttack();
            playerHealth.TakeDamage(_forca);
        }
    }
}

