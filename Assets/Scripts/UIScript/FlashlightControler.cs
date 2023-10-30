using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class FlashlightControler : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Light _flashlight;



    void Start()
    {
        string flashLight = "flashLightRange"; // Store the key in a variable to avoid typos
        if (!PlayerPrefs.HasKey(flashLight))
        {
            PlayerPrefs.SetFloat(flashLight, _slider.value);
            Load();
        }
        else
        {
            Load();
        }
    }

    // Update is called once per frame
    public void ChangeRange()
    {
        _flashlight.range = _slider.value;
        Save();
    }
    private void Load()
    {
        _slider.value = PlayerPrefs.GetFloat("flashLightRange");
    }

    private void Save()
    {
        PlayerPrefs.SetFloat("flashLightRange", _slider.value);
    }
}
