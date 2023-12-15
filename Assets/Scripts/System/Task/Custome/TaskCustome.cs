using System.Collections.Generic;
using UnityEngine;

public class TaskCustome : InitMonoBehaviour, IObservationTask
{
    [SerializeField] protected List<TaskCustomeElement> taskCustomeElements;

    protected override void Awake() => Task.Instance.AddObservation(this);

    protected override void Start() => this.Custome();

    protected override void ResetValue()
    {
        base.ResetValue();
        this.taskCustomeElements = new List<TaskCustomeElement>(GetComponentsInChildren<TaskCustomeElement>());
    }

    protected void Custome()
    {
        foreach (TaskCustomeElement taskCustomeElement in taskCustomeElements)
        {
            if (taskCustomeElement.task.status == Task.Instance.CurrentTask.status && taskCustomeElement.task.code == Task.Instance.CurrentTask.code)
            {
                taskCustomeElement.Show();
                return;
            }
        }
    }

    public void DoneTask() => this.Custome();

    public void Switch2NextTask() => this.Custome();

    public void AcceptTask() => this.Custome();
}
