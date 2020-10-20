using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    private bool isEnemyAttacking;
    private Animator _enemyAnimator;
    private EnemyAttack _enemyAttack;

    // Start is called before the first frame update
    void Start()
    {
        _enemyAttack = GetComponent<EnemyAttack>();
        _enemyAnimator = GetComponent<Animator>();
    }

    public void EnemyAttack(){
        _enemyAnimator.SetTrigger("Attack");
    }
    public void EnemyRunning(bool Running){
        _enemyAnimator.SetBool("Running", Running);
    }
    public void EnemyHit(){
        _enemyAnimator.SetTrigger("Hit");
    }
    public void EnemyDeath(){
        _enemyAnimator.SetTrigger("Death");
    }
}
