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
        if (uiItemShop != null) return;
        this.uiItemShop = transform.parent.GetComponent<UIItemShop>();
        Debug.Log(transform.name + ": LoadUIItemShop", gameObject);
    }

    protected override void OnClick() => Shop.Instance.BuyItem(uiItemShop.ItemShop);
    /*    {
            if (uiItemShop == null) return;
            ItemShop itemShop = uiItemShop.ItemShop;
            int price = itemShop.price;
            string nameCurrency = LocalizationManager.Localize(CurrencyDataSO.FindByName(itemShop.currencyCode).keyName);
            string content = nameCurrency + " - " + price;
            Sprite image = CurrencyDataSO.FindByName(itemShop.currencyCode).currencySprite;
            CurrencyCode currencyCode = CurrencyDataSO.FindByName(itemShop.currencyCode).currencyCode;

            if (currencyCode == CurrencyCode.Gold)
            {
                if (Wallet.Instance.DeductGold(price))
                {
                    UITextSpawner.Instance.SpawnUIImageTextWithMousePosition(content, image);
                    BuyItem();
                    return;
                }
            }

            if (currencyCode == CurrencyCode.Silver)
            {
                if (Wallet.Instance.DeductSilver(price))
                {
                    UITextSpawner.Instance.SpawnUIImageTextWithMousePosition(content, image);
                    BuyItem();
                    return;
                };
            }

            string balanceNotEnough = LocalizationManager.Localize("Shop.BalanceNotEnough");
            UITextSpawner.Instance.SpawnUITextWithMousePosition(balanceNotEnough);
        }*/
}
