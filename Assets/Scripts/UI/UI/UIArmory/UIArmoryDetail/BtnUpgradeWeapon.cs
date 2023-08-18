public class BtnUpgradeWeapon : BaseButton
{
    protected override void OnClick()
    {
        Weapon weapon = UIArmoryDetail.Instance.Weapon;
        weapon.Upgrade();
        UIArmoryDetail.Instance.SetUIArmoryDetail(weapon);
        UIArmory.Instance.ShowWeapons();
    }
}
