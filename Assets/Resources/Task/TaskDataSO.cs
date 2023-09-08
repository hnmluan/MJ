using UnityEngine;

[CreateAssetMenu(fileName = "TaskDataSO", menuName = "SO/TaskDataSO")]

public class TaskDataSO : ScriptableObject
{
    public TaskCode taskCode = TaskCode.NoTask;

    public string keyName;

    public string keyDescription;

    public static TaskDataSO FindByItemCode(TaskCode taskCode)
    {
        var profiles = Resources.LoadAll("Task/SO", typeof(TaskDataSO));
        foreach (TaskDataSO profile in profiles)
        {
            if (profile.taskCode != taskCode) continue;
            return profile;
        }
        return null;
    }
}


