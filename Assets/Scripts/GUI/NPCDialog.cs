using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TaskDialog
{
    public string taskDialogName;

    [SerializeField] List<string> localizationKeys;

    public List<string> LocalizationKeys { get => localizationKeys; }
}


[System.Serializable]
public class NPCDialog
{
    [SerializeField] List<TaskDialog> taskDialogs;

    public List<TaskDialog> TaskDialogs { get => taskDialogs; }

    public List<string> GetLocalizationKeysForTask(string taskName)
    {

        foreach (TaskDialog taskDialog in taskDialogs)
        {
            if (taskDialog.taskDialogName == taskName)
            {
                return taskDialog.LocalizationKeys;
            }
        }

        Debug.LogWarning("Task not found: " + taskName);
        return new List<string>();
    }
}
