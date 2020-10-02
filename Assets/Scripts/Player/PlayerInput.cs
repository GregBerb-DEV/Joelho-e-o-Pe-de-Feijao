using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string ATTACK_BUTTON = "Fire1";
    private const string HORIZONTAL_AXIS = "Horizontal";
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
        return Input.GetButtonDown(JUMP_BUTTON);
    }
}
