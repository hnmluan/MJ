public abstract class BaseUI : InitMonoBehaviour
{
    protected override void Start()
    {
        base.Start();
        this.Close();
    }

    public virtual void Open()
    {
        gameObject.SetActive(true);
        UICtrl.Instance.IsOpen = true;
        UICtrl.Instance.OpenSetting();
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
        UICtrl.Instance.IsOpen = false;
        UICtrl.Instance.CloseSetting();
    }

    public virtual void Toggle()
    {
        if (UICtrl.Instance.IsOpen) return;
        UICtrl.Instance.IsOpen = !UICtrl.Instance.IsOpen;
        this.Open();
    }
}
