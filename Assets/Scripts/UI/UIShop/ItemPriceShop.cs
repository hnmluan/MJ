[System.Serializable]
public class ItemPriceShop
{
    public int price = 0;
    public CurrencyCode currencyCode = CurrencyCode.NoCurrency;

    public ItemPriceShop(int price, CurrencyCode currencyCode)
    {
        this.price = price;
        this.currencyCode = currencyCode;
    }
}
