using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public class UIItemArmory : InitMonoBehaviour
{
    [Header("UI Weapon Armory")]
    [SerializeField] protected ItemArmory weapon;
    public ItemArmory Weapon => weapon;

    [SerializeField] protected Text weaponName;
    public Text WeaponName => weaponName;

    [SerializeField] protected Text weaponLevel;
    public Text WeaponNumer => weaponLevel;

    [SerializeField] protected Image weaponImage;
    public Image Image => weaponImage;

    [SerializeField] protected Image focus;
    public Image Focus => focus;

    [SerializeField] protected Transform upgradeIndicator;
    public Transform UpgradeIndicator => upgradeIndicator;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeaponName();
        this.LoadWeaponNumer();
        this.LoadWeaponImage();
        this.LoadFocus();
        this.LoadUpgradeIndicator();
    }

    protected virtual void LoadUpgradeIndicator()
    {
        if (this.upgradeIndicator != null) return;
        this.upgradeIndicator = transform.Find("UpgradeIndicator");
        Debug.Log(transform.name + ": LoadUpgradeIndicator", gameObject);
    }

    protected virtual void LoadFocus()
    {
        if (this.focus != null) return;
        this.focus = transform.Find("Focus").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadFocus", gameObject);
    }

    protected virtual void LoadWeaponImage()
    {
        if (this.weaponImage != null) return;
        this.weaponImage = transform.Find("Image").Find("Image").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadWeapontory", gameObject);
    }

    protected virtual void LoadWeaponName()
    {
        if (this.weaponName != null) return;
        this.weaponName = transform.Find("NameBox").Find("WeaponName").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadWeaponName", gameObject);
    }

    protected virtual void LoadWeaponNumer()
    {
        if (this.weaponLevel != null) return;
        this.weaponLevel = transform.Find("LevelBox").Find("Level").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadWeaponNumer", gameObject);
    }

    public virtual void ShowWeapon(ItemArmory weapon)
    {
        if (weapon == null) return;
        this.weapon = weapon;
        this.weaponName.text = LocalizationManager.Localize(weapon.weapon.dataSO.keyName);
        this.weaponImage.sprite = weapon.weapon.dataSO.spriteInHand;
        this.weaponLevel.text = "+ " + weapon.weapon.level.ToString();
        this.upgradeIndicator.gameObject.SetActive(weapon.CanUpgrade());
        this.focus.gameObject.SetActive(weapon == UIArmory.Instance.CurrentItem);
    }
}