using UnityEngine;
using UnityEngine.UI;

public class UIArmoryDetailCtrl : InitMonoBehaviour
{
    [Header("UI Armory Detail Ctrl")]

    [SerializeField] protected Image image;
    public Image Image => image;

    [SerializeField] protected Text name;
    public Text Name => name;

    [SerializeField] protected Text type;
    public Text Type => type;

    [SerializeField] protected Text level;
    public Text Level => level;

    [SerializeField] protected Text upgradeTxt;
    public Text UpgradeTxt => upgradeTxt;

    [SerializeField] protected Button btnUpgrade;
    public Button BtnUpgrade => btnUpgrade;

    [SerializeField] protected Button btnDecompose;
    public Button BtnDecompose => btnDecompose;

    [SerializeField] protected Button btnEquip;
    public Button BtnEquip => btnEquip;

    [SerializeField] protected Button btnUnequip;
    public Button BtnUnequip => btnUnequip;

    [SerializeField] protected Text slotEquippedWeaponTxt;
    public Text SlotEquippedWeaponTxt => slotEquippedWeaponTxt;

    [SerializeField] protected Transform slotEquippedWeaponBox;
    public Transform SlotEquippedWeaponBox => slotEquippedWeaponBox;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeaponType();
        this.LoadName();
        this.LoadLevel();
        this.LoadImage();
        this.LoadUpgradeTxt();
        this.LoadBtnUpgrade();
        this.LoadBtnDecompose();
        this.LoadSlotEquippedWeaponTxt();
        this.LoadSlotEquippedWeaponBox();
        this.LoadBtnEquip();
        this.LoadBtnUnequip();
    }

    private void LoadBtnDecompose()
    {
        if (this.btnDecompose != null) return;
        this.btnDecompose = transform.Find("Buttons").Find("BtnDecompose").GetComponent<Button>();
        Debug.Log(transform.name + ": LoadWeaponType", gameObject);
    }

    private void LoadBtnUpgrade()
    {
        if (this.btnUpgrade != null) return;
        this.btnUpgrade = transform.Find("Buttons").Find("BtnUpgrade").GetComponent<Button>();
        Debug.Log(transform.name + ": LoadWeaponType", gameObject);
    }

    private void LoadBtnEquip()
    {
        if (this.btnEquip != null) return;
        this.btnEquip = transform.Find("Buttons").Find("BtnEquip").GetComponent<Button>();
        Debug.Log(transform.name + ": LoadBtnEquip", gameObject);
    }

    private void LoadBtnUnequip()
    {
        if (this.btnUnequip != null) return;
        this.btnUnequip = transform.Find("Buttons").Find("BtnUnequip").GetComponent<Button>();
        Debug.Log(transform.name + ": LoadBtnUnequip", gameObject);
    }

    private void LoadWeaponType()
    {
        if (this.type != null) return;
        this.type = transform.Find("Information").Find("Grid").Find("WeaponType").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadWeaponType", gameObject);
    }

    private void LoadName()
    {
        if (this.name != null) return;
        this.name = transform.Find("Information").Find("Grid").Find("WeaponName").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadWeaponName", gameObject);
    }

    private void LoadUpgradeTxt()
    {
        if (this.upgradeTxt != null) return;
        this.upgradeTxt = transform.Find("RecipeUpgrade").Find("Text").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadWeaponName", gameObject);
    }

    private void LoadLevel()
    {
        if (this.level != null) return;
        this.level = transform.Find("Information").Find("Grid").Find("WeaponLevel").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadWeaponName", gameObject);
    }

    private void LoadImage()
    {
        if (this.image != null) return;
        this.image = transform.Find("Image").Find("WeaponImage").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadWeaponImage", gameObject);
    }

    private void LoadSlotEquippedWeaponTxt()
    {
        if (this.slotEquippedWeaponTxt != null) return;
        this.slotEquippedWeaponTxt = transform.Find("EquipSlot").Find("Slot").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadSlotEquippedWeaponTxt", gameObject);
    }

    private void LoadSlotEquippedWeaponBox()
    {
        if (this.slotEquippedWeaponBox != null) return;
        this.slotEquippedWeaponBox = transform.Find("EquipSlot");
        Debug.Log(transform.name + ": LoadSlotEquippedWeaponBox", gameObject);
    }
}
