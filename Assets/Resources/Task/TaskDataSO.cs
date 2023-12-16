using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Task", menuName = "ScriptableObject/Task")]

public class TaskDataSO : ScriptableObject
{
    public TaskCode taskCode = TaskCode.Greeting;

    public string title;

    public string content;

    public List<string> criterias;

    public static TaskDataSO FindByItemCode(TaskCode taskCode)
    {
        var profiles = Resources.LoadAll("Task/ScriptableObject", typeof(TaskDataSO));
        foreach (TaskDataSO profile in profiles)
        {
            if (profile.taskCode != taskCode) continue;
            return profile;
        }
        return null;
    }
}


