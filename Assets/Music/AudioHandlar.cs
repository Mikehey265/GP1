using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AudioHandlar : MonoBehaviour
{
    public AudioSource _audioSource;
    public Slider _slider;
    // Start is called before the first frame update
    void Start()
    {
        string musicVolumeKey = "musicVolume"; // Store the key in a variable to avoid typos
        if (!PlayerPrefs.HasKey(musicVolumeKey))
        {
            PlayerPrefs.SetFloat(musicVolumeKey, _slider.value);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
    public void ChangeVolume()
    {
        _audioSource.volume = _slider.value;
        Save();
    }
    private void Load()
    {
        _slider.value = PlayerPrefs.GetFloat("musicVolume");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("musicVolume", _slider.value);
    }
}
