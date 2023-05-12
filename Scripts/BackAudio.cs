using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackAudio : MonoBehaviour
{
    [SerializeField] private AudioSource BackAudioInGame;
    
    private void Update()
    {
        if (Time.timeScale == 0f)
        {
            BackAudioInGame.mute = true;
        }
        else
        {
            BackAudioInGame.mute = false;
        }
    }
}
