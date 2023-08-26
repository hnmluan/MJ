using System;

[Serializable]
public class ItemShop
{
    public ItemDataSO itemProfile;
    public int quantity = 0;
    public int price = 0;
    public ItemPriceShop itemPrice;

    public static ItemShop GetRandomSellableItem()
    {
        ItemShop newItemShop = new ItemShop();

        newItemShop.itemProfile = GetSellableItemData();
        newItemShop.quantity = GetRandomItemQuantity(newItemShop.itemProfile);
        newItemShop.itemPrice = GetRandomItemPrice(newItemShop.itemProfile);
        newItemShop.price = newItemShop.quantity * newItemShop.itemPrice.price;

        return newItemShop;
    }

    private static ItemPriceShop GetRandomItemPrice(ItemDataSO itemProfile)
    {
        System.Random random = new System.Random();
        int randomIndex = random.Next(itemProfile.GetItemData<SellItemData>().price.Count);
        ItemRangePrice itemPrice = itemProfile.GetItemData<SellItemData>().price[randomIndex];
        return new ItemPriceShop(itemPrice.rangePrice.GetRandomValue(), itemPrice.currencyCode);
    }

    private static ItemDataSO GetSellableItemData() => ItemDataSO.GetRandomSellableItemSO();

    private static int GetRandomItemQuantity(ItemDataSO itemProfile) => itemProfile.GetItemData<SellItemData>().quantityToBuy.GetRandomValue();
}
