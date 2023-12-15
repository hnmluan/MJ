using System;
using System.Collections.Generic;
using UnityEngine;

public enum TaskCode
{
    Greeting = 1,
    Task_1 = 2,
    Task_2 = 3,
    Task_3 = 4,
    Task_4 = 5,
    Ending = 6,
}

public enum TaskStatus
{
    start = 0,
    processing = 1,
    done = 2
}

[Serializable]
public class TaskInformation
{
    public TaskCode code;
    public TaskStatus status;

    public TaskInformation(TaskCode code, TaskStatus status)
    {
        this.code = code;
        this.status = status;
    }
}

public class Task : Singleton<Task>
{
    private List<IObservationTask> observations = new List<IObservationTask>();

    [SerializeField] protected TaskInformation currentTask;
    public TaskInformation CurrentTask => currentTask;

    protected override void Awake() => this.LoadData();

    public void LoadData()
    {
        TaskData data = SaveLoadHandler.LoadFromFile<TaskData>(FileNameData.Task);

        if (data == null)
        {
            this.currentTask = new TaskInformation(TaskCode.Greeting, TaskStatus.processing);
            this.SaveData();
            return;
        };

        this.currentTask.code = (TaskCode)Enum.Parse(typeof(TaskCode), data.code);
        this.currentTask.status = (TaskStatus)Enum.Parse(typeof(TaskStatus), data.status);
    }

    public void SaveData() => SaveLoadHandler.SaveToFile(FileNameData.Task, new TaskData());

    public TaskDataSO GetDataSO() => TaskDataSO.FindByItemCode(this.currentTask.code);

    public virtual void AddObservation(IObservationTask observation) => observations.Add(observation);

    public virtual void RemoveObservation(IObservationTask observation) => observations.Remove(observation);

    public void Switch2NextTask()
    {
        if (currentTask.code == TaskCode.Ending) return;
        if (this.currentTask.status != TaskStatus.done) return;
        this.currentTask.code++;
        this.currentTask.status = TaskStatus.start;
        this.ExcuteSwitchTaskObservation();
        this.SaveData();
    }

    public void AcceptTask()
    {
        this.currentTask.status = TaskStatus.processing;
        this.ExcuteAcceptTaskObservation();
        this.SaveData();
    }

    public void DoneTask()
    {
        currentTask.status = TaskStatus.done;
        this.ExcuteDoneTaskObservation();
        this.SaveData();
    }

    public virtual void ExcuteDoneTaskObservation() { foreach (IObservationTask observation in observations) observation.DoneTask(); }

    public virtual void ExcuteSwitchTaskObservation() { foreach (IObservationTask observation in observations) observation.Switch2NextTask(); }

    public virtual void ExcuteAcceptTaskObservation() { foreach (IObservationTask observation in observations) observation.AcceptTask(); }
}
