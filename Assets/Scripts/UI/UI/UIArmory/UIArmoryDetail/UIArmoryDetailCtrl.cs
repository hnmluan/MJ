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

    [SerializeField] protected Text weaponDescription;
    public Text WeaponDescription => weaponDescription;

    [SerializeField] protected Text weaponQuantity;
    public Text WeaponQuantity => weaponQuantity;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeaponType();
        this.LoadWeaponName();
        this.LoadWeaponQuantity();
        this.LoadWeaponImage();
        this.LoadWeaponDiscription();
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

    private void LoadWeaponQuantity()
    {
        if (this.weaponQuantity != null) return;
        this.weaponQuantity = transform.Find("Information").Find("Grid").Find("WeaponQuantity").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadWeaponName", gameObject);
    }

    private void LoadWeaponDiscription()
    {
        if (this.weaponDescription != null) return;
        this.weaponDescription = transform.Find("Information").
            Find("Scroll View").
            Find("Viewport").
            Find("Content").
            Find("Description").
            GetComponent<Text>();
        Debug.Log(transform.name + ": LoadWeaponDiscription", gameObject);
    }

    private void LoadWeaponImage()
    {
        if (this.weaponImage != null) return;
        this.weaponImage = transform.Find("Image").Find("WeaponImage").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadWeaponImage", gameObject);
    }
}
