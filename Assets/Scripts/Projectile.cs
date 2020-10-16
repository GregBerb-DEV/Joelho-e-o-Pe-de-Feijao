using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField]
    private int damage = 5;
    public float speed;
    public float lifeTime = 1f;
    public float distance;

    public LayerMask WhatIsSolid;
    public GameObject destroyEffect;


    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);

    }


    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, WhatIsSolid);
        HitSomething(hitInfo);
        transform.Translate(transform.right * speed * Time.deltaTime);
    }


    void HitSomething(RaycastHit2D hitInfo)
    {
        if (hitInfo.collider != null)
        {
            HitEnemy(hitInfo);
            DestroyProjectile();
        }

    }


    void HitEnemy(RaycastHit2D hitInfo)
    {
        if (hitInfo.collider.CompareTag("inimigo"))
        {
            hitInfo.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
        }
    }


    void DestroyProjectile()
    {
        if (destroyEffect)
            Instantiate(destroyEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
