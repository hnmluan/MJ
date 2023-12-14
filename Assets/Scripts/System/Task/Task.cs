﻿using System;
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
    processing = 0,
    done = 1
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
    public List<IObservationTask> observations;

    [SerializeField] public TaskInformation currentTask;

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

    public virtual void AddObservation(IObservationTask observation) => observations.Add(observation);

    public virtual void RemoveObservation(IObservationTask observation) => observations.Remove(observation);

    public void Switch2NextTask()
    {
        if (currentTask.code == TaskCode.Ending) return;
        if (this.currentTask.status != TaskStatus.done) return;
        currentTask.code++;
        currentTask.status = TaskStatus.processing;
        this.ShowPanel();
        this.ExcuteSwitchTaskObservation();
        this.SaveData();
    }
    public void DoneTask()
    {
        currentTask.status = TaskStatus.done;
        this.ExcuteDoneTaskObservation();
        this.SaveData();
    }

    public void ShowPanel()
    {
        TaskDataSO dataSO = TaskDataSO.FindByItemCode(currentTask.code);

        if (dataSO == null)
        {
            Debug.Log(transform.name + "Don't found task's data");
            return;
        };

        UITask.Instance.ShowTask(dataSO.title, dataSO.content);
    }

    public virtual void ExcuteDoneTaskObservation() { foreach (IObservationTask observation in observations) observation.DoneTask(); }

    public virtual void ExcuteSwitchTaskObservation() { foreach (IObservationTask observation in observations) observation.Switch2NextTask(); }

}