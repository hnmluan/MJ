using UnityEngine;

public class BtnEquipWeapon : BaseButton
{
    [SerializeField] protected UIHotKeyWeapon uiWeapon;
    public UIHotKeyWeapon Weapon => uiWeapon;

    protected override void OnClick() => Armory.Instance.EquipItem(UIArmory.Instance.CurrentItem, uiWeapon.Position);

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIEquippedWeapon();
    }

    protected virtual void LoadUIEquippedWeapon()
    {
        if (this.uiWeapon != null) return;
        this.uiWeapon = GetComponentInParent<UIHotKeyWeapon>();
        Debug.Log(transform.name + ": LoadUIEquippedWeapon", gameObject);
    }
}
