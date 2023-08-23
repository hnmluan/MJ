using UnityEngine;

public class PlayerAbstract : InitMonoBehaviour
{
    [SerializeField] protected PlayerCtrl playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }
}
