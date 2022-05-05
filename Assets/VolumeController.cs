using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider = null;
    [SerializeField] private Text volumeText = null;

    private void Start()
    {
        LoadValues();
    }

    public void VolumeSlider(float volume)
    {
        volumeText.text = volume.ToString("0.0");
    }

    public void SaveVolumeButton()
    {
        float volumeValue = volumeSlider.value;
        PlayerPrefs.SetFloat("PopVolume", volumeValue);
        LoadValues();
    }

    void LoadValues()
    {
        float volumeValue = PlayerPrefs.GetFloat("PopVolume");
        volumeSlider.value = volumeValue;
        AudioListener.volume = volumeValue;
    }
}
