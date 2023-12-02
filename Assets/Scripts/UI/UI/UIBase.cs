public class UIBase : InitMonoBehaviour
{
    protected bool isOpen = true;

    protected override void Start() => this.Close();

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open(); else this.Close();
    }

    protected override void OnEnable() => this.isOpen = true;

    protected override void OnDisable() => this.isOpen = false;

    public virtual void Open() => this.gameObject.SetActive(true);

    public virtual void Close() => this.gameObject.SetActive(false);
}
