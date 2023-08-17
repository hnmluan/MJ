using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIInventory : BaseUI, IActionInventoryObserver
{
    [Header("UI Inventory")]
    private static UIInventory instance;
    public static UIInventory Instance => instance;

    [SerializeField] protected InventorySort inventorySort = InventorySort.ByName;

    [SerializeField] protected ItemType inventoryFilter = ItemType.NoType;

    public int CurrSlots = -1;

    protected override void Awake()
    {
        base.Awake();
        if (UIInventory.instance != null) Debug.LogError("Only 1 UIInventory allow to exist");
        UIInventory.instance = this;
    }

    protected override void Start()
    {
        this.Close();
        Inventory.Instance.AddObserver(this);
    }

    protected override void OnEnable() => CurrSlots = -1;

    public int GetIndexSlot(ItemInventory itemInventory)
    {
        int index = -1;

        int itemCount = UIInventoryCtrl.Instance.Content.childCount;

        for (int i = 0; i < itemCount; i++)
        {
            Transform currentItem = UIInventoryCtrl.Instance.Content.GetChild(i);

            if (currentItem.gameObject.activeSelf == true)
            {
                UIItemInventory currentUIItem = currentItem.GetComponent<UIItemInventory>();

                ItemInventory currentProfile = currentUIItem.ItemInventory;

                index += 1;

                if (currentProfile == itemInventory)
                {
                    return index;
                }
            }
        }
        return -1;
    }

    public ItemInventory GetItemInventoryInCurrSlots()
    {
        for (int i = 0; i < Inventory.Instance.Items.Count; i++)
        {
            if (GetIndexSlot(Inventory.Instance.Items[i]) == CurrSlots)
            {
                return Inventory.Instance.Items[i];
            }
        }
        return null;
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

    public override void Open()
    {
        base.Open();
        ShowItems();
    }

    private void ShowItems()
    {
        this.ClearItems();

        List<ItemInventory> items = Inventory.Instance.Items;

        items = inventoryFilter == ItemType.NoType ? items : items.Where(item => item.itemProfile.itemType == inventoryFilter).ToList();

        foreach (ItemInventory item in items) UIInvItemSpawner.Instance.SpawnItem(item);

        this.SortItems();
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

            ItemProfileSO currentProfile = currentUIItem.ItemInventory.itemProfile;
            ItemProfileSO nextProfile = nextUIItem.ItemInventory.itemProfile;

            bool isSwap = false;

            switch (this.inventorySort)
            {
                case InventorySort.ByName:
                    string currentName = currentProfile.keyName;
                    string nextName = nextProfile.keyName;
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
                            string currentName = currentProfile.keyName;
                            string nextName = nextProfile.keyName;
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

    public void OnAddItem() => ShowItems();

    public void OnDeductItem() => ShowItems();
}
