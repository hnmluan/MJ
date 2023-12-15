using System;

[Serializable]

public class TaskData
{
    public string code;
    public string status;

    public TaskData()
    {
        this.code = Task.Instance.CurrentTask.code.ToString();
        this.status = Task.Instance.CurrentTask.status.ToString();
    }
}
