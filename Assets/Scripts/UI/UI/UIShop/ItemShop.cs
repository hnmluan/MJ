using System;

[Serializable]
public class ItemShop
{
    public ItemDataSO itemProfile;
    public int quantity = 0;
    public int price = 0;
    public ItemPriceShop itemPrice;

    public static ItemShop GetRandomItemShopExcludingNoItem()
    {
        ItemShop newItemShop = new ItemShop();

        newItemShop.itemProfile = GetRandomItemProfileSO();
        newItemShop.quantity = GetRandomItemQuantity(newItemShop.itemProfile);
        newItemShop.itemPrice = GetRandomItemPrice(newItemShop.itemProfile);
        newItemShop.price = newItemShop.quantity * newItemShop.itemPrice.price;

        return newItemShop;
    }

    private static ItemPriceShop GetRandomItemPrice(ItemDataSO itemProfile)
    {
        System.Random random = new System.Random();
        int randomIndex = random.Next(itemProfile.price.Count);
        ItemRangePrice itemPrice = itemProfile.price[randomIndex];
        return new ItemPriceShop(itemPrice.rangePrice.GetRandomValue(), itemPrice.currencyCode);
    }

    private static ItemDataSO GetRandomItemProfileSO()
    {
        ItemCode randomItemCode = ItemDataSO.GetRandomItemCodeExcludingNoItem();
        return ItemDataSO.FindByItemCode(randomItemCode);
    }

    private static int GetRandomItemQuantity(ItemDataSO itemProfile) => itemProfile.quantityToBuy.GetRandomValue();
}
