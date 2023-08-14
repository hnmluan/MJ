using UnityEngine;

public class UIPause : InitMonoBehaviour
{
    [Header("UI Pause")]
    private static UIPause instance;
    public static UIPause Instance => instance;

    protected bool isOpen = true;

    protected override void Awake()
    {
        base.Awake();
        if (UIPause.instance != null) Debug.LogError("Only 1 UIPause allow to exist");
        UIPause.instance = this;
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