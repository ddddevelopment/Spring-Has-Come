using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsInUI : MonoBehaviour
{
    public void ToCertainScene(int indexScene)
    {
        SceneManager.LoadScene(indexScene);
    }
}
