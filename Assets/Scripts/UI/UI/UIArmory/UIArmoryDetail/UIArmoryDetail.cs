using Assets.SimpleLocalization;
using UnityEngine;

public class UIArmoryDetail : UIArmoryDetailAbstract
{
    [Header("UI Armory Detail")]

    private static UIArmoryDetail instance;
    public static UIArmoryDetail Instance => instance;

    [SerializeField] protected Weapon weapon = null;
    public Weapon Weapon => weapon;

    protected override void Awake()
    {
        base.Awake();
        if (UIArmoryDetail.instance != null) Debug.LogError("Only 1 UIArmory allow to exist");
        UIArmoryDetail.instance = this;
    }

    protected override void OnDisable() => this.SetEmptyUIArmoryDetail();

    public virtual void SetUIArmoryDetail(Weapon weapon)
    {
        this.weapon = weapon;

        uiArmoryDetailCtrl.WeaponImage.sprite = weapon.weaponProfile.spriteInHand;
        uiArmoryDetailCtrl.WeaponName.text = LocalizationManager.Localize(weapon.weaponProfile.keyName);
    }

    public virtual void SetEmptyUIArmoryDetail()
    {
        this.weapon = null;

        uiArmoryDetailCtrl.WeaponImage.sprite = null;
        uiArmoryDetailCtrl.WeaponDescription.text = null;
        uiArmoryDetailCtrl.WeaponName.text = null;
        uiArmoryDetailCtrl.WeaponQuantity.text = null;
        uiArmoryDetailCtrl.WeaponType.text = null;
    }
}
