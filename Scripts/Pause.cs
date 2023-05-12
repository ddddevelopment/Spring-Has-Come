using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool IsPause;
    [SerializeField] private GameObject PauseMenu_Panel;

    private void Start() 
    {
        IsPause = false;
        PauseMenu_Panel.SetActive(IsPause);
    }

    void OnDestroy()
    {
        Time.timeScale = 1f;
    }

    public void ChangeActivePauseMenu()
    {
        IsPause = !IsPause;
        PauseMenu_Panel.SetActive(IsPause);

        if (IsPause)
            Time.timeScale = 0f;
        else
            Time.timeScale = 1f;
    }
}
