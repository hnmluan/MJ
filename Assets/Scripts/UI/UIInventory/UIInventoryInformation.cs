using UnityEngine;
using UnityEngine.UI;

public class UIInventoryInformation : InitMonoBehaviour
{
    [Header("UI Inventory Information")]

    private static UIInventoryInformation instance;
    public static UIInventoryInformation Instance => instance;

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    [SerializeField] protected Text itemName;
    public Text ItemName => itemName;

    [SerializeField] protected Text itemNumber;
    public Text ItemNumer => itemNumber;

    [SerializeField] protected Text itemType;
    public Text ItemType => itemType;

    [SerializeField] protected Image itemImage;
    public Image Image => itemImage;

    protected override void Awake()
    {
        base.Awake();
        if (UIInventoryInformation.instance != null) Debug.LogError("Only 1 UIInventory allow to exist");
        UIInventoryInformation.instance = this;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemNumer();
        this.LoadItemImage();
        this.LoadItemType();
    }
    private void LoadItemImage()
    {
        if (this.itemImage != null) return;
        this.itemImage = transform.Find("Image").Find("ImageItem").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadItemImage", gameObject);
    }

    protected virtual void LoadItemName()
    {
        if (this.itemName != null) return;
        this.itemName = transform.Find("Information").Find("Name").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemName", gameObject);
    }

    protected virtual void LoadItemNumer()
    {
        if (this.itemNumber != null) return;
        this.itemNumber = transform.Find("Information").Find("Quantity").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemNumer", gameObject);
    }

    protected virtual void LoadItemType()
    {
        if (this.itemType != null) return;
        this.itemType = transform.Find("Information").Find("Type").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemType", gameObject);
    }

    public virtual void ShowInfor(ItemInventory item)
    {
        this.itemInventory = item;
        this.itemName.text = "Name: " + this.itemInventory.itemProfile.itemName;
        this.itemNumber.text = "Quantity: " + this.itemInventory.itemCount.ToString();
        this.itemImage.sprite = this.itemInventory.itemProfile.itemSprite;
        this.itemType.text = "Type: " + this.itemInventory.itemProfile.itemType.ToString();

    }
}
