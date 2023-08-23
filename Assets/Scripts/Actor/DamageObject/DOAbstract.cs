using UnityEngine;

public class DOAbstract : InitMonoBehaviour
{
    [SerializeField] protected DOCtrl damageObjectCtrl;
    public DOCtrl DamageObjectCtrl { get => damageObjectCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageObjectCtrl();
    }

    protected virtual void LoadDamageObjectCtrl()
    {
        if (this.damageObjectCtrl != null) return;
        this.damageObjectCtrl = transform.parent.GetComponent<DOCtrl>();
        Debug.Log(transform.name + ": LoadDamageObjectCtrl", gameObject);
    }
}
