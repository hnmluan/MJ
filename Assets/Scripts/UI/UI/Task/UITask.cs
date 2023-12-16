using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public class UITask : UIBase, IObservationTask
{
    private static UITask instance;
    public static UITask Instance => instance;

    [SerializeField] protected LocalizedText content;
    public LocalizedText Content => content;

    [SerializeField] protected LocalizedText title;
    public LocalizedText Title => title;

    [SerializeField] protected Button btnAccept;
    public Button BtnAccept => btnAccept;

    [SerializeField] protected LocalizedText note;

    protected override void Awake()
    {
        base.Awake();
        if (UITask.instance != null) Debug.LogError("Only 1 UITask allow to exist");
        UITask.instance = this;
    }

    public override void Open()
    {
        this.btnAccept.gameObject.SetActive(Task.Instance.CurrentTask.status == TaskStatus.start);
        this.note.LocalizationKey =
            Task.Instance.CurrentTask.status == TaskStatus.start ? "Task.Accept" :
            Task.Instance.CurrentTask.status == TaskStatus.processing ? "Task.Countinue" : "Task.done";
        TaskDataSO taskDataSO = Task.Instance.GetDataSO();
        this.title.LocalizationKey = taskDataSO == null ? "Dont found task SO" : taskDataSO.title;
        this.content.LocalizationKey = taskDataSO == null ? "Dont found task SO" : taskDataSO.content;
        base.Open();

    }

    protected void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Task.Instance.CurrentTask.status == TaskStatus.start) Task.Instance.AcceptTask();
        if (Input.GetKeyDown(KeyCode.Space) && Task.Instance.CurrentTask.status == TaskStatus.processing) this.Close();
        if (Input.GetKeyDown(KeyCode.Space) && Task.Instance.CurrentTask.status == TaskStatus.done) this.Close();
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTitle();
        this.LoadContent();
        this.LoadBtnAccept();
        this.LoadNote();
    }

    private void LoadTitle()
    {
        if (this.title != null) return;
        this.title = transform.Find("Title").Find("Title").GetComponent<LocalizedText>();
        Debug.Log(transform.name + ": LoadItemType", gameObject);
    }

    private void LoadNote()
    {
        if (this.note != null) return;
        this.note = transform.Find("Note").GetComponent<LocalizedText>();
        Debug.Log(transform.name + ": LoadNote", gameObject);
    }

    private void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Content").GetComponent<LocalizedText>();
        Debug.Log(transform.name + ": LoadItemName", gameObject);
    }

    private void LoadBtnAccept()
    {
        if (this.btnAccept != null) return;
        this.btnAccept = transform.GetComponentInChildren<Button>();
        Debug.Log(transform.name + ": LoadBtnAccept", gameObject);
    }

    public void DoneCriteriaTask() { }

    public void Switch2NextTask() { }

    public void AcceptTask() => this.Close();
}
