using System;

[Serializable]

public class TaskData
{
    public string code;
    public string status;

    public TaskData()
    {
        this.code = Task.Instance.currentTask.code.ToString();
        this.status = Task.Instance.currentTask.status.ToString();
    }
}
