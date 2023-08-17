using UnityEngine;

public class UIArmoryDetailAbstract : InitMonoBehaviour
{
    [SerializeField] protected UIArmoryDetailCtrl uiArmoryDetailCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadUIArmoryDetailCtrl();
    }

    protected virtual void LoadUIArmoryDetailCtrl()
    {
        if (uiArmoryDetailCtrl != null) return;
        uiArmoryDetailCtrl = transform.GetComponent<UIArmoryDetailCtrl>();
        Debug.Log(transform.name + ": LoadUIArmoryDetailCtrl", gameObject);
    }
}
