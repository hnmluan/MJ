using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public class UIInventoryIn4 : InitMonoBehaviour
{
    [Header("UI Inventory Information")]

    private static UIInventoryIn4 instance;
    public static UIInventoryIn4 Instance => instance;

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
        if (UIInventoryIn4.instance != null) Debug.LogError("Only 1 UIInventory allow to exist");
        UIInventoryIn4.instance = this;
    }

    protected override void OnDisable() => this.ResetIn4();

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
        this.itemName = transform.Find("Information").Find("NameItem").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemName", gameObject);
    }

    protected virtual void LoadItemNumer()
    {
        if (this.itemNumber != null) return;
        this.itemNumber = transform.Find("Information").Find("QuantityItem").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemNumer", gameObject);
    }

    protected virtual void LoadItemType()
    {
        if (this.itemType != null) return;
        this.itemType = transform.Find("Information").Find("TypeItem").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemType", gameObject);
    }

    public virtual void ShowIn4(ItemInventory item)
    {
        this.itemInventory = item;
        this.itemName.GetComponent<LocalizedText>().LocalizationKey = "Item." + this.itemInventory.itemProfile.itemName.Replace(" ", "");
        this.itemName.GetComponent<LocalizedText>().Localize();
        this.itemType.GetComponent<LocalizedText>().LocalizationKey = "Item.Type." + this.itemInventory.itemProfile.itemType.ToString().Replace(" ", "");
        this.itemType.GetComponent<LocalizedText>().Localize();
        this.itemNumber.text = this.itemInventory.itemCount.ToString();
        this.itemImage.sprite = this.itemInventory.itemProfile.itemSprite;

    }

    public virtual void ResetIn4()
    {
        this.itemInventory = new ItemInventory();
        this.itemName.GetComponent<LocalizedText>().LocalizationKey = "";
        this.itemName.GetComponent<LocalizedText>().Localize();
        this.itemType.GetComponent<LocalizedText>().LocalizationKey = "";
        this.itemType.GetComponent<LocalizedText>().Localize();
        this.itemNumber.text = "";
        this.itemImage.sprite = null;
    }
}
