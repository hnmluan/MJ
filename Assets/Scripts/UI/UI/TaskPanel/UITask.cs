using Assets.SimpleLocalization;
using UnityEngine;

public class UITask : UIBase
{
    private static UITask instance;
    public static UITask Instance => instance;

    protected override void Awake()
    {
        base.Awake();
        if (UITask.instance != null) Debug.LogError("Only 1 UITask allow to exist");
        UITask.instance = this;
    }

    [SerializeField] protected LocalizedText taskContent;
    public LocalizedText ItemName => taskContent;

    [SerializeField] protected LocalizedText taskTitle;
    public LocalizedText ItemType => taskTitle;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTitle();
        this.LoadContent();
    }

    private void LoadTitle()
    {
        if (this.taskTitle != null) return;
        this.taskTitle = transform.Find("Title").Find("Title").GetComponent<LocalizedText>();
        Debug.Log(transform.name + ": LoadItemType", gameObject);
    }

    private void LoadContent()
    {
        if (this.taskContent != null) return;
        this.taskContent = transform.Find("Content").GetComponent<LocalizedText>();
        Debug.Log(transform.name + ": LoadItemName", gameObject);
    }

    public void ShowTask(string title, string content)
    {
        LocalizationManager.Localize(title);
        this.taskTitle.LocalizationKey = title;
        this.taskContent.LocalizationKey = content;
        this.Open();
    }
}
