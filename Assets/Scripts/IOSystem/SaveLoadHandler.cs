using System.IO;
using UnityEngine;


public static class SaveLoadHandler
{
    public static void SaveToFile(string fileName, object data)
    {
        string path = FileNameData.GetFullPath(fileName);
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(path, json);
        Debug.Log("SaveToFile " + path);
        Debug.Log(json);
    }

    public static T LoadFromFile<T>(string fileName) where T : class
    {
        string path = FileNameData.GetFullPath(fileName);
        Debug.Log(path);
        if (!File.Exists(path)) return null;
        try
        {
            string json = File.ReadAllText(path);
            Debug.Log(path);
            Debug.Log(json);
            return JsonUtility.FromJson<T>(json);
        }
        catch
        {
            Debug.Log("Null");
            return null;
        }

    }
}

