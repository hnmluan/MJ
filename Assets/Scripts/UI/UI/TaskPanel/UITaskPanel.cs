using UnityEngine;

public class UITaskPanel : InitMonoBehaviour
{
    private static UITaskPanel instance;
    public static UITaskPanel Instance => instance;

    protected bool isOpen = true;

    protected override void Awake()
    {
        base.Awake();
        if (UITaskPanel.instance != null) Debug.LogError("Only 1 UITaskPanel allow to exist");
        UITaskPanel.instance = this;
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
