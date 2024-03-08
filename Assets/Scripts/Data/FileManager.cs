using Newtonsoft.Json;
using System.IO;
using UnityEngine;
using System;

public class FileManager
{
    string fileName = "";
    string directoryPath = "";

    public FileManager(string fileName, string directoryPath)
    {
        this.fileName = fileName;
        this.directoryPath = directoryPath;
    }

    public GameData Load()
    {
        string fullPath = Path.Combine(directoryPath, fileName);
        GameData gameData = null;
        if (File.Exists(fullPath))
        {
            try
            {
                //ladataan json-data tiedostosta
                string dataToLoad = "";
                using (FileStream stream = new FileStream(fullPath, FileMode.Open))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        dataToLoad = reader.ReadToEnd();
                    }
                }

                //'deserialisoidaan' eli muutetaan JSON-muotoinen teksti
                //C#-objektiksi eli C# ymm‰rt‰m‰‰n muotoon

                //jos et k‰yt‰ Newtonsoftin JSON.NET, niin Unityn omalla:                
                //gameData = JsonUtility.FromJson<GameData>(dataToLoad);
                //tai
                //jos k‰yt‰t JSON.NET:
                gameData = JsonConvert.DeserializeObject<GameData>(dataToLoad);
            }
            catch (Exception e)
            {
                Debug.Log($"Cannot load {fullPath} : Exception:{e}");
            }
        }
        return gameData;

    }

    public void Save(GameData data)
    {
        string fullPath = Path.Combine(directoryPath, fileName);
        try
        {
            //luodaan hakemisto, jos sit‰ ei viel‰ ole
            Directory.CreateDirectory(Path.GetDirectoryName(fullPath));

            //Serialisoidaan data JSON-muotoon
            //Unityn JsonUtilityll‰:
            //string dataToStore = JsonUtility.ToJson(gameData,true);
            //tai JSON.NET:ll‰:
            string dataToStore = JsonConvert.SerializeObject(data, Formatting.Indented, new JsonSerializerSettings
            { ReferenceLoopHandling = ReferenceLoopHandling.Ignore});

            // kirjoitetaan serialisoitu data JSON-muoossa tiedostoon
            using (FileStream stream = new FileStream(fullPath, FileMode.Create))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.Write(dataToStore);
                }
            }

        }
        catch (Exception e)
        {
            Debug.LogWarning($"Error saving file in {fullPath}, with error {e}");
        }
    }
}



