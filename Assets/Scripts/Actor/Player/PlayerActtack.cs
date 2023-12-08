public class PlayerActtack : ObjAttackByMouse
{
    protected override void Attacking()
    {
        this.damageObject = Armory.Instance.GetFocusEquippedWeapon().weapon.dataSO.damageObjectCode;
        base.Attacking();
    }
}
