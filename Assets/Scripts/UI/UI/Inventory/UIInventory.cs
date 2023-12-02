using Assets.SimpleLocalization;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public enum InventorySort
{
    NoSort = 0,
    Name = 1,
    Quantity = 2,
}

public class UIInventory : InitMonoBehaviour, IObservationInventory
{
    private static UIInventory instance;
    public static UIInventory Instance => instance;

    protected bool isOpen = true;

    protected override void Awake()
    {
        base.Awake();
        if (UIInventory.instance != null) Debug.LogError("Only 1 UIInventory allow to exist");
        UIInventory.instance = this;
    }

    protected override void Start() => this.Close();

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
        else this.Close();
    }

    public virtual void Open()
    {
        this.gameObject.SetActive(true);
        this.isOpen = true;
    }

    public virtual void Close()
    {
        this.gameObject.SetActive(false);
        this.isOpen = false;
    }

    [SerializeField] protected InventorySort inventorySort = InventorySort.Name;

    [SerializeField] protected ItemType inventoryFilter = ItemType.NoType;

    [SerializeField] protected UIInvItemSpawner invItemSpawner;

    [SerializeField] protected UIInvDetail uiInvDetail;

    [SerializeField] protected Text slotItemText;

    [SerializeField] protected Text quanityItemText;
    [SerializeField] public UIInvDetail UIInvDetail => uiInvDetail;




    protected override void OnEnable()
    {
        Inventory.Instance.AddObservation(this);
        this.ShowItems();
    }

    protected override void OnDisable() => Inventory.Instance.RemoveObservation(this);

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

    public virtual void ShowItems()
    {
        this.ClearItems();

        List<ItemInventory> items = Inventory.Instance.Items;

        items = inventoryFilter == ItemType.NoType ? items : items.Where(item => item.itemProfile.itemType == inventoryFilter).ToList();

        foreach (ItemInventory item in items)
            invItemSpawner.SpawnItem(item);

        this.SortItems();

        UpdateInventorySlotText();

        UpdateInventoryQuantityText();
    }

    protected virtual void ClearItems() => invItemSpawner.ClearItems();

    protected virtual void SortItems()
    {
        if (this.inventorySort == InventorySort.NoSort) return;

        int itemCount = invItemSpawner.Content.childCount;
        bool isSorting = false;

        for (int i = 0; i < itemCount - 1; i++)
        {
            Transform currentItem = invItemSpawner.Content.GetChild(i);
            Transform nextItem = invItemSpawner.Content.GetChild(i + 1);

            UIItemInventory currentUIItem = currentItem.GetComponent<UIItemInventory>();
            UIItemInventory nextUIItem = nextItem.GetComponent<UIItemInventory>();

            ItemDataSO currentProfile = currentUIItem.ItemInventory.itemProfile;
            ItemDataSO nextProfile = nextUIItem.ItemInventory.itemProfile;

            bool isSwap = false;

            switch (this.inventorySort)
            {
                case InventorySort.Name:
                    string currentName = LocalizationManager.Localize(currentProfile.keyName);
                    string nextName = LocalizationManager.Localize(nextProfile.keyName);
                    isSwap = string.Compare(currentName, nextName) == 1; // Đổi từ -1 thành 1 để đảo ngược thứ tự
                    break;
                case InventorySort.Quantity:
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
                    case InventorySort.Name:
                        // Sắp xếp theo số lượng nếu cùng tên
                        if (currentProfile.keyName == nextProfile.keyName)
                        {
                            int currentCount = currentUIItem.ItemInventory.itemCount;
                            int nextCount = nextUIItem.ItemInventory.itemCount;
                            isSwap = currentCount < nextCount;
                        }
                        break;
                    case InventorySort.Quantity:
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

    protected void UpdateInventorySlotText() => slotItemText.text = Inventory.Instance.GetCurrentItemCount() + " / " + Inventory.Instance.MaxItemCount;

    protected void UpdateInventoryQuantityText() => quanityItemText.text = Inventory.Instance.GetCurrentItemCount() + " / " + Inventory.Instance.MaxItemCount;

    public void AddItem() => this.ShowItems();

    public void DeductItem() => this.ShowItems();

    public void ClearAllFocus()
    {
        foreach (Transform item in invItemSpawner.Content)
        {
            UIItemInventory uiItem = item.GetComponent<UIItemInventory>();
            if (uiItem == null) return;
            uiItem.ClearFocus();
        }
    }
}
