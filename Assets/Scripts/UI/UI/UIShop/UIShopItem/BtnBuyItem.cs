using Assets.SimpleLocalization;
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

            ItemShop itemShop = uiItemShop.ItemShop;

            int price = itemShop.price;

            string nameCurrency = LocalizationManager.Localize(itemShop.itemPrice.currencyProfileSO.keyName);

            string balanceNotEnough = LocalizationManager.Localize("Shop.BalanceNotEnough");

            string content = nameCurrency + " -" + price;

            Sprite image = itemShop.itemPrice.currencyProfileSO.currencySprite;

            CurrencyCode currencyCode = uiItemShop.ItemShop.itemPrice.currencyProfileSO.currencyCode;

            if (currencyCode == CurrencyCode.Gold)
            {
                if (Wallet.Instance.DeductGoldenBalance(price))
                {
                    UITextSpawner.Instance.SpawnUIImageTextWithMousePosition(content, image);
                    BuyItem();
                    return;
                }
            }

            if (currencyCode == CurrencyCode.Silver)
            {
                if (Wallet.Instance.DeductSilverBalance(price))
                {
                    UITextSpawner.Instance.SpawnUIImageTextWithMousePosition(content, image);
                    BuyItem();
                    return;
                };
            }
            UITextSpawner.Instance.SpawnUITextWithMousePosition(balanceNotEnough);
        }
        catch (System.Exception) { }

    }

    private void BuyItem()
    {
        Inventory.Instance.AddItem(uiItemShop.ItemShop.itemProfile.itemCode, uiItemShop.ItemShop.quantity);
        uiItemShop.SoldOut.gameObject.SetActive(true);
        this.gameObject.SetActive(false);
    }
}
