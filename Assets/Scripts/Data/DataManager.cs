using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    [SerializeField]string fileName;
    GameData gameData;
    FileManager fileManager; //TODO muuta staattiseksi

    List<ISaveLoad> saveableObjects;

  

    public static DataManager instance;

    void Awake()
    {
        if(instance!= null)
        {
            Debug.LogError("found more than 1 data manager in the scene");
        }
        instance = this;
    }
    void Start()
    {
        //Debug.Log(Application.persistentDataPath); //riippuu mikä OS
        //Debug.Log(Application.dataPath); // Assets-kansio
        fileManager = new FileManager(fileName, Application.dataPath + "/Saves");
        saveableObjects = FindAllSaveableObjects();
        LoadGame();
    }

    void NewGame()
    {
        gameData = new GameData();
    }
    void LoadGame()
    {
        //haetaan tiedostosta pelaajan alkusijanti
        gameData = fileManager.Load(); //palauttaa gameDataan tiedot JSONista

        //jos gameDataa ei ole, initialisoidaan uusi peli
        if (gameData == null)
        {
            NewGame();
        }

        //käydään läpi kaikki saveable-objektit
        foreach (ISaveLoad script in saveableObjects)
        {
            Debug.Log(script);
            script.LoadData(gameData);
        }
    }
    void SaveGame()
    {
        //käydään läpi kaikki saveable-objektit
        foreach (ISaveLoad script in saveableObjects)
        {           
            script.SaveData(gameData);
        }
        //print(gameData.playerPosition);
        //tallennetaan gameDatan sisätö tiedostoon
        fileManager.Save(gameData);
    }
    void OnApplicationQuit()
    {
        SaveGame();
        Debug.Log("QUITTED");
    }

    List<ISaveLoad> FindAllSaveableObjects()
    {
        IEnumerable<ISaveLoad> saveableObjects = FindObjectsOfType<MonoBehaviour>().OfType<ISaveLoad>();
        return new List<ISaveLoad>(saveableObjects);
    }

}

