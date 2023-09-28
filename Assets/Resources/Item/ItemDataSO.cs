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

    [field: SerializeReference] public List<ItemActionData> actionItemDatas;

    public void AddData(ItemActionData data)
    {
        if (actionItemDatas.FirstOrDefault(t => t.GetType() == data.GetType()) != null)
            return;

        actionItemDatas.Add(data);
    }

    public bool IsExistItemData<T>() where T : ItemActionData => GetItemData<T>() != null;

    public T GetItemData<T>() where T : ItemActionData => actionItemDatas.OfType<T>().FirstOrDefault();

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
}


