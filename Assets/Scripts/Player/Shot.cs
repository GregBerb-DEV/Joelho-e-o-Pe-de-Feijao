using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shot : MonoBehaviour
{
    public GameObject projectile;
    public Transform shotPoint;
    private PlayerSpriteHandler _playerSpriteHandler;

    private float timeBtwShots;
    public float startTimeBtwShots = 0.5f;
    private bool side;
    private int quaternionZ;


    void Start(){
        _playerSpriteHandler = gameObject.GetComponent<PlayerSpriteHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        IsSide();
        if(timeBtwShots <= 0){
            if (Input.GetMouseButtonDown(0)){
                Instantiate(projectile, shotPoint.position, Quaternion.Euler(0,0,quaternionZ));
                timeBtwShots = startTimeBtwShots;
            } 
        } else {
                timeBtwShots -= Time.deltaTime;
        }
    }

    void IsSide(){
        side = _playerSpriteHandler.isRight;
        if(side){
            quaternionZ = 0;
        }else{
            quaternionZ = 90;
        }
    }
}
