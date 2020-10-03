using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {

    public bool IsAttacking = false;
    private float _waitTime = 1.0f;
    private EnemyAnimation _enemyAnimation;

    void Start(){
        _enemyAnimation = GetComponent<EnemyAnimation>();
    }


    void OnTriggerStay2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "Player")
            Attack();
    }

    void Attack()
    {
        if (!IsAttacking)
        {
            StartCoroutine(WaitAttack());
        }
    }

    IEnumerator WaitAttack(){
        IsAttacking = true;
        _enemyAnimation.EnemyAttack();
        yield return new WaitForSeconds(1f);
        IsAttacking = false;
        yield return new WaitForSeconds(2f);
    }
}

