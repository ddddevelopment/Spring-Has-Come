using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Record : MonoBehaviour
{
    [SerializeField] private TMPro.TMP_Text RecordScoreHUD;

    private void Start() 
    {
        StaticLibrary.recordScore = SaveManager.instance.activeSave.recordScore;
        RecordScoreHUD.text = StaticLibrary.recordScore.ToString();
    }
}
