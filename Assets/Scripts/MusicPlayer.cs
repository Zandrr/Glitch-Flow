using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        audiosource = GetComponent<AudioSource>();
        audiosource.volume = PlayerPrefsController.GetMasterVolume();
    }


    public void SetVolume(float volume)
    {
        audiosource.volume = volume;
    }
}
