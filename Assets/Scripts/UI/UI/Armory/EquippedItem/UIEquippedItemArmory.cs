using UnityEngine;
using UnityEngine.UI;

public class UIEquippedItemArmory : InitMonoBehaviour, IObservationArmory
{
    [SerializeField] protected ItemArmory weapon = null;
    public ItemArmory Weapon => weapon;

    [SerializeField] protected int position;

    [SerializeField] protected Text weaponLevel;
    public Text WeaponNumer => weaponLevel;

    [SerializeField] protected Image weaponImage;
    public Image Image => weaponImage;

    [SerializeField] protected Image focus;
    public Image ImgFocus => focus;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeaponNumer();
        this.LoadWeaponImage();
        this.LoadFocus();
    }
    protected override void Awake()
    {
        base.Awake();
        Armory.Instance.AddObservation(this);
    }

    protected override void Start()
    {
        base.Start();
        this.Clear();
        this.ResetUI();
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


    protected virtual void LoadWeaponNumer()
    {
        if (this.weaponLevel != null) return;
        this.weaponLevel = transform.Find("LevelBox").Find("Level").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadWeaponNumer", gameObject);
    }


    public virtual void ResetUI()
    {
        if (position == 1) this.Show(Armory.Instance.EquippedWeapon1);
        if (position == 2) this.Show(Armory.Instance.EquippedWeapon2);
        if (position == 3) this.Show(Armory.Instance.EquippedWeapon3);
    }

    public virtual void Show(ItemArmory weapon)
    {
        if (weapon == null)
        {
            this.weapon = null;
            this.weaponImage.sprite = null;
            this.weaponLevel.text = null;
            return;
        }

        this.weapon = weapon;
        this.weaponImage.sprite = weapon.weaponProfile.spriteInHand;
        this.weaponLevel.text = "+ " + weapon.level.ToString();
    }

    public virtual void Clear()
    {
        this.weapon = null;
        this.weaponImage.sprite = null;
        this.weaponLevel.text = null;
    }

    public void Focus(bool isFocus) => this.focus.gameObject.SetActive(isFocus);

    public void AddItem() => this.ResetUI();

    public void DeductItem() => this.ResetUI();

    public void UpgradeItem(bool isUpgradeSuccessful) => this.ResetUI();

    public void DecomposeItem() => this.ResetUI();

    public void EquipItem(ItemArmory item, int position) => this.ResetUI();
}