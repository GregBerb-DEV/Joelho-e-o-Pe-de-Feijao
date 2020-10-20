using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour, IHaveHealth
{
    public bool IsDead = false;

    [SerializeField]
    private int _enemyHealth = 10;

    private EnemyAnimation _enemyAnimation;

    void Start()
    {
        _enemyAnimation = GetComponent<EnemyAnimation>();
    }

    public void TakeDamage(int damageTaken)
    {
        _enemyHealth -= damageTaken;
        _enemyAnimation.EnemyHit();
        if (_enemyHealth <= 0)
            Kill();
    }

    public void Kill()
    {
        IsDead = true;
        FindObjectOfType<PlayerScore>().IncreaseScore(1);
        Destroy(gameObject);
        _enemyAnimation.EnemyDeath();
    }
}