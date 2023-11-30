using Assets.SimpleLocalization;
using UnityEngine;

public class BtnBuyItem : BaseButton
{
    [SerializeField] protected UIItemShop uiItemShop;

    protected override void LoadComponents() => this.LoadUIItemShop();

    private void LoadUIItemShop()
    {
        this.uiItemShop = transform.parent.GetComponent<UIItemShop>();
        Debug.Log(transform.name + ": LoadUIItemShop", gameObject);
    }

    protected override void OnEnable() => LoadUIItemShop();

    private void BuyItem()
    {
        ItemShop item = uiItemShop.ItemShop;
        Shop.Instance.BuyItem(item);
        UIShop.Instance.RefreshUI();
    }

    protected override void OnClick()
    {
        if (uiItemShop == null) return;
        ItemShop itemShop = uiItemShop.ItemShop;
        int price = itemShop.price;
        string nameCurrency = LocalizationManager.Localize(CurrencyDataSO.FindByName(itemShop.currencyCode).keyName);
        string content = nameCurrency + " - " + price;
        Sprite image = CurrencyDataSO.FindByName(itemShop.currencyCode).currencySprite;
        CurrencyCode currencyCode = CurrencyDataSO.FindByName(itemShop.currencyCode).currencyCode;

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

        string balanceNotEnough = LocalizationManager.Localize("Shop.BalanceNotEnough");
        UITextSpawner.Instance.SpawnUITextWithMousePosition(balanceNotEnough);
    }
}
