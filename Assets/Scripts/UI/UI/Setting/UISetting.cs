using UnityEngine;

public class UISetting : InitMonoBehaviour
{
    private static UISetting instance;
    public static UISetting Instance => instance;

    protected bool isOpen = true;

    protected override void Awake()
    {
        base.Awake();
        if (UISetting.instance != null) Debug.LogError("Only 1 UISetting allow to exist");
        UISetting.instance = this;
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