using UnityEngine;

public class UIGuide : InitMonoBehaviour
{
    [Header("UI Guide")]
    private static UIGuide instance;
    public static UIGuide Instance => instance;

    protected bool isOpen = true;

    protected override void Awake()
    {
        base.Awake();
        if (UIGuide.instance != null) Debug.LogError("Only 1 UIGuide allow to exist");
        UIGuide.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        this.Close();
    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
        else this.Close();
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
        this.isOpen = true;
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
        this.isOpen = false;
    }
}