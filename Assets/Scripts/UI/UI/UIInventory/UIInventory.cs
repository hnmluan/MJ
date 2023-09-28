using Assets.SimpleLocalization;
using System.Collections.Generic;
using UnityEngine;
public enum InventorySort
{
    NoSort = 0,
    ByName = 1,
    ByQuantity = 2,
}

public class UIInventory : Singleton<UIInventory>
{
    [SerializeField] protected InventorySort inventorySort = InventorySort.ByName;

    [SerializeField] protected ItemType inventoryFilter = ItemType.NoType;

    [SerializeField] protected Transform slots;

    [SerializeField] protected ItemSlotInventory itemSlotPrefab;

    [SerializeField] protected DetailInventory detailBoxInventory;

    protected override void OnEnable() => ShowItems();

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

    public List<ItemSlotInventory> GetListUIItemInventory()
    {
        List<ItemSlotInventory> list = new List<ItemSlotInventory>();

        int itemCount = slots.childCount;

        for (int i = 0; i < itemCount; i++)
        {
            Transform currentItem = slots.GetChild(i);

            if (currentItem.gameObject.activeSelf == true)
            {
                ItemSlotInventory currentUIItem = currentItem.GetComponent<ItemSlotInventory>();

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
        ClearItemSlots();

        List<ItemInventory> items = Inventory.Instance.Items;

        foreach (ItemInventory item in items)
        {
            GetItemSlotInactive().ShowItem(item);
        }

        this.SortItems();
    }

    protected virtual void SortItems()
    {
        if (this.inventorySort == InventorySort.NoSort) return;

        int itemCount = slots.childCount;
        bool isSorting = false;

        for (int i = 0; i < itemCount - 1; i++)
        {
            Transform currentItem = slots.GetChild(i);
            Transform nextItem = slots.GetChild(i + 1);

            ItemSlotInventory currentUIItem = currentItem.GetComponent<ItemSlotInventory>();
            ItemSlotInventory nextUIItem = nextItem.GetComponent<ItemSlotInventory>();

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

    protected void ClearItemSlots()
    {
        foreach (Transform child in slots)
        {
            child.gameObject.SetActive(false);
        }
    }

    protected ItemSlotInventory GetItemSlotInactive()
    {
        foreach (Transform child in slots)
        {
            if (child.gameObject.activeSelf == false)
            {
                child.gameObject.SetActive(true);
                return child.GetComponent<ItemSlotInventory>();
            }
        }

        ItemSlotInventory newItemSlotInventory = Instantiate(itemSlotPrefab, slots);
        newItemSlotInventory.gameObject.SetActive(true);
        newItemSlotInventory.transform.localScale = Vector3.one;

        return newItemSlotInventory;
    }

    public void ShowInforItem(ItemInventory itemInventory) => detailBoxInventory.SetBox(itemInventory);
}