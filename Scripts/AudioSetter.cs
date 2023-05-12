using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioSetter : MonoBehaviour
{
    [SerializeField] private AudioMixer Mixer;

    private void Start() 
    {
        Mixer.SetFloat("GlobalVolume", StaticLibrary.volumeAudio * 50 - 50);
    }
}
