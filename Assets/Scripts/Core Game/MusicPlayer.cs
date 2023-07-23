using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;

    private void Awake()
    {
        if(FindObjectsOfType<MusicPlayer>().Length > 1)
        { Destroy(gameObject); }
    }
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);
        audioSource = GetComponent<AudioSource>();
        audioSource.volume=PlayerPrefsController.GetMasterVolume();
    }
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
    
}
