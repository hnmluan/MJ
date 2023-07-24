using UnityEngine;

public class MeleeDOAbstract : InitMonoBehaviour
{
    [SerializeField] protected MeleeDOCtrl meleeDOCtrl;
    public MeleeDOCtrl MeleeDOCtrl { get => meleeDOCtrl; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMeleeDOCtrl();
    }

    protected virtual void LoadMeleeDOCtrl()
    {
        if (this.meleeDOCtrl != null) return;
        this.meleeDOCtrl = transform.parent.GetComponent<MeleeDOCtrl>();
        Debug.Log(transform.name + ": LoadMeleeDOCtrl", gameObject);
    }
}
