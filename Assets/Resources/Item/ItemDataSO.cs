using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfileSO", menuName = "ScriptableObject/ItemProfile")]

[Serializable]
public class ItemDataSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;

    public ItemType itemType = ItemType.NoType;

    public string keyName = "no-name";

    public Sprite itemSprite;

    public string keyDescription;

    public int defaultMaxStack = 10;

    [field: SerializeReference] public List<ItemData> datas;

    public void AddData(ItemData data)
    {
        if (datas.FirstOrDefault(t => t.GetType() == data.GetType()) != null)
            return;

        datas.Add(data);
    }

    public bool IsExistItemData<T>() where T : ItemData => GetItemData<T>() != null;

    public T GetItemData<T>() where T : ItemData => datas.OfType<T>().FirstOrDefault();

    public static ItemDataSO FindByItemCode(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item/ScriptableObject", typeof(ItemDataSO));
        foreach (ItemDataSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }

    public static ItemDataSO GetRandomSellableItemSO()
    {
        if (GetSellableItemsSO().Count == 0) return null;

        System.Random random = new System.Random();

        int randomIndex = random.Next(0, GetSellableItemsSO().Count);

        return GetSellableItemsSO()[randomIndex];
    }

    public static List<ItemDataSO> GetSellableItemsSO()
    {
        ItemDataSO[] allItemDataSO = Resources.LoadAll<ItemDataSO>("Item/ScriptableObject");
        return allItemDataSO.Where(itemDataSO => itemDataSO.datas.Any(data => data is BuyableItemData)).ToList();
    }
}


