using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;

    private float timeBtwShots;
    public float startTimeBtwShots = 1f;


    // Update is called once per frame
    void Update()
    {
        if(timeBtwShots <= 0){
            if (Input.GetMouseButtonDown(0)){
                Instantiate(projectile, shotPoint.position, Quaternion.Euler(0,0,0));
                timeBtwShots = startTimeBtwShots;
            } 
        } else {
                timeBtwShots -= Time.deltaTime;
        }
    }


}
