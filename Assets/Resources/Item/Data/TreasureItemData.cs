using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]

public class TreasureItemData : ItemData
{
    public List<ItemDropRate> listItemDrop;

    public virtual List<ItemDropRate> Drop(List<ItemDropRate> dropList)
    {
        List<ItemDropRate> dropItems = new List<ItemDropRate>();

        if (dropList.Count < 1) return dropItems;

        dropItems = this.DropItems(dropList);
        foreach (ItemDropRate itemDropRate in dropItems)
        {
            ItemCode itemCode = itemDropRate.itemSO.itemCode;
            Inventory.Instance.AddItem(itemCode, 1);
        }

        return dropItems;
    }

    protected virtual List<ItemDropRate> DropItems(List<ItemDropRate> items)
    {
        List<ItemDropRate> droppedItems = new List<ItemDropRate>();

        float rate, itemRate;
        int itemDropMore;

        foreach (ItemDropRate item in items)
        {
            rate = UnityEngine.Random.Range(0, 1f);
            itemRate = item.dropRate / 100000f;

            itemDropMore = Mathf.FloorToInt(itemRate);
            if (itemDropMore > 0)
            {
                itemRate -= itemDropMore;
                for (int i = 0; i < itemDropMore; i++) droppedItems.Add(item);
            }
        }

        return droppedItems;
    }

    public void OpenTreasure(int quantity)
    {
        List<ItemDropRate> itemDropRates = new List<ItemDropRate>();

        for (int i = 0; i < quantity; i++)
        {
            List<ItemDropRate> itemDropRate = Drop(listItemDrop);
            itemDropRates.AddRange(itemDropRate);
        }

        UITextSpawner.Instance.SpawnUIImageTextWithMousePosition(itemDropRates);
    }
}
