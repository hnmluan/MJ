using Assets.SimpleLocalization;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIInventory : BaseUI<UIInventory>
{
    [SerializeField] protected InventorySort inventorySort = InventorySort.ByName;

    [SerializeField] protected ItemType inventoryFilter = ItemType.NoType;

    [SerializeField] public int currentItemInventory = -1;

    protected override void OnEnable()
    {
        ClearFocusItem();
        currentItemInventory = -1;
    }

    public override void Open()
    {
        base.Open();
        ShowItems();
    }

    public void SetInventorySort(InventorySort inventorySort)
    {
        this.inventorySort = inventorySort;
        this.ShowItems();
    }

    public void SetInventoryFilter(ItemType inventoryFilter)
    {
        this.inventoryFilter = inventoryFilter;
        this.ShowItems();
    }

    public virtual void SetCurrentItemInventory(int currentItemInventory) => this.currentItemInventory = currentItemInventory;

    public void ClearFocusItem()
    {
        foreach (UIItemInventory item in GetListUIItemInventory()) item.Focus.gameObject.SetActive(false);
    }

    public void KeepFocusInCurrentItemInventory()
    {
        ClearFocusItem();
        try
        {
            if (currentItemInventory == -1) return;
            GetListUIItemInventory()[currentItemInventory].Focus.gameObject.SetActive(true);
            UIInvDetail.Instance.SetUIInvDetail(GetListUIItemInventory()[currentItemInventory].ItemInventory);
        }
        catch (System.Exception)
        {
            currentItemInventory = -1;
        }
    }

    public List<UIItemInventory> GetListUIItemInventory()
    {
        List<UIItemInventory> list = new List<UIItemInventory>();

        int itemCount = UIInventoryCtrl.Instance.Content.childCount;

        for (int i = 0; i < itemCount; i++)
        {
            Transform currentItem = UIInventoryCtrl.Instance.Content.GetChild(i);

            if (currentItem.gameObject.activeSelf == true)
            {
                UIItemInventory currentUIItem = currentItem.GetComponent<UIItemInventory>();

                list.Add(currentUIItem);
            }
        }
        return list;
    }

    public int GetIndexItemInventory(ItemInventory itemInventory)
    {
        int itemCount = GetListUIItemInventory().Count;

        for (int i = 0; i < itemCount; i++) if (GetListUIItemInventory()[i].ItemInventory == itemInventory) return i;

        return -1;
    }

    public virtual void ShowItems()
    {
        this.ClearItems();

        List<ItemInventory> items = Inventory.Instance.Items;

        items = inventoryFilter == ItemType.NoType ? items : items.Where(item => item.itemProfile.itemType == inventoryFilter).ToList();

        foreach (ItemInventory item in items) UIInvItemSpawner.Instance.SpawnItem(item);

        this.SortItems();

        KeepFocusInCurrentItemInventory();
    }

    protected virtual void ClearItems() => UIInvItemSpawner.Instance.ClearItems();

    protected virtual void SortItems()
    {
        if (this.inventorySort == InventorySort.NoSort) return;

        int itemCount = UIInventoryCtrl.Instance.Content.childCount;
        bool isSorting = false;

        for (int i = 0; i < itemCount - 1; i++)
        {
            Transform currentItem = UIInventoryCtrl.Instance.Content.GetChild(i);
            Transform nextItem = UIInventoryCtrl.Instance.Content.GetChild(i + 1);

            UIItemInventory currentUIItem = currentItem.GetComponent<UIItemInventory>();
            UIItemInventory nextUIItem = nextItem.GetComponent<UIItemInventory>();

            ItemDataSO currentProfile = currentUIItem.ItemInventory.itemProfile;
            ItemDataSO nextProfile = nextUIItem.ItemInventory.itemProfile;

            bool isSwap = false;

            switch (this.inventorySort)
            {
                case InventorySort.ByName:
                    string currentName = LocalizationManager.Localize(currentProfile.keyName);
                    string nextName = LocalizationManager.Localize(nextProfile.keyName);
                    isSwap = string.Compare(currentName, nextName) == 1; // Đổi từ -1 thành 1 để đảo ngược thứ tự
                    break;
                case InventorySort.ByQuantity:
                    int currentCount = currentUIItem.ItemInventory.itemCount;
                    int nextCount = nextUIItem.ItemInventory.itemCount;
                    isSwap = currentCount < nextCount; // Đổi dấu > thành <
                    break;
            }

            // Sắp xếp theo tiêu chí phụ (nếu có) khi không có swap theo tiêu chí chính
            if (!isSwap)
            {
                switch (this.inventorySort)
                {
                    case InventorySort.ByName:
                        // Sắp xếp theo số lượng nếu cùng tên
                        if (currentProfile.keyName == nextProfile.keyName)
                        {
                            int currentCount = currentUIItem.ItemInventory.itemCount;
                            int nextCount = nextUIItem.ItemInventory.itemCount;
                            isSwap = currentCount < nextCount;
                        }
                        break;
                    case InventorySort.ByQuantity:
                        // Sắp xếp theo tên nếu cùng số lượng
                        if (currentUIItem.ItemInventory.itemCount == nextUIItem.ItemInventory.itemCount)
                        {
                            string currentName = LocalizationManager.Localize(currentProfile.keyName);
                            string nextName = LocalizationManager.Localize(nextProfile.keyName);
                            isSwap = string.Compare(currentName, nextName) == 1;
                        }
                        break;
                }
            }

            if (isSwap)
            {
                this.SwapItems(currentItem, nextItem);
                isSorting = true;
            }
        }

        if (isSorting) this.SortItems(); // Gọi đệ quy chỉ khi có sự thay đổi
    }

    protected virtual void SwapItems(Transform currentItem, Transform nextItem)
    {
        int currentIndex = currentItem.GetSiblingIndex();
        int nextIndex = nextItem.GetSiblingIndex();

        currentItem.SetSiblingIndex(nextIndex);
        nextItem.SetSiblingIndex(currentIndex);
    }
}
