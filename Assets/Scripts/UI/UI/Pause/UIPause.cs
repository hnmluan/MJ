using UnityEngine;

public class UIPause : InitMonoBehaviour
{
    private static UIPause instance;
    public static UIPause Instance => instance;

    protected bool isOpen = true;

    protected override void Awake()
    {
        base.Awake();
        if (UIPause.instance != null) Debug.LogError("Only 1 UIPause allow to exist");
        UIPause.instance = this;
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