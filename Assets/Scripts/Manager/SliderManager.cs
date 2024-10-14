using UnityEngine;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider sfxSlider;
    [SerializeField] private Slider musicSlider;

    private void Start()
    {
        masterSlider.value = AudioManager.Instance.GetMasterVolume();
        sfxSlider.value = AudioManager.Instance.GetSFXVolume();
        musicSlider.value = AudioManager.Instance.GetMusicVolume();

        masterSlider.onValueChanged.AddListener(OnMasterVolumeChange);
        sfxSlider.onValueChanged.AddListener(OnSFXVolumeChange);
        musicSlider.onValueChanged.AddListener(OnMusicVolumeChange);
    }

    private void OnMasterVolumeChange(float value)
    {
        AudioManager.Instance.UpdateMasterVolume(value);
    }

    private void OnSFXVolumeChange(float value)
    {
        AudioManager.Instance.UpdateSFXVolume(value);
    }

    private void OnMusicVolumeChange(float value)
    {
        AudioManager.Instance.UpdateMusicVolume(value);
    }
}