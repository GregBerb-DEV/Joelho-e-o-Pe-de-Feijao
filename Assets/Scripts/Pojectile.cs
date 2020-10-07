using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pojectile : MonoBehaviour
{

    [SerializeField]
    private int damage = 5;
    public float speed;
    public float lifeTime = 1f;
    public float distance;

    public LayerMask WhatIsSolid;
    public GameObject destroyEffect;

    private void Start(){
        Invoke("DestroyProjectile", lifeTime);

    }
    void Update()
    {

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, WhatIsSolid);
        if (hitInfo.collider != null){
            Debug.Log("hit collider != null");
            if (hitInfo.collider.CompareTag("inimigo")){
                Debug.Log("compareTag == inimigo");
                hitInfo.collider.GetComponent<EnemyHealth>().TakeDamage(damage);

            }
            DestroyProjectile();
        }
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    void DestroyProjectile() {
        if(destroyEffect)
            Instantiate(destroyEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
