using System;

[Serializable]
public class ItemShop
{
    public ItemProfileSO itemProfile;
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

    private static ItemPriceShop GetRandomItemPrice(ItemProfileSO itemProfile)
    {
        System.Random random = new System.Random();
        int randomIndex = random.Next(itemProfile.price.Count);
        ItemPrice itemPrice = itemProfile.price[randomIndex];
        return new ItemPriceShop(itemPrice.rangePrice.GetRandomValue(), itemPrice.currencyCode);
    }

    private static ItemProfileSO GetRandomItemProfileSO()
    {
        ItemCode randomItemCode = ItemProfileSO.GetRandomItemCodeExcludingNoItem();
        return ItemProfileSO.FindByItemCode(randomItemCode);
    }

    private static int GetRandomItemQuantity(ItemProfileSO itemProfile) => itemProfile.quantityToBuy.GetRandomValue();


}
