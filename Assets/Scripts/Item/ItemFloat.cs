using UnityEngine;

public class ItemFloat : ObjFloat
{
    [Header("Item Abstract")]
    [SerializeField] protected ItemCtrl itemCtrl;
    public ItemCtrl ItemCtrl => itemCtrl;

    protected override void LoadComponents()
    {
        this.LoadItemCtrl();
        base.LoadComponents();
    }

    protected virtual void LoadItemCtrl()
    {
        if (this.itemCtrl != null) return;
        this.itemCtrl = transform.parent.GetComponent<ItemCtrl>();
        Debug.Log(transform.name + ": LoadItemCtrl", gameObject);
    }

    protected override void SetObj() => obj = itemCtrl.ItemSR.transform;
}
