public class BtnCloseArmory : BaseButton
{
    protected override void OnClick()
    {
        HotKeyEquippedWeapon.Instance.SetEquipMode(false);
        UIArmory.Instance.Close();
    }
}