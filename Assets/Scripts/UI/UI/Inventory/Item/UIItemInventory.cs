using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public class UIItemInventory : InitMonoBehaviour
{
    [Header("UI Item Inventory")]
    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    [SerializeField] protected Text itemName;
    public Text ItemName => itemName;

    [SerializeField] protected Text itemNumber;
    public Text ItemNumer => itemNumber;

    [SerializeField] protected Image itemImage;
    public Image Image => itemImage;

    [SerializeField] protected Image focus;
    public Image Focus => focus;

    protected override void OnDisable() => focus.gameObject.SetActive(false);

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemNumer();
        this.LoadItemImage();
        this.LoadFocus();
    }

    private void LoadFocus()
    {
        if (this.focus != null) return;
        this.focus = transform.Find("Focus").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadFocus", gameObject);
    }

    private void LoadItemImage()
    {
        if (this.itemImage != null) return;
        this.itemImage = transform.Find("Image").Find("Image").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadItemInvtory", gameObject);
    }

    protected virtual void LoadItemName()
    {
        if (this.itemName != null) return;
        this.itemName = transform.Find("NameBox").Find("ItemName").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemName", gameObject);
    }

    protected virtual void LoadItemNumer()
    {
        if (this.itemNumber != null) return;
        this.itemNumber = transform.Find("QuantityBox").Find("Quantity").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemNumer", gameObject);
    }

    public virtual void ShowItem(ItemInventory item)
    {
        this.itemInventory = item;
        this.itemName.text = LocalizationManager.Localize(item.itemProfile.keyName);
        this.itemNumber.text = this.itemInventory.itemCount.ToString();
        this.itemImage.sprite = this.itemInventory.itemProfile.itemSprite;
    }

    public virtual void Press()
    {
        if (itemInventory == null) return;
        UIInventory.Instance.UIInvDetail.SetUIInvDetail(itemInventory);
        UIInventory.Instance.ClearAllFocus();
        focus.gameObject.SetActive(true);
    }

    public void ClearFocus() => focus.gameObject.SetActive(false);
}