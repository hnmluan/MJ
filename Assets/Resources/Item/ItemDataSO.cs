using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemProfileSO", menuName = "ScriptableObject/ItemProfile")]

public class ItemDataSO : ScriptableObject
{
    public ItemCode itemCode = ItemCode.NoItem;

    public ItemType itemType = ItemType.NoType;

    public ItemRarity itemRarity = ItemRarity.NoRarity;

    public string keyName = "no-name";

    public Sprite itemSprite;

    public string keyDescription;

    public int defaultMaxStack = 10;

    [field: SerializeReference] public List<ActionItemData> actionItemDatas;

    public void AddData(ActionItemData data)
    {
        if (actionItemDatas.FirstOrDefault(t => t.GetType() == data.GetType()) != null)
            return;

        actionItemDatas.Add(data);
    }

    public bool IsExistItemData<T>() where T : ActionItemData => GetItemData<T>() != null;

    public T GetItemData<T>() where T : ActionItemData => actionItemDatas.OfType<T>().FirstOrDefault();

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
        return allItemDataSO.Where(itemDataSO => itemDataSO.actionItemDatas.Any(data => data is BuyItemDataAction)).ToList();
    }
}


