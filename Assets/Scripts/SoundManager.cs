using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip playerKickSound;
    public static AudioClip playerDieSound;
    public static AudioClip playerDamageSound;
    public static AudioClip playerKickHitSound;
    public static AudioClip playerExtraJumpSound;
    public static AudioClip playerLandSound;
    public static AudioClip playerShootSound;
    public static AudioClip playerWalkingSound;
    public static AudioClip playerStepSound;
    public static AudioClip playerJumpSound;
    public static AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        playerKickSound = Resources.Load<AudioClip>("kick");
        playerKickHitSound = Resources.Load<AudioClip>("kickHit");
        playerDamageSound = Resources.Load<AudioClip>("damage");
        playerDieSound = Resources.Load<AudioClip>("die");
        playerExtraJumpSound = Resources.Load<AudioClip>("extraJump");
        playerLandSound = Resources.Load<AudioClip>("land");
        playerShootSound = Resources.Load<AudioClip>("shoot");
        playerWalkingSound = Resources.Load<AudioClip>("walking");
        playerStepSound = Resources.Load<AudioClip>("step");
        playerJumpSound = Resources.Load<AudioClip>("jump");

        audioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "kick":
                audioSrc.PlayOneShot(playerKickSound, 5);
                break;
            case "kickHit":
                audioSrc.PlayOneShot(playerKickHitSound);
                break;
            case "die":
                audioSrc.PlayOneShot(playerDieSound);
                break;
            case "damage":
                audioSrc.PlayOneShot(playerDamageSound);
                break;
            case "jump":
                audioSrc.PlayOneShot(playerJumpSound);
                break;
            case "extraJump":
                audioSrc.PlayOneShot(playerExtraJumpSound, 10);
                break;
            case "land":
                audioSrc.PlayOneShot(playerLandSound);
                break;
            case "shoot":
                audioSrc.PlayOneShot(playerShootSound, 2);
                break;
            case "walking":
                audioSrc.PlayOneShot(playerWalkingSound, 10);
                break;
            case "step":
                audioSrc.PlayOneShot(playerStepSound, 10);
                break;
        }
    }
}
