using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKick : MonoBehaviour
{
    [SerializeField]
    private int _damageAmount = 5;
    [SerializeField]
    private string _enemyTag = "inimigo";
    [SerializeField]
    private GameObject _explosionEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == _enemyTag)
            other.GetComponent<PlayerHealth>().TakeDamage(_damageAmount);
        //Interface ITakeDamage
        if (_explosionEffect)
            Instantiate(_explosionEffect, transform.position, transform.rotation);
    }
}
