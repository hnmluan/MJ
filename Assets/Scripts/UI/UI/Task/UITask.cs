using Assets.SimpleLocalization;
using UnityEngine;

public class UITask : UIBase
{
    private static UITask instance;
    public static UITask Instance => instance;


    [SerializeField] protected LocalizedText content;
    public LocalizedText Content => content;

    [SerializeField] protected LocalizedText title;
    public LocalizedText Title => title;

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

    public void ShowTask(string title, string content)
    {
        LocalizationManager.Localize(title);
        this.title.LocalizationKey = title;
        this.content.LocalizationKey = content;
        this.Open();
    }
}
