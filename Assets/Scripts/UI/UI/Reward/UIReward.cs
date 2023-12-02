using UnityEngine;

public class UIReward : InitMonoBehaviour
{
    private static UIReward instance;
    public static UIReward Instance => instance;

    protected bool isOpen = true;

    protected override void Awake()
    {
        base.Awake();
        if (UIReward.instance != null) Debug.LogError("Only 1 UIReward allow to exist");
        UIReward.instance = this;
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
