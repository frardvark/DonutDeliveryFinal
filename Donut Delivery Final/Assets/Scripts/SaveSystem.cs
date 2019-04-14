using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    

    public static void SaveState(int saveFile, int levelsCleared)
    {
        BinaryFormatter bf = new BinaryFormatter();
        string fileName = getName(saveFile);
        string path = Application.persistentDataPath + "/" + fileName;
        Debug.Log("Path: " + path); 

        using (FileStream stream = new FileStream(path, FileMode.Create))
        {
            SaveData data = new SaveData(fileName, levelsCleared);
            bf.Serialize(stream, data);
        }
    }

    public static SaveData LoadState(int saveFile)
    {
        string fileName = getName(saveFile);
        string path = Application.persistentDataPath + "/" + fileName;
        Debug.Log("Path: " + path);
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (FileStream stream = new FileStream(path, FileMode.Open))
            {
                SaveData data = bf.Deserialize(stream) as SaveData;
                return data;
            }
        }
        else
        {
            Debug.Log("Save File not found, creating new save file");
            SaveState(saveFile, 0);
            return LoadState(saveFile);
        }
    }

    private static string getName(int saveFile)
    {
        Debug.Log("getName called with saveFile number " + saveFile);
        string fileName = "";
        switch (saveFile)
        {
            case 1:
                fileName = "file1.sav";
                Debug.Log("Case 1 called");
                break;
            case 2:
                fileName = "file2.sav";
                break;
            case 3:
                fileName = "file3.sav";
                break;
            case 4:
                fileName = "file4.sav";
                break;
            default:
                fileName = "file1.sav";
                Debug.Log("Default called");
                break;
        }
        return fileName;
    }
}
