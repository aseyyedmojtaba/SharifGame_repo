using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] float defaultVolume = 0.8f;
    [SerializeField] Slider volumeEffectSlider;
    [SerializeField] float defultEffectVolume = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        volumeEffectSlider.value = PlayerPrefsController.GetEffectVolume();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer != null)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        }
        else
        {
            Debug.LogWarning("no musicPlayer do you start from splash screen?");
        }
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        PlayerPrefsController.SetEffectVolume(volumeEffectSlider.value);
        FindObjectOfType<LevelLoader>().LoadeMainScene();
    }

    public void SetDefaults()
    {
        volumeSlider.value = defaultVolume;
        volumeEffectSlider.value = defultEffectVolume;
    }
}
