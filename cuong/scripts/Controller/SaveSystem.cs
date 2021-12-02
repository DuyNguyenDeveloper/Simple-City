using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static void SaveListHouse(List<HouseData> lsHouse)
    {
        if (lsHouse != null)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            string path = Application.persistentDataPath + "/listHouse.fun";
            FileStream stream = new FileStream(path, FileMode.Create);
            formatter.Serialize(stream, lsHouse);
            /* foreach (HouseData obj in lsHouse)
             {
                 formatter.Serialize(stream, obj);
             }*/
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
}