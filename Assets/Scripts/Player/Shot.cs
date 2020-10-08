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
    public bool right;
    private int quaternionZ;


    void Start(){
        _playerSpriteHandler = gameObject.GetComponent<PlayerSpriteHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        IsSide();
        WhaitBtwShot();
    }


    void IsSide(){
        right = _playerSpriteHandler.isRight;
        if(right){
            quaternionZ = 0;
        }else{
            quaternionZ = 90;
        }
    }


    void WhaitBtwShot(){
        if(timeBtwShots <= 0){
            if (Input.GetMouseButtonDown(0)){
                Instantiate(projectile, shotPoint.position, Quaternion.Euler(0,0,quaternionZ));
                timeBtwShots = startTimeBtwShots;
            } 
        } else {
                timeBtwShots -= Time.deltaTime;
        }
    }

    public void ShotDoubleJump(){
        Instantiate(projectile, shotPoint.position, Quaternion.Euler(0,0,135));
    }
}
