using System.Collections.Generic;
using UnityEngine;

public class UIInvIn4 : InitMonoBehaviour
{
    [Header("UI Inventory Information")]

    private static UIInvIn4 instance;
    public static UIInvIn4 Instance => instance;

    [SerializeField] protected ItemInventory itemInventory = null;
    public ItemInventory ItemInventory => itemInventory;

    [SerializeField] protected BtnUseItem btnUseItem;
    public BtnUseItem BtnUseItem => btnUseItem;

    [SerializeField] protected BtnUseItemAll btnUseItemAll;
    public BtnUseItemAll BtnUseItemAll => btnUseItemAll;

    protected override void Awake()
    {
        base.Awake();
        if (UIInvIn4.instance != null) Debug.LogError("Only 1 UIInventory allow to exist");
        UIInvIn4.instance = this;
    }

    protected override void OnDisable() => this.SetEmptyUIInfor();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBtnUseItem();
        this.LoadBtnUseItemAll();
    }

    protected virtual void LoadBtnUseItem()
    {
        if (this.btnUseItem != null) return;
        this.btnUseItem = transform.GetComponentInChildren<BtnUseItem>();
        Debug.Log(transform.name + ": LoadBtnUseItem", gameObject);
    }

    protected virtual void LoadBtnUseItemAll()
    {
        if (this.btnUseItemAll != null) return;
        this.btnUseItemAll = transform.GetComponentInChildren<BtnUseItemAll>();
        Debug.Log(transform.name + ": LoadBtnUseItem", gameObject);
    }

    public virtual void ResetUIInfor(ItemInventory item)
    {
        this.itemInventory = item;
        HideButton();
        if (CanUse()) this.ShowButton();
    }

    public virtual void SetEmptyUIInfor()
    {
        HideButton();
        this.itemInventory = null;
    }

    public virtual void ClickUseItem()
    {
        Drop(itemInventory.itemProfile.dropListItem);
        PlayerCtrl.Instance.Inventory.DeductItem(itemInventory.itemProfile.itemCode, 1);
        ResetUIInfor(itemInventory);
        if (itemInventory.itemCount == 0) SetEmptyUIInfor();
    }

    public virtual void ClickUseAllItem()
    {
        for (int i = 0; i < itemInventory.itemCount; i++) Drop(itemInventory.itemProfile.dropListItem);
        PlayerCtrl.Instance.Inventory.DeductItem(itemInventory.itemProfile.itemCode, itemInventory.itemCount);
        SetEmptyUIInfor();
    }

    private void ShowButton()
    {
        btnUseItem.transform.gameObject.SetActive(true);
        BtnUseItemAll.transform.gameObject.SetActive(true);
    }

    private void HideButton()
    {
        btnUseItem.transform.gameObject.SetActive(false);
        BtnUseItemAll.transform.gameObject.SetActive(false);
    }

    private bool CanUse() => itemInventory.itemProfile.dropListItem.Count != 0;

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
                for (int i = 0; i < itemDropMore; i++)
                {
                    droppedItems.Add(item);
                }
            }
        }

        return droppedItems;
    }
}
