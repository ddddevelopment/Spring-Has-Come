using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Xml.Serialization;

public class SaveManager : MonoBehaviour
{
    public static SaveManager instance;
    public SaveData activeSave;

    public bool hasLoaded;

    private void Awake() 
    {
        instance = this;
        Load();
    }

    public void Save()
    {
        string dataPath = Application.persistentDataPath;

        var fileSerializer = new XmlSerializer(typeof(SaveData));
        var fileStream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Create);

        fileSerializer.Serialize(fileStream, activeSave);
        fileStream.Close();

        Debug.Log("Save");
    }

    public void Load()
    {
        string dataPath = Application.persistentDataPath;

        if (File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
        {
            var fileSerializer = new XmlSerializer(typeof(SaveData));
            var fileStream = new FileStream(dataPath + "/" + activeSave.saveName + ".save", FileMode.Open);

            activeSave = fileSerializer.Deserialize(fileStream) as SaveData;
            fileStream.Close();

            Debug.Log("Load");
            hasLoaded = true;
        }
    }

    public void DeleteSave()
    {
        string dataPath = Application.persistentDataPath;

        if (File.Exists(dataPath + "/" + activeSave.saveName + ".save"))
        {
            File.Delete(dataPath + "/" + activeSave.saveName + ".save");
        }
    }
}

[System.Serializable]
public class SaveData
{
    public string saveName;
    public int recordScore;
    public int difficultyLevel;
    public float volumeAudio;
}