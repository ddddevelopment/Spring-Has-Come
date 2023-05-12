using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio; 

public class AudioController : MonoBehaviour
{
    [SerializeField] private Slider VolumeAudio_Slider;
    [SerializeField] private Image IconAudio_Image;

    [SerializeField] private AudioMixer Mixer;

    private void Start()
    {
        VolumeAudio_Slider.value = StaticLibrary.volumeAudio;
    }

    public void OnChangeAudioVolume()
    {
        StaticLibrary.volumeAudio = VolumeAudio_Slider.value;
        SaveManager.instance.activeSave.volumeAudio = StaticLibrary.volumeAudio;
        SaveManager.instance.Save();

        Mixer.SetFloat("GlobalVolume", StaticLibrary.volumeAudio * 50 - 50);
    }
}
