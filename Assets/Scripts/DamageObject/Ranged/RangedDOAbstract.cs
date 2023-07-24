using UnityEngine;

public abstract class RangedDOAbstract : InitMonoBehaviour
{
    [SerializeField] protected RangedDOCtrl rangedDOCtrl;
    public RangedDOCtrl RangedDOCtrl { get => rangedDOCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRangedDOCtrl();
    }

    protected virtual void LoadRangedDOCtrl()
    {
        if (this.rangedDOCtrl != null) return;
        this.rangedDOCtrl = transform.parent.GetComponent<RangedDOCtrl>();
        Debug.Log(transform.name + ": LoadRangedDOCtrl", gameObject);
    }
}
