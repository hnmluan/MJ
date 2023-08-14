using System.Collections.Generic;
using UnityEngine;

public class UIDictionaryIn4 : InitMonoBehaviour
{
    [Header("UI Dictionary Information")]

    private static UIDictionaryIn4 instance;
    public static UIDictionaryIn4 Instance => instance;

    [SerializeField] protected ItemDictionary itemDictionary = null;
    public ItemDictionary ItemDictionary => itemDictionary;

    protected override void Awake()
    {
        base.Awake();
        if (UIDictionaryIn4.instance != null) Debug.LogError("Only 1 UIDictionary allow to exist");
        UIDictionaryIn4.instance = this;
    }

    protected override void OnDisable() => this.SetEmptyUIInfor();

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }


    public virtual void ResetUIInfor(ItemDictionary item)
    {
        this.itemDictionary = item;
    }

    public virtual void SetEmptyUIInfor()
    {
        this.itemDictionary = null;
    }

    public virtual void ClickUseItem()
    {
        Drop(itemDictionary.itemProfile.listItemCanGet);
        PlayerCtrl.Instance.Inventory.DeductItem(itemDictionary.itemProfile.itemCode, 1);
        ResetUIInfor(itemDictionary);
        if (itemDictionary.itemCount == 0) SetEmptyUIInfor();
        UIDictionary.Instance.ShowItems();
    }

    public virtual void ClickUseAllItem()
    {
        for (int i = 0; i < itemDictionary.itemCount; i++) Drop(itemDictionary.itemProfile.listItemCanGet);
        PlayerCtrl.Instance.Inventory.DeductItem(itemDictionary.itemProfile.itemCode, itemDictionary.itemCount);
        SetEmptyUIInfor();
        UIDictionary.Instance.ShowItems();
    }

    private bool CanUse() => itemDictionary.itemProfile.listItemCanGet.Count != 0;

    public virtual List<ItemDropRate> Drop(List<ItemDropRate> dropList)
    {
        List<ItemDropRate> dropItems = new List<ItemDropRate>();

        if (dropList.Count < 1) return dropItems;

        dropItems = this.DropItems(dropList);
        foreach (ItemDropRate itemDropRate in dropItems)
        {
            ItemCode itemCode = itemDropRate.itemSO.itemCode;
            PlayerCtrl.Instance.Inventory.AddItem(itemCode, 1);
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
            rate = Random.Range(0, 1f);
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
}
