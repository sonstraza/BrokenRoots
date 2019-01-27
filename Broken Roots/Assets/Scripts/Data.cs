using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.UI;

//Data class being saved
[Serializable]
public class CharacterData
{
    //List of NPC names as strings
    public List<string> NPCNames;
    //List of key items as strings
    public List<string> itemNames;
    //Amount of gold.
    public int gold;
}

public class Data
{
    //Send in from game
    public List<GameObject> npcsInTown;
    //Send in from game
    public List<GameObject> keyItem;
    public CharacterData charaData;

    //Set in Unity
    public Button saveButton;
    public Button loadButton;

    const string folderName = "BinaryCharacterData";
    const string fileExtension = ".dat";

    void Start()
    {
        npcsInTown = new List<GameObject>();
        keyItem = new List<GameObject>();
        //Called when save button in UI is clicked
        saveButton.onClick.AddListener(SaveGame);
        //Called when load button in UI is clicked
        loadButton.onClick.AddListener(LoadGame);
    }

    /// <summary>
    /// Saves game
    /// </summary>
    void SaveGame()
    {
        //Iterates through all NPCs storing only the name of the prefab as strings
        foreach (GameObject npc in npcsInTown)
        {
            charaData.NPCNames.Add(npc.name);
        }
        //Iterates through all key items storing only the name of the prefab as strings
        foreach (GameObject item in keyItem)
        {
            charaData.itemNames.Add(item.name);
        }
        string folderPath = Path.Combine(Application.persistentDataPath, folderName);
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        string pathString = "charaData";
        string dataPath = Path.Combine(folderPath, pathString + fileExtension);
        BinaryFormatter binaryFormatter = new BinaryFormatter();

        using (FileStream fileStream = File.Open(pathString, FileMode.OpenOrCreate))
        {
            binaryFormatter.Serialize(fileStream, charaData);
        }
    }

    /// <summary>
    /// Loads game
    /// </summary>
    void LoadGame()
    {
        string[] filePaths = GetFilePaths();

        if (filePaths.Length > 0)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (FileStream fileStream = File.Open(filePaths[0], FileMode.Open))
            {
                //Sets charaData, then extract from it to put into game when loading.
                charaData = (CharacterData) binaryFormatter.Deserialize(fileStream);
            }
        }
    }

    /// <summary>
    /// Returns file path
    /// </summary>
    /// <returns></returns>
    static string[] GetFilePaths()
    {
        string folderPath = Path.Combine(Application.persistentDataPath, folderName);

        return Directory.GetFiles(folderPath, fileExtension);
    }
}
