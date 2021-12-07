using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static void SaveListHouse(List<HouseData> lsHouse, GameData gameData)
    {
        if (lsHouse != null)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/listHouse.fun";
            FileStream stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, lsHouse);

            path = Application.persistentDataPath + "/gameData.fun";
            stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, gameData);
            Debug.Log(path);
            stream.Close();
        }
    }
    public static List<HouseData> LoadListHouse()
    {
        string path = Application.persistentDataPath + "/listHouse.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            List<HouseData> data = formatter.Deserialize(stream) as List<HouseData>;
            stream.Close();
            return data;
        }
        else
        {
            return new List<HouseData>();
        }
    }

    public static GameData LoadGameData()
    {
        string path = Application.persistentDataPath + "/gameData.fun";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();
            return data;
        }
        else
        {
            return new GameData();
        }
    }
}
