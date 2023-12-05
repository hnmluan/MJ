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

    public int defaultMaxStack;

    [field: SerializeReference] public List<ItemActionData> itemActionDatas;

    public ItemDataSO()
    {
        itemActionDatas.Add(new ItemSellAcctionData());
        itemActionDatas.Add(new ItemBuyActionData());
        itemActionDatas.Add(new ItemOpenTreasureData());
    }

    public void AddData(ItemActionData data)
    {
        if (itemActionDatas.FirstOrDefault(t => t.GetType() == data.GetType()) != null) return;

        itemActionDatas.Add(data);
    }

    public bool IsExistItemData<T>() where T : ItemActionData => GetItemActionData<T>() != null;

    public T GetItemActionData<T>() where T : ItemActionData => itemActionDatas.OfType<T>().FirstOrDefault();

    public static ItemDataSO FindByCode(ItemCode itemCode)
    {
        var profiles = Resources.LoadAll("Item/ScriptableObject", typeof(ItemDataSO));
        foreach (ItemDataSO profile in profiles)
        {
            if (profile.itemCode != itemCode) continue;
            return profile;
        }
        return null;
    }

    public static ItemDataSO FindByName(string name)
    {
        ItemCode itemCode;
        Enum.TryParse(name, out itemCode);
        return FindByCode(itemCode);
    }

    public static ItemDataSO GetRandomSellableItemSO()
    {
        if (GetSellableItemsSO().Count == 0) return null;

        System.Random random = new System.Random();

        int randomIndex = (new System.Random()).Next(0, GetSellableItemsSO().Count);

        return GetSellableItemsSO()[randomIndex];
    }

    public static List<ItemDataSO> GetSellableItemsSO()
    {
        ItemDataSO[] allItemDataSO = Resources.LoadAll<ItemDataSO>("Item/ScriptableObject");
        return allItemDataSO.Where(itemDataSO => itemDataSO.itemActionDatas.Any(data => data is ItemBuyActionData)).ToList();
    }
}


