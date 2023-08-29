using UnityEngine;
using UnityEngine.UI;

public class UIArmoryDetailCtrl : InitMonoBehaviour
{
    [Header("UI Armory Detail Ctrl")]

    [SerializeField] protected Image weaponImage;
    public Image WeaponImage => weaponImage;

    [SerializeField] protected Text weaponName;
    public Text WeaponName => weaponName;

    [SerializeField] protected Text weaponType;
    public Text WeaponType => weaponType;

    [SerializeField] protected Text weaponLevel;
    public Text WeaponLevel => weaponLevel;

    [SerializeField] protected Text weaponUpgrade;
    public Text WeaponUpgrade => weaponUpgrade;

    [SerializeField] protected Button btnUpgradeWeapon;
    public Button BtnUpgradeWeapon => btnUpgradeWeapon;

    [SerializeField] protected Button btnDecompose;
    public Button BtnDecompose => btnDecompose;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeaponType();
        this.LoadWeaponName();
        this.LoadWeaponLevel();
        this.LoadWeaponImage();
        this.LoadWeaponUpgrade();
        this.LoadBtnUpgradeWeapon();
        this.LoadBtnDecompose();
    }

    private void LoadBtnDecompose()
    {
        if (this.btnDecompose != null) return;
        this.btnDecompose = transform.Find("Buttons").Find("BtnDecompose").GetComponent<Button>();
        Debug.Log(transform.name + ": LoadWeaponType", gameObject);
    }

    private void LoadBtnUpgradeWeapon()
    {
        if (this.btnUpgradeWeapon != null) return;
        this.btnUpgradeWeapon = transform.Find("Buttons").Find("BtnUpgrade").GetComponent<Button>();
        Debug.Log(transform.name + ": LoadWeaponType", gameObject);
    }

    private void LoadWeaponType()
    {
        if (this.weaponType != null) return;
        this.weaponType = transform.Find("Information").Find("Grid").Find("WeaponType").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadWeaponType", gameObject);
    }

    private void LoadWeaponName()
    {
        if (this.weaponName != null) return;
        this.weaponName = transform.Find("Information").Find("Grid").Find("WeaponName").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadWeaponName", gameObject);
    }

    private void LoadWeaponUpgrade()
    {
        if (this.weaponUpgrade != null) return;
        this.weaponUpgrade = transform.Find("Upgrade").Find("Text").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadWeaponName", gameObject);
    }

    private void LoadWeaponLevel()
    {
        if (this.weaponLevel != null) return;
        this.weaponLevel = transform.Find("Information").Find("Grid").Find("WeaponLevel").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadWeaponName", gameObject);
    }

    private void LoadWeaponImage()
    {
        if (this.weaponImage != null) return;
        this.weaponImage = transform.Find("Image").Find("WeaponImage").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadWeaponImage", gameObject);
    }
}