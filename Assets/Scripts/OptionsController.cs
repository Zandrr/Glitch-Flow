using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] Slider difficultySlider;
    [SerializeField] float defaultVolume = 0.8f;
    [SerializeField] float defaultDifficulty = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        volumeSlider.value = PlayerPrefsController.GetMasterVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    // Update is called once per frame
    void Update()
    {
        var musicPlayer = FindObjectOfType<MusicPlayer>();
        if (musicPlayer)
        {
            musicPlayer.SetVolume(volumeSlider.value);
        } else
        {
            Debug.LogWarning("No music player found. must start from splash screen");
        }

        PlayerPrefsController.SetDifficulty(difficultySlider.value);
    }

    public void SaveAndExit()
    {
        PlayerPrefsController.SetMasterVolume(volumeSlider.value);
        FindObjectOfType<SceneLoader>().LoadMainMenu();
    }

    public void SetDefaults()
    {
        PlayerPrefsController.SetMasterVolume(defaultVolume);
        volumeSlider.value = defaultVolume;

        PlayerPrefsController.SetDifficulty(defaultDifficulty);
        Debug.Log(PlayerPrefsController.GetDifficulty());
        difficultySlider.value = defaultDifficulty;

    }
}
