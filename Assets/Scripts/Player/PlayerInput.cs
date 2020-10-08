using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string ATTACK_BUTTON = "Fire1";
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string VERTICAL_AXIS = "Vertical";
    private const string JUMP_BUTTON = "Jump";

    public bool CheckForAttackButton()
    {
        return Input.GetButtonDown(ATTACK_BUTTON);
    }

    public float GetHorizontalMovement()
    {
        return Input.GetAxisRaw(HORIZONTAL_AXIS);
    }

    public bool GetJumpButton()
    {
        if(Input.GetButtonDown(JUMP_BUTTON)){
            return Input.GetButtonDown(JUMP_BUTTON);

        }else if(Input.GetKeyDown(KeyCode.UpArrow)){
            return Input.GetKeyDown(KeyCode.UpArrow);
        }else {
            return false;
        }
    }
}
