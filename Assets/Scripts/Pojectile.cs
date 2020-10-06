using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pojectile : MonoBehaviour
{

    public float speed;
    public float lifeTime = 1f;

    public GameObject destroyEffect;

    private void Start(){
        Invoke("DestroyProjectile", lifeTime);
    }
    void Update()
    {
        transform.Translate(transform.right * speed * Time.deltaTime);
    }

    void DestroyProjectile() {
        if(destroyEffect)
            Instantiate(destroyEffect, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
}
