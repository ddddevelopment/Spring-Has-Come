using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySettings : MonoBehaviour
{
    [SerializeField] private List<Button> ButtonsDifficultyLevel = new List<Button>(3);
    [SerializeField] private Sprite selectedButton_Sprite;
    [SerializeField] private Sprite notSelectedButton_Sprite;

    private void Awake() 
    {
        if (SaveManager.instance.hasLoaded)
            StaticLibrary.difficultyLevel = SaveManager.instance.activeSave.difficultyLevel;
        else
            StaticLibrary.difficultyLevel = 1;

        ChangeDifficultyLevel(StaticLibrary.difficultyLevel);
    }

    public void ChangeDifficultyLevel(int difficulty)
    {
        StaticLibrary.difficultyLevel = difficulty;
        SaveManager.instance.activeSave.difficultyLevel = StaticLibrary.difficultyLevel;
        SaveManager.instance.Save();
        ButtonsDifficultyLevel[difficulty - 1].GetComponent<Image>().sprite = selectedButton_Sprite;
        for (int i = 0; i < ButtonsDifficultyLevel.Count; i++)
        {
            if (i != difficulty - 1)
            {
                ButtonsDifficultyLevel[i].GetComponent<Image>().sprite = notSelectedButton_Sprite;
            }
        }
    }
}
