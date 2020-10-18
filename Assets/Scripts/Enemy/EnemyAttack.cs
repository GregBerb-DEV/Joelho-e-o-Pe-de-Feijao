using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{

    public bool IsAttacking = false;
    [SerializeField]
    private int _forca = 1;
    private EnemyAnimation _enemyAnimation;


    void Start()
    {
        _enemyAnimation = GetComponent<EnemyAnimation>();
    }


    void OnTriggerStay2D(Collider2D outro)
    {
        if (outro.gameObject.tag == "Player")
            Attack(outro);
    }

    void Attack(Collider2D outro)
    {
        if (!IsAttacking)
        {
            if (outro.gameObject.GetComponent<PlayerHealth>())
            {
                PlayerHealth playerHealth = outro.gameObject.GetComponent<PlayerHealth>();
                playerHealth.TakeDamage(_forca);
                StartCoroutine(WaitAttack());
            }

        }
    }

    IEnumerator WaitAttack()
    {
        IsAttacking = true;
        _enemyAnimation.EnemyAttack();
        yield return new WaitForSeconds(1f);
        IsAttacking = false;
        yield return new WaitForSeconds(2f);
    }
}

