using UnityEngine;

public class BtnBuyItem : BaseButton
{
    [SerializeField] protected UIItemShop uiItemShop;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadUIItemShop();
    }

    private void LoadUIItemShop()
    {
        this.uiItemShop = transform.parent.GetComponent<UIItemShop>();
        Debug.Log(transform.name + ": LoadUIItemShop", gameObject);
    }

    protected override void OnEnable() => LoadUIItemShop();

    protected override void OnClick()
    {
        try
        {
            if (uiItemShop == null) return;

            switch (uiItemShop.ItemShop.itemPrice.currencyCode)
            {
                case CurrencyCode.Gold:
                    if (Wallet.Instance.DeductGoldenBalance(uiItemShop.ItemShop.itemPrice.price)) BuyItem();
                    break;
                case CurrencyCode.Silver:
                    if (Wallet.Instance.DeductSilverBalance(uiItemShop.ItemShop.itemPrice.price)) BuyItem();
                    break;
                default:
                    break;
            }
        }
        catch (System.Exception) { }

    }

    private void BuyItem()
    {
        PlayerCtrl.Instance.Inventory.AddItem(uiItemShop.ItemShop.itemProfile.itemCode, uiItemShop.ItemShop.quantity);
        uiItemShop.SoldOut.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
