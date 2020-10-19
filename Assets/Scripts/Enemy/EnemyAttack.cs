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


    void OnTriggerStay2D(Collider2D outro)
    {
        if (_currentTimeBetweenKicks <= 0)
        {
            Attack(outro);
            _currentTimeBetweenKicks = _initialTimeBetweenKicks;
        }
        else
        {
            _currentTimeBetweenKicks -= Time.deltaTime;
        }
    }

    void Attack(Collider2D outro)
    {
        if (outro.gameObject.GetComponent<PlayerHealth>())
        {
            SoundManager.PlaySound("kickHit");
            PlayerHealth playerHealth = outro.gameObject.GetComponent<PlayerHealth>();
            playerHealth.TakeDamage(_forca);
        }
    }
}

