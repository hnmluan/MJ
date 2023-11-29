using Assets.SimpleLocalization;
using UnityEngine;
using UnityEngine.UI;

public class UIItemShop : InitMonoBehaviour
{
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
        this.LoadItemNumber();
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
        this.itemImage = transform.Find("ImageBox").Find("ObjImage").GetComponent<Image>();
        Debug.Log(transform.name + ": LoadItemImage", gameObject);
    }

    protected virtual void LoadItemName()
    {
        if (this.itemName != null) return;
        this.itemName = transform.Find("NameBox").Find("ItemName").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemName", gameObject);
    }

    protected virtual void LoadItemNumber()
    {
        if (this.itemNumber != null) return;
        this.itemNumber = transform.Find("QuantityBox").Find("Quantity").GetComponent<Text>();
        Debug.Log(transform.name + ": LoadItemNumer", gameObject);
    }

    public virtual void ShowItem(ItemShop item)
    {
        this.itemShop = item;

        ItemDataSO itemData = ItemDataSO.FindByName(item.itemCode);

        this.itemName.text = LocalizationManager.Localize(itemData.keyName);

        this.itemNumber.text = this.itemShop.quantity.ToString();

        this.itemImage.sprite = itemData.itemSprite;

        this.currencyImage.sprite = CurrencyDataSO.FindByName(item.currencyCode).currencySprite;

        if (item.isBuy)
        {
            this.soldOut.gameObject.SetActive(true);
            this.buyButton.gameObject.SetActive(false);
        }
        else
        {
            this.soldOut.gameObject.SetActive(false);
            this.buyButton.gameObject.SetActive(true);
        }
    }
}