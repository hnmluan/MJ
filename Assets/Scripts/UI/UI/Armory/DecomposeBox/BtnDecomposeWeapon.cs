public class BtnDecomposeWeapon : BaseButton
{
    protected override void OnClick() => Armory.Instance.DecomposeItem(UIArmory.Instance.CurrentItem);
}
