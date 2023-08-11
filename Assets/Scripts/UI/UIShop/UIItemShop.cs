using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public class UIItemShop : InitMonoBehaviour
{
    [Header("UI Item Shop")]
    [SerializeField] protected ItemInventory itemShop;
    public ItemInventory ItemShop => itemShop;

    [SerializeField] protected Text itemName;
    public Text ItemName => itemName;

    [SerializeField] protected Text itemNumber;
    public Text ItemNumer => itemNumber;

    [SerializeField] protected Image itemImage;
    public Image Image => itemImage;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemNumer();
        this.LoadItemImage();
    }

    private void LoadItemImage()
    {
        if (this.itemImage != null) return;
        this.itemImage = transform.Find("Image").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadItemImage", gameObject);
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
        this.itemShop = item;
        string name = "Item." + this.itemShop.itemProfile.itemName.Replace(" ", "");
        this.itemName.GetComponent<LocalizedText>().LocalizationKey = name;
        this.itemName.GetComponent<LocalizedText>().Localize();
        this.itemNumber.text = this.itemShop.itemCount.ToString();
        this.itemImage.sprite = this.itemShop.itemProfile.itemSprite;
    }
}