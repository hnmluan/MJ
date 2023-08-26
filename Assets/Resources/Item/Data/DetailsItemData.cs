using System;
using UnityEngine;

[Serializable]

public class DetailsItemData : ItemData
{
    public ItemCode itemCode = ItemCode.NoItem;

    public ItemType itemType = ItemType.NoType;

    public string keyName = "no-name";

    public string keyDescription;

    public Sprite itemSprite;

    public int defaultMaxStack = 10;
}
