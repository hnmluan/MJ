using System.IO;
using UnityEngine;


public static class SaveLoadHandler
{
    public static void SaveToFile(string fileName, object data)
    {
        string path = FileNameData.GetFullPath(fileName);
        string json = JsonUtility.ToJson(data);
        Debug.Log(json);
        Debug.Log(path);
        File.WriteAllText(path, json);
    }

    public static T LoadFromFile<T>(string fileName) where T : class
    {
        string path = FileNameData.GetFullPath(fileName);
        if (!File.Exists(path))
        {
            Debug.Log("Dont exist");
            return null;
        }
        try
        {
            string json = File.ReadAllText(path);
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

