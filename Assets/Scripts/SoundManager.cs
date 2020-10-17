using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{


    public static AudioClip playerTapa;
    public static AudioClip playerPulo;
    public static AudioClip playerDor;
    static AudioSource audioSrc;


    // Start is called before the first frame update
    void Start()
    {
        playerTapa = Resources.Load<AudioClip>("tapa");
        playerPulo = Resources.Load<AudioClip>("pulo");
        playerDor = Resources.Load<AudioClip>("dor");

        audioSrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    public static void PlaySound(string clip){
        switch (clip) {
            case "tapa":
                audioSrc.PlayOneShot(playerTapa);
                break;
            case "pulo":
                audioSrc.PlayOneShot(playerPulo);

                break;
            case "dor":
                audioSrc.PlayOneShot(playerDor);

                break;
        }    
    }
}
