[System.Serializable]
public class ItemPriceShop
{
    public int price = 0;
    public CurrencyProfileSO currencyProfileSO;

    public ItemPriceShop(int price, CurrencyProfileSO currencyProfileSO)
    {
        this.price = price;
        this.currencyProfileSO = currencyProfileSO;
    }
}
