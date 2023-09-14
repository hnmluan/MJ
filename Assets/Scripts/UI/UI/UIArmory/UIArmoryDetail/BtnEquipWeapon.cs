public class BtnEquipWeapon : BaseButton
{
    protected override void OnClick()
    {
        Weapon weapon = UIArmoryDetail.Instance.Weapon;
        Armory.Instance.firstWeapon = weapon;
        if (FirstWeaponUI.Instance.weapon == null)
        {
            FirstWeaponUI.Instance.SetFirstWeaponUI(weapon);
            return;
        }
        SecondWeaponUI.Instance.SetSecondWeaponUI(FirstWeaponUI.Instance.weapon);
        FirstWeaponUI.Instance.SetFirstWeaponUI(weapon);

    }
}
