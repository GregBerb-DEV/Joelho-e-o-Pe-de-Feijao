using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip KickSound;
    public static AudioClip DieSound;
    public static AudioClip DamageSound;
    public static AudioClip KickHitSound;
    public static AudioClip ExtraJumpSound;
    public static AudioClip LandSound;
    public static AudioClip ShootSound;
    public static AudioClip WalkingSound;
    public static AudioClip StepSound;
    public static AudioClip JumpSound;
    public static AudioClip CoinSound;
    public static AudioClip ExtraLifeSound;
    public static AudioSource SFXAudioSrc;


    // Start is called before the first frame update
    void Start()
    {
        KickSound = Resources.Load<AudioClip>("kick");
        KickHitSound = Resources.Load<AudioClip>("kickHit");
        DamageSound = Resources.Load<AudioClip>("damage");
        DieSound = Resources.Load<AudioClip>("die");
        ExtraJumpSound = Resources.Load<AudioClip>("extraJump");
        LandSound = Resources.Load<AudioClip>("land");
        ShootSound = Resources.Load<AudioClip>("shoot");
        WalkingSound = Resources.Load<AudioClip>("walking");
        StepSound = Resources.Load<AudioClip>("step");
        JumpSound = Resources.Load<AudioClip>("jump");
        CoinSound = Resources.Load<AudioClip>("coin");
        ExtraLifeSound = Resources.Load<AudioClip>("extraLife");

        SFXAudioSrc = GetComponent<AudioSource>();
    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "kick":
                SFXAudioSrc.PlayOneShot(KickSound, 5);
                break;
            case "kickHit":
                SFXAudioSrc.PlayOneShot(KickHitSound);
                break;
            case "die":
                SFXAudioSrc.PlayOneShot(DieSound);
                break;
            case "damage":
                SFXAudioSrc.PlayOneShot(DamageSound);
                break;
            case "jump":
                SFXAudioSrc.PlayOneShot(JumpSound);
                break;
            case "extraJump":
                SFXAudioSrc.PlayOneShot(ExtraJumpSound, 10);
                break;
            case "land":
                SFXAudioSrc.PlayOneShot(LandSound);
                break;
            case "shoot":
                SFXAudioSrc.PlayOneShot(ShootSound, 2);
                break;
            case "walking":
                SFXAudioSrc.PlayOneShot(WalkingSound, 10);
                break;
            case "step":
                SFXAudioSrc.PlayOneShot(StepSound, 10);
                break;
            case "coin":
                SFXAudioSrc.PlayOneShot(CoinSound);
                break;
            case "extraLife":
                SFXAudioSrc.PlayOneShot(ExtraLifeSound);
                break;
        }
    }
}
