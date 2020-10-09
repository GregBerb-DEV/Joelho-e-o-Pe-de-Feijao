using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private const string HORIZONTAL_AXIS = "Horizontal";
    private const string JUMP_BUTTON = "Jump";
    private const string KICK_BUTTON = "Kick";
    private const string SHOOT_BUTTON = "Shoot";
    private const string PAUSE_BUTTON = "Pause";
    private const string NEXT_HAT_BUTTON = "NextHat";
    private const string PREVIOUS_HAT_BUTTON = "PreviousHat";

    public float GetHorizontalMovement()
    {
        return Input.GetAxisRaw(HORIZONTAL_AXIS);
    }

    public bool CheckForKickButton()
    {
        return Input.GetButtonDown(KICK_BUTTON);
    }
    public bool CheckForJumpButton()
    {
        return Input.GetButtonDown(JUMP_BUTTON);
    }

    public bool CheckForShootButton()
    {
        return Input.GetButton(SHOOT_BUTTON);
    }

    public bool CheckForPauseButton()
    {
        return Input.GetButtonDown(PAUSE_BUTTON);
    }

    public bool CheckForNextHatButton()
    {
        return Input.GetButtonDown(NEXT_HAT_BUTTON);
    }

    public bool CheckForPreviousHatButton()
    {
        return Input.GetButtonDown(PREVIOUS_HAT_BUTTON);
    }
}
