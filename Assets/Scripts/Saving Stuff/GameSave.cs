using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Saving_Stuff;
using UnityEngine;

public class GameSave : MonoBehaviour
{
    public GameState gs;
    

    public void SaveData()
    {
        if (!Directory.Exists("Saves"))
            Directory.CreateDirectory("Saves");

        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Create("Saves/save.bin");

        formatter.Serialize(saveFile, gs);

        saveFile.Close();
    }

    public void LoadData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        FileStream saveFile = File.Open("Saves/save.bin", FileMode.Open);

        gs = (GameState)formatter.Deserialize(saveFile);

        saveFile.Close();
    }
}
