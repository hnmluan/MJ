using UnityEngine;
using UnityEngine.UI;

public class TaskIndicator : InitMonoBehaviour, IObservationTask
{
    [SerializeField] protected Image iconTask;
    public Image IconTask => iconTask;

    [SerializeField] protected Button btnTask;
    public Button BtnTask => btnTask;

    [SerializeField] protected Text progress;
    public Text Progress => progress;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadIconTask();
        this.LoadBtnTask();
        this.LoadProgress();
    }

    protected override void Start()
    {
        base.Start();
        this.SwitchToTaskStatus(Task.Instance.CurrentTask.status);
        Task.Instance.AddObservation(this);
    }

    private void LoadIconTask()
    {
        if (this.iconTask != null) return;
        this.iconTask = transform.Find("BtnOpenTask").Find("TaskIcon").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadIconTask", gameObject);
    }

    private void LoadBtnTask()
    {
        if (this.btnTask != null) return;
        this.btnTask = transform.Find("BtnOpenTask").GetComponent<Button>();
        Debug.Log(transform.name + ": LoadBtnTask", gameObject);
    }

    private void LoadProgress()
    {
        if (this.progress != null) return;
        this.progress = transform.Find("Progress").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadProgress", gameObject);
    }

    protected void SwitchToTaskStatus(TaskStatus status)
    {
        this.iconTask.color = new Color(0.7725f, 0.4196f, 0.3451f); ;
        if (status == TaskStatus.done) iconTask.color = Color.green;
        this.btnTask.gameObject.SetActive(status != TaskStatus.start);
        this.progress.text = Task.Instance.GetProgress() + "%";
        this.progress.gameObject.SetActive(!(Task.Instance.CurrentTask.status == TaskStatus.start));
    }

    public void DoneCriteriaTask() => SwitchToTaskStatus(Task.Instance.CurrentTask.status);

    public void Switch2NextTask() => SwitchToTaskStatus(Task.Instance.CurrentTask.status);

    public void AcceptTask() => SwitchToTaskStatus(Task.Instance.CurrentTask.status);

}
