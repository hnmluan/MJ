using UnityEngine;

public class UIInvDetailAbstract : InitMonoBehaviour
{
    [SerializeField] protected UIInvDetailCtrl uiCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadUIInvDetailCtrl();
    }

    protected virtual void LoadUIInvDetailCtrl()
    {
        if (uiCtrl != null) return;
        uiCtrl = transform.GetComponent<UIInvDetailCtrl>();
        Debug.Log(transform.name + ": LoadUIInvDetailCtrl", gameObject);
    }
}
