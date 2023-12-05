[System.Serializable]
public class ItemRangePrice
{
    public CurrencyDataSO currencyCode;
    public IntRange rangePrice;

    public ItemRangePrice(CurrencyDataSO currencyCode, IntRange rangePrice)
    {
        this.currencyCode = currencyCode;
        this.rangePrice = rangePrice;
    }
}
