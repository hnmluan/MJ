using UnityEngine;
using UnityEngine.EventSystems;

public class PresUIEquippedWeapon : PressUI
{
    [SerializeField] protected UIHotKeyWeapon uiHotKeyWeapon;

    public override void OnPointerClick(PointerEventData eventData) => Armory.Instance.FocusItem(uiHotKeyWeapon.Position);

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIHotKeyWeapon();
    }

    protected void LoadUIHotKeyWeapon()
    {
        if (this.uiHotKeyWeapon != null) return;
        this.uiHotKeyWeapon = GetComponentInParent<UIHotKeyWeapon>();
        Debug.Log(transform.name + ": LoadFocus", gameObject);
    }
}
