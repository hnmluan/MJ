public interface IObservationShop
{
    void BuyItem(ItemShop item, bool isTransactionSuccessful);

    void ResetItems();
}
