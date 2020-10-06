using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayPlatform : MonoBehaviour
{
    //private PlayerInput _playerInput;
    private PlatformEffector2D effector;
    private float waitTime;
    public float holdTime = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        effector = GetComponent<PlatformEffector2D>();
        waitTime = holdTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.DownArrow)){
            waitTime = holdTime;                         
        }

        if(Input.GetKey(KeyCode.DownArrow)){
            if(waitTime <= 0){
                effector.rotationalOffset = 180f;
                waitTime = holdTime;
            } else{
                waitTime -= Time.deltaTime;
            }
        }

        if(Input.GetButtonDown("Jump"))
            effector.rotationalOffset = 0f;
    }
}
