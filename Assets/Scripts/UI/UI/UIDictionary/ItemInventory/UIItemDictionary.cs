using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public class UIItemDictionary : InitMonoBehaviour
{
    [Header("UI Item Dictionary")]
    [SerializeField] protected ItemDictionary itemDictionary;
    public ItemDictionary ItemDictionary => itemDictionary;

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
        Debug.Log(transform.name + ": LoadItemDictionarytory", gameObject);
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

    public virtual void ShowItem(ItemDictionary item)
    {
        this.itemDictionary = item;
        string name = "Item." + this.itemDictionary.itemProfile.itemName.Replace(" ", "");
        this.itemName.GetComponent<LocalizedText>().LocalizationKey = name;
        this.itemName.GetComponent<LocalizedText>().Localize();
        this.itemNumber.text = this.itemDictionary.itemCount.ToString();
        this.itemImage.sprite = this.itemDictionary.itemProfile.itemSprite;
    }
}