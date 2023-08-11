using UnityEngine;

public class ItemShop : MonoBehaviour
{
    public ItemProfileSO itemProfile;
    public int quantity = 0;
    public int price = 0;

    public static ItemShop GetRandomItemShopExcludingNoItem()
    {
        ItemShop newItemShop = new ItemShop();
        ItemCode randomItemCode = ItemProfileSO.GetRandomItemCodeExcludingNoItem();
        newItemShop.itemProfile = ItemProfileSO.FindByItemCode(randomItemCode);
        newItemShop.price = newItemShop.itemProfile.priceToSale.GetRandomValue();
        newItemShop.quantity = newItemShop.itemProfile.quantityToBy.GetRandomValue();
        return newItemShop;
    }

}
