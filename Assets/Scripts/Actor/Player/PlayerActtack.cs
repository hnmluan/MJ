public class PlayerActtack : ObjAttackByMouse
{
    protected override void Attacking()
    {
        this.damageObject = Armory.Instance.GetFocusEquippedWeapon().weaponProfile.damageObjectCode;
        base.Attacking();
    }
}
