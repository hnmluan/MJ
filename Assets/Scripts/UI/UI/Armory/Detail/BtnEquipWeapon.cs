public class BtnEquipWeapon : BaseButton
{
    protected override void OnClick() => Armory.Instance.EquipItem(UIArmory.Instance.CurrentItem, 1);
}
    