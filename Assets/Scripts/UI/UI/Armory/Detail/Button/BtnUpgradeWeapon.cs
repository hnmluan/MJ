public class BtnUpgradeWeapon : BaseButton
{
    protected override void OnClick() => Armory.Instance.UpgradeItem(UIArmory.Instance.CurrentItem);
}
