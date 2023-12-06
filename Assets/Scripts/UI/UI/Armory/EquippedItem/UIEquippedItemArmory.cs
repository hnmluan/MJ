using UnityEngine;
using UnityEngine.UI;

public class UIEquippedItemArmory : InitMonoBehaviour, IObservationArmory
{
    [SerializeField] protected ItemArmory weapon;
    public ItemArmory Weapon => weapon;

    [SerializeField] protected int position;

    [SerializeField] protected Text weaponLevel;
    public Text WeaponNumer => weaponLevel;

    [SerializeField] protected Image weaponImage;
    public Image Image => weaponImage;

    [SerializeField] protected Image focus;
    public Image ImgFocus => focus;

    protected override void Awake()
    {
        base.Awake();
        this.Show(Armory.Instance.GetEquippedWeapon(position));
        Armory.Instance.AddObservation(this);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeaponNumer();
        this.LoadWeaponImage();
        this.LoadFocus();
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

    public virtual void Show(ItemArmory weapon)
    {
        if (weapon == null)
        {
            Clear();
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

    public void AddItem() { }

    public void DeductItem() => Show(Armory.Instance.GetEquippedWeapon(this.position));

    public void UpgradeItem(bool isUpgradeSuccessful) => Show(Armory.Instance.GetEquippedWeapon(this.position));

    public void DecomposeItem() => Show(Armory.Instance.GetEquippedWeapon(this.position));

    public void EquipItem(ItemArmory item, int position) => Show(Armory.Instance.GetEquippedWeapon(this.position));
}