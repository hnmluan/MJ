public class BtnUnequipWeapon : BaseButton
{
    protected override void OnClick() => Armory.Instance.UnequipItem(UIArmory.Instance.CurrentItem);
}
