using UnityEngine;

public class UIInvDetailAbstract : InitMonoBehaviour
{
    [SerializeField] protected UIInvDetailCtrl uiInvDetailCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadUIInvDetailCtrl();
    }

    protected virtual void LoadUIInvDetailCtrl()
    {
        if (uiInvDetailCtrl != null) return;
        uiInvDetailCtrl = transform.GetComponent<UIInvDetailCtrl>();
        Debug.Log(transform.name + ": LoadUIInvDetailCtrl", gameObject);
    }
}
