using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System;

public static class SaveSystem
{
    public static void SavePlayer(progressSaver player)
    {
        // Remove the Application.isEditor check for now

        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + "/Player.fun";

        try
        {
            using (FileStream stream = new FileStream(path, FileMode.Create))
            {
                PlayerData data = new PlayerData(player);
                formatter.Serialize(stream, data);
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Error saving player data: " + e.Message);
        }
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/Player.fun";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();

            try
            {
                using (FileStream stream = new FileStream(path, FileMode.Open))
                {
                    PlayerData data = formatter.Deserialize(stream) as PlayerData;
                    return data;
                }
            }
            catch (Exception e)
            {
                Debug.LogError("Error loading save file: " + e.Message);
                return null;
            }
        }
        else
        {
            Debug.Log("Save File not found in " + path);
            return null;
        }
    }
}
