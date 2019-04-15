using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class SaveData
{
    public string name;
    public int levelsCleared;

    public SaveData(string name, int levelsCleared)
    {
        this.name = name;
        this.levelsCleared = levelsCleared;
    }


   
}
