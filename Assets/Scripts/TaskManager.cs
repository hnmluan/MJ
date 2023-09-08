using System;

public enum TaskCode
{
    NoTask = 0,
    Greeting = 1,
    Task_1 = 2,
    Task_2 = 3,
    Task_3 = 4,
    Task_4 = 5,
    Ending = 6,
}

public class TaskManager : Singleton<TaskManager>
{
    public TaskCode currentTask = TaskCode.NoTask;

    public Action<TaskCode> Switch2NextTask;

    public void Switch2NextTaskEnumCode()
    {
        if (currentTask == TaskCode.Ending) return;
        currentTask++;
    }
}
