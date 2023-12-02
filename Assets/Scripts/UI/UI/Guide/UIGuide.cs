using UnityEngine;

public class UIGuide : InitMonoBehaviour
{
    private static UIGuide instance;
    public static UIGuide Instance => instance;

    protected bool isOpen = true;

    protected override void Awake()
    {
        base.Awake();
        if (UIGuide.instance != null) Debug.LogError("Only 1 UIGuide allow to exist");
        UIGuide.instance = this;
    }

    protected override void Start() => this.Close();

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
        else this.Close();
    }

    public virtual void Open()
    {
        this.gameObject.SetActive(true);
        this.isOpen = true;
    }

    public virtual void Close()
    {
        this.gameObject.SetActive(false);
        this.isOpen = false;
    }
}