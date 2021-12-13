using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishEatAudio : MonoBehaviour
{
    public AudioSource Audio;
    public AudioClip Click;
    public static FishEatAudio sfxInstance;
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
