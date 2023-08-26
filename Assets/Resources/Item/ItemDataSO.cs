using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfileSO", menuName = "SO/ItemProfile")]

public class ItemDataSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;

    public ItemType itemType = ItemType.NoType;

    public string keyName = "no-name";

    public Sprite itemSprite;

    public string keyDescription;

    public int defaultMaxStack = 10;

    public int priceToSell;

    public List<ItemDropRate> listItemCanGet;

    public List<ItemRangePrice> price;

    public IntRange quantityToBuy;

    [field: SerializeReference] public List<ItemData> datas = new List<ItemData>() { new DetailsItemData() };

    public void AddData(ItemData data)
    {
        if (datas.FirstOrDefault(t => t.GetType() == data.GetType()) != null)
            return;

        datas.Add(data);
    }

    public static ItemDataSO FindByItemCode(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item/SO", typeof(ItemDataSO));
        foreach (ItemDataSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }

    public static ItemCode GetRandomItemCodeExcludingNoItem()
    {
        ItemCode[] itemCode = (ItemCode[])System.Enum.GetValues(typeof(ItemCode));
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


