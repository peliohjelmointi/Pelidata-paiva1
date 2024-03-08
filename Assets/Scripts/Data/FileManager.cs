using UnityEngine;
using System.IO;
using System;

public class FileManager 
{
    string fileName="";
    string directoryPath="";

    public FileManager(string fileName, string directoryPath)
    {
        this.fileName = fileName;
        this.directoryPath = directoryPath;
    }

    //public GameData Load()
    //{
    //    string fullPath = Path.Combine(directoryPath, fileName);
    //}

    void Start()
    {
        
    }


}
