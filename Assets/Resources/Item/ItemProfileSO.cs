using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfileSO", menuName = "SO/ItemProfile")]
public class ItemProfileSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;

    public ItemType itemType = ItemType.NoType;

    public string itemName = "no-name";

    public Sprite itemSprite;

    public string discription;

    public int defaultMaxStack = 10;

    public List<ItemDropRate> listItemCanGet;

    public List<ItemPrice> price;

    public IntRange priceToBuy;

    public IntRange quantityToBuy;

    public int priceToSell;


    public static ItemProfileSO FindByItemCode(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item", typeof(ItemProfileSO));
        foreach (ItemProfileSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }

    public static ItemCode GetRandomItemCodeExcludingNoItem()
    {
        ItemCode[] itemCode = (ItemCode[])Enum.GetValues(typeof(ItemCode));
        ItemCode randomItemCode;

        System.Random random = new System.Random();

        do
        {
            randomItemCode = itemCode[random.Next(itemCode.Length)];
        } while (randomItemCode == ItemCode.NoItem);

        return randomItemCode;
    }

    public static string GetLocalizationKeyOfName(ItemCode itemCode) => "Item." + itemCode.ToString().Replace(" ", "");
}


