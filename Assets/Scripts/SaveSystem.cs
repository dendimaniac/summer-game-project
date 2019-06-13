using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{
    // public static void SavePos(Vector3 playerPos)
    // {
    //     BinaryFormatter formatter = new BinaryFormatter();
    //     string path = Application.persistentDataPath + "/ppos.bin";
    //     FileStream stream = new FileStream(path, FileMode.Create);

    //     PlayerPos positionData = new PlayerPos(playerPos);

    //     formatter.Serialize(stream, positionData);
    //     stream.Close();
    // }

    // public static PlayerPos LoadPos()
    // {
    //     string path = Application.persistentDataPath + "/ppos.bin";
    //     if (File.Exists(path))
    //     {
    //         BinaryFormatter formatter = new BinaryFormatter();
    //         FileStream stream = new FileStream(path, FileMode.Open);

    //         PlayerPos playerPos = formatter.Deserialize(stream) as PlayerPos;
    //         stream.Close();

    //         Debug.Log("SaveSystem " + playerPos);
    //         return playerPos;
    //     }
    //     else
    //     {
    //         Debug.Log("Save file not found in " + path);
    //         return null;
    //     }
    // }
}
