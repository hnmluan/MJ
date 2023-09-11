[System.Serializable]
public class ItemPriceShop
{
    public int price = 0;
    public CurrencyDataSO currencyProfileSO;

    public ItemPriceShop(int price, CurrencyDataSO currencyProfileSO)
    {
        this.price = price;
        this.currencyProfileSO = currencyProfileSO;
    }
}
