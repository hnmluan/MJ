using System;
using System.Collections.Generic;

[Serializable]

public class TaskData
{
    public string code;
    public string status;
    public List<string> process = new List<string>();

    public TaskData()
    {
        this.code = Task.Instance.CurrentTask.code.ToString();
        this.status = Task.Instance.CurrentTask.status.ToString();
        foreach (CriteriaStatus task in Task.
            Instance.
            criterias)
            this.process.Add(task.ToString());
    }
}
