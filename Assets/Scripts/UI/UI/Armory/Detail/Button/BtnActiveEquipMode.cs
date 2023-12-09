public class BtnActiveEquipMode : BaseButton
{
    protected override void OnClick() => HotKeyEquippedWeapon.Instance.SetEquipMode(true);
}
