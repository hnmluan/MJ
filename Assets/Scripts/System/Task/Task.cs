using System;
using System.Collections.Generic;
using System.Linq;
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

public enum CriteriaStatus
{
    processing = 0,
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

    public List<CriteriaStatus> criterias = new List<CriteriaStatus>();

    protected override void Awake() => this.LoadData();

    public void LoadData()
    {
        TaskData data = SaveLoadHandler.LoadFromFile<TaskData>(FileNameData.Task);

        if (data == null)
        {
            this.currentTask = new TaskInformation(TaskCode.Greeting, TaskStatus.start);
            TaskDataSO.FindByItemCode(TaskCode.Greeting).criterias.ForEach(p => { this.criterias.Add(CriteriaStatus.processing); });
            this.SaveData();
            return;
        };

        this.currentTask.code = (TaskCode)Enum.Parse(typeof(TaskCode), data.code);
        this.currentTask.status = (TaskStatus)Enum.Parse(typeof(TaskStatus), data.status);
        data.process.ForEach(p => { this.criterias.Add((CriteriaStatus)Enum.Parse(typeof(CriteriaStatus), p)); });
    }

    public void SaveData() => SaveLoadHandler.SaveToFile(FileNameData.Task, new TaskData());

    public TaskDataSO GetDataSO() => TaskDataSO.FindByItemCode(this.currentTask.code);

    public int GetProgress()
        => criterias.Count(x => x == CriteriaStatus.done) == 0 ? 0 :
        (int)Math.Round((double)(criterias.Count(x => x == CriteriaStatus.done)) / criterias.Count * 100);

    public virtual void AddObservation(IObservationTask observation) => observations.Add(observation);

    public virtual void RemoveObservation(IObservationTask observation) => observations.Remove(observation);

    public void Switch2NextTask()
    {
        if (this.currentTask.status != TaskStatus.done) return;
        this.currentTask.code++;
        this.currentTask.status = TaskStatus.start;
        TaskDataSO.FindByItemCode(currentTask.code).criterias.
            ForEach(p => { this.criterias.Add((CriteriaStatus)Enum.Parse(typeof(CriteriaStatus), p)); });
        this.ExcuteSwitchTaskObservation();
        this.SaveData();
    }

    public void AcceptTask()
    {
        this.currentTask.status = TaskStatus.processing;
        this.ExcuteAcceptTaskObservation();
        this.SaveData();
    }

    public void DoneCriteriaTask(int critera)
    {
        if (critera > criterias.Count) return;
        criterias[critera - 1] = CriteriaStatus.done;
        if (GetProgress() == 100) this.currentTask.status = TaskStatus.done;
        this.ExcuteDoneTaskObservation();
        this.SaveData();
    }

    public virtual void ExcuteDoneTaskObservation() { foreach (IObservationTask observation in observations) observation.DoneCriteriaTask(); }

    public virtual void ExcuteSwitchTaskObservation() { foreach (IObservationTask observation in observations) observation.Switch2NextTask(); }

    public virtual void ExcuteAcceptTaskObservation() { foreach (IObservationTask observation in observations) observation.AcceptTask(); }
}
