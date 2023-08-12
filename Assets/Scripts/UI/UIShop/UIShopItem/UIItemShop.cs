using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public class UIItemShop : InitMonoBehaviour
{
    [SerializeField] protected bool isSoldOut;
    public bool IsSoldOut => isSoldOut;

    [SerializeField] protected ItemShop itemShop;
    public ItemShop ItemShop => itemShop;

    [SerializeField] protected Text itemName;
    public Text ItemName => itemName;

    [SerializeField] protected Text itemNumber;
    public Text ItemNumer => itemNumber;

    [SerializeField] protected Text soldOut;
    public Text SoldOut => soldOut;

    [SerializeField] protected Image itemImage;
    public Image ItemImage => itemImage;

    [SerializeField] protected Image currencyImage;
    public Image CurrencyImage => currencyImage;

    [SerializeField] protected Button buyButton;
    public Button BuyButton => buyButton;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemName();
        this.LoadItemNumer();
        this.LoadItemImage();
        this.LoadCurrencyImage();
        this.LoadItemBuy();
        this.LoadSoldOut();
    }

    private void LoadCurrencyImage()
    {
        if (this.currencyImage != null) return;
        this.currencyImage = transform.Find("Buy").Find("Currency").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadItemBuy", gameObject);
    }

    private void LoadItemBuy()
    {
        if (this.buyButton != null) return;
        this.buyButton = transform.Find("Buy").GetComponent<Button>();
        Debug.Log(transform.name + ": LoadItemBuy", gameObject);
    }

    private void LoadSoldOut()
    {
        if (this.soldOut != null) return;
        this.soldOut = transform.Find("Soldout").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadSoldOut", gameObject);
    }

    private void LoadItemImage()
    {
        if (this.itemImage != null) return;
        this.itemImage = transform.Find("Image").GetComponent<Image>();
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

    public virtual void ShowItem(ItemShop item)
    {
        this.itemShop = item;
        string name = "Item." + this.itemShop.itemProfile.itemName.Replace(" ", "");

        this.itemName.GetComponent<LocalizedText>().LocalizationKey = name;

        this.itemName.GetComponent<LocalizedText>().Localize();

        this.itemNumber.text = this.itemShop.quantity.ToString();

        this.itemImage.sprite = this.itemShop.itemProfile.itemSprite;

        this.buyButton.gameObject.SetActive(true);
        this.soldOut.gameObject.SetActive(false);
        this.isSoldOut = false;
        this.currencyImage.sprite = CurrencyProfileSO.FindByItemCode(this.itemShop.itemPrice.currencyCode).currencySprite;
    }
}