using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour, ICharacterController
{
    public float InputHorizontalMovement()
    {
        return Input.GetAxis("Horizontal");
    }

    public bool InputJump()
    {
        return Input.GetButtonDown("Jump");
    }
}
