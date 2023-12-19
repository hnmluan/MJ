using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class ItemOpenTreasureData : ItemActionData
{
    public List<ItemDropRate> listItemDrop;

    public List<ItemDropRate> Drop()
    {
        GetDroppedItems().ForEach(item => Inventory.Instance.AddItem(item.itemSO.itemCode, 1));

        return GetDroppedItems();
    }

    private List<ItemDropRate> GetDroppedItems()
    {
        return listItemDrop.SelectMany(item =>
        {
            float rate = UnityEngine.Random.Range(0, 1f);
            float itemRate = item.dropRate / 100000f;
            int itemDropMore = Mathf.FloorToInt(itemRate);

            return Enumerable.Repeat(item, itemDropMore).ToList();
        }).ToList();
    }

    public void Open(int quantity)
    {
        List<ItemDropRate> itemDropRates = Enumerable.Range(0, quantity)
            .SelectMany(_ => Drop())
            .ToList();

        UITextSpawner.Instance.SpawnUIImageTextWithMousePosition(itemDropRates);
    }
}
