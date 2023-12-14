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

    protected override void Awake()
    {
        base.Awake();
        if (UITask.instance != null) Debug.LogError("Only 1 UITask allow to exist");
        UITask.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTitle();
        this.LoadContent();
        this.LoadBtnAccept();
    }

    private void LoadTitle()
    {
        if (this.title != null) return;
        this.title = transform.Find("Title").Find("Title").GetComponent<LocalizedText>();
        Debug.Log(transform.name + ": LoadItemType", gameObject);
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

    public void ShowTask(string title, string content)
    {
        LocalizationManager.Localize(title);
        this.title.LocalizationKey = title;
        this.content.LocalizationKey = content;
        this.btnAccept.gameObject.SetActive(Task.Instance.currentTask.status == TaskStatus.start);
        this.Open();
    }

    public void DoneTask()
    {
    }

    public void Switch2NextTask()
    {
    }

    public void AcceptTask() => this.Close();
}
