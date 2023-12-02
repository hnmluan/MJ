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

    [SerializeField] protected Transform canUpgrade;
    public Transform CanUpgrade => canUpgrade;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeaponName();
        this.LoadWeaponNumer();
        this.LoadWeaponImage();
        this.LoadFocus();
        this.LoadCanUpgrade();
    }

    private void LoadCanUpgrade()
    {
        if (this.canUpgrade != null) return;
        this.canUpgrade = transform.Find("CanUpgrade");
        Debug.Log(transform.name + ": LoadCanUpgrade", gameObject);
    }

    private void LoadFocus()
    {
        if (this.focus != null) return;
        this.focus = transform.Find("Focus").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadFocus", gameObject);
    }

    private void LoadWeaponImage()
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
        this.weaponName.text = LocalizationManager.Localize(weapon.weaponProfile.keyName);
        this.weaponImage.sprite = weapon.weaponProfile.spriteInHand;
        this.weaponLevel.text = "+ " + weapon.level.ToString();

        if (weapon.CanUpgrade())
        {
            canUpgrade.gameObject.SetActive(true);
            return;
        }
        canUpgrade.gameObject.SetActive(false);
    }
}