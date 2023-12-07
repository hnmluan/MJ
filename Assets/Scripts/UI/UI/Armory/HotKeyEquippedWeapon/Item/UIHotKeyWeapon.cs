using UnityEngine;
using UnityEngine.UI;

public class UIHotKeyWeapon : InitMonoBehaviour
{
    [SerializeField] protected ItemArmory weapon;
    public ItemArmory Weapon => weapon;

    [SerializeField] protected Text level;
    public Text Level => level;

    [SerializeField] protected Image image;
    public Image Image => image;

    [SerializeField] protected Image focus;
    public Image ImgFocus => focus;

    [SerializeField] protected Button btnEquip;
    public Button BtnEquip => btnEquip;

    [SerializeField] protected int position;
    public int Position => position;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadLevel();
        this.LoadImage();
        this.LoadFocus();
        this.LoadBtnEquip();
    }

    protected virtual void LoadFocus()
    {
        if (this.focus != null) return;
        this.focus = transform.Find("Focus").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadFocus", gameObject);
    }

    protected virtual void LoadImage()
    {
        if (this.image != null) return;
        this.image = transform.Find("Image").Find("Image").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadWeaponImage", gameObject);
    }

    protected virtual void LoadLevel()
    {
        if (this.level != null) return;
        this.level = transform.Find("Level").Find("Level").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadWeaponNumer", gameObject);
    }

    protected virtual void LoadBtnEquip()
    {
        if (this.btnEquip != null) return;
        this.btnEquip = transform.Find("BtnEquip").GetComponent<Button>();
        Debug.Log(transform.name + ": LoadBtnEquip", gameObject);
    }

    public virtual void Show(ItemArmory item)
    {
        if (item == null)
        {
            Clear();
            return;
        }

        this.weapon = item;
        this.image.sprite = item.weaponProfile.spriteInHand;
        this.level.text = "+ " + item.level.ToString();
        this.Focus(item.isFocus);
        this.SetEquipMode(false);
    }

    public virtual void Clear()
    {
        this.weapon = null;
        this.image.sprite = null;
        this.level.text = null;
        this.Focus(false);
        this.SetEquipMode(false);
    }

    public void Focus(bool isFocus) => this.focus.gameObject.SetActive(isFocus);

    public void SetEquipMode(bool isEquipMode) => this.btnEquip.gameObject.SetActive(isEquipMode);

    public void SetPosition(int postion) => this.position = postion;
}