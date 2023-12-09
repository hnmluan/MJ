public class PlayerActtack : ObjAttackByMouse
{
    private void Update()
    {
        if (InputManager.Instance.FocusFirstWeapon()) Armory.Instance.FocusItem(1);
        if (InputManager.Instance.FocusSecondWeapon()) Armory.Instance.FocusItem(2);
        if (InputManager.Instance.FocusThirdWeapon()) Armory.Instance.FocusItem(3);
    }

    protected override void Attacking()
    {
        if (Armory.Instance.GetFocusEquippedWeapon() == null) return;
        this.damageObject = Armory.Instance.GetFocusEquippedWeapon().weapon.dataSO.damageObjectCode;
        base.Attacking();
    }
}
