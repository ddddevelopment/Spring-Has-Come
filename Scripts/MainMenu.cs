using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject History_Panel;
    [SerializeField] private GameObject MainWindow_Panel;

    [SerializeField] private AudioSource AudioForHistory;
    [SerializeField] private AudioSource AudioForMainWindow;

    private void Start() 
    {
        if (!SaveManager.instance.hasLoaded)
        {
            OnOrOffHistory(true);
            StaticLibrary.volumeAudio = 0.99f;
        }
        else
        {
            OnOrOffHistory(false);
            StaticLibrary.volumeAudio = SaveManager.instance.activeSave.volumeAudio;
        }
    }

    public void CloseHistory()
    {
        OnOrOffHistory(false);
    }

    private void OnOrOffHistory(bool IsActive)
    {
        History_Panel.SetActive(IsActive);
        MainWindow_Panel.SetActive(!IsActive);

        if (IsActive) 
        {
            AudioForHistory.Play();
            AudioForMainWindow.Pause();
        }  
            
        else
        {
            AudioForHistory.Pause();
            AudioForMainWindow.Play();
        }
        
    }
}
