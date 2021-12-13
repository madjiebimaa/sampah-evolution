using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishCrashAudio : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip Click;
    public static FishCrashAudio sfxInstance;
    private void Awake() {
        if (sfxInstance != null && sfxInstance != this) 
        {
            Destroy(this.gameObject);
            return;
        }    

        sfxInstance = this;
        DontDestroyOnLoad(this);
    }
}
