using Assets.SimpleLocalization;

public class BtnUpgradeWeapon : BaseButton
{
    protected override void OnClick()
    {
        ItemArmory weapon = UIArmoryDetail.Instance.Weapon;
        bool isSuccess = weapon.Upgrade();
        UIArmoryDetail.Instance.SetUIArmoryDetail(weapon);
        UIArmory.Instance.ShowItems();
        if (isSuccess)
        {
            UITextSpawner.Instance.SpawnUITextWithMousePosition(LocalizationManager.Localize("Armory.Upgrade.Success"));
            return;
        }
        UITextSpawner.Instance.SpawnUITextWithMousePosition(LocalizationManager.Localize("Armory.Upgrade.Check"));

    }
}
