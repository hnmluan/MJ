public class PlayerActtack : ObjAttackByMouse
{
    protected override void Attacking()
    {
        if (Armory.Instance.GetFocusEquippedWeapon() == null) return;
        this.damageObject = Armory.Instance.GetFocusEquippedWeapon().weapon.dataSO.damageObjectCode;
        base.Attacking();
    }
}
