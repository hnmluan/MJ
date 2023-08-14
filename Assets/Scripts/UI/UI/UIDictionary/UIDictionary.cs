using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIDictionary : InitMonoBehaviour
{
    [Header("UI Dictionary")]
    private static UIDictionary instance;
    public static UIDictionary Instance => instance;

    protected bool isOpen = true;

    [SerializeField] protected DictionarySort dictionarySort = DictionarySort.ByName;

    [SerializeField] protected ItemType dictionaryFilter = ItemType.NoType;

    public void SetDictionarySort(DictionarySort dictionarySort)
    {
        this.dictionarySort = dictionarySort;
        this.ShowItems();
    }

    public void SetDictionaryFilter(ItemType dictionaryFilter)
    {
        this.dictionaryFilter = dictionaryFilter;
        this.ShowItems();
    }

    protected override void Awake()
    {
        base.Awake();
        if (UIDictionary.instance != null) Debug.LogError("Only 1 UIDictionary allow to exist");
        UIDictionary.instance = this;
    }

    protected override void Start()
    {
        base.Start();
        ShowItems();
        this.Close();

        //DictionaryokeRepeating(nameof(this.ShowItems), 1, 1);
    }

    public virtual void Toggle()
    {
        this.isOpen = !this.isOpen;
        if (this.isOpen) this.Open();
        else this.Close();
    }

    public virtual void Open()
    {
        UIDictionaryCtrl.Instance.gameObject.SetActive(true);
        ShowItems();
        this.isOpen = true;
    }

    public virtual void Close()
    {
        UIDictionaryCtrl.Instance.gameObject.SetActive(false);
        this.isOpen = false;
    }

    public virtual void ShowItems()
    {
        if (!this.isOpen) return;

        this.ClearItems();

        List<ItemDictionary> items = new List<ItemDictionary>();

        items = dictionaryFilter == ItemType.NoType ? items : items.Where(item => item.itemProfile.itemType == dictionaryFilter).ToList();

        foreach (ItemDictionary item in items) UIDictionaryItemSpawner.Instance.SpawnItem(item);

        this.SortItems();
    }

    protected virtual void ClearItems() => UIDictionaryItemSpawner.Instance.ClearItems();

    protected virtual void SortItems()
    {
        if (this.dictionarySort == DictionarySort.NoSort) return;

        int itemCount = UIDictionaryCtrl.Instance.Content.childCount;
        bool isSorting = false;

        for (int i = 0; i < itemCount - 1; i++)
        {
            Transform currentItem = UIDictionaryCtrl.Instance.Content.GetChild(i);
            Transform nextItem = UIDictionaryCtrl.Instance.Content.GetChild(i + 1);

            UIItemDictionary currentUIItem = currentItem.GetComponent<UIItemDictionary>();
            UIItemDictionary nextUIItem = nextItem.GetComponent<UIItemDictionary>();

            ItemProfileSO currentProfile = currentUIItem.ItemDictionary.itemProfile;
            ItemProfileSO nextProfile = nextUIItem.ItemDictionary.itemProfile;

            bool isSwap = false;

            switch (this.dictionarySort)
            {
                case DictionarySort.ByName:
                    string currentName = currentProfile.itemName;
                    string nextName = nextProfile.itemName;
                    isSwap = string.Compare(currentName, nextName) == 1; // Đổi từ -1 thành 1 để đảo ngược thứ tự
                    break;
                case DictionarySort.ByQuantity:
                    int currentCount = currentUIItem.ItemDictionary.itemCount;
                    int nextCount = nextUIItem.ItemDictionary.itemCount;
                    isSwap = currentCount < nextCount; // Đổi dấu > thành <
                    break;
            }

            // Sắp xếp theo tiêu chí phụ (nếu có) khi không có swap theo tiêu chí chính
            if (!isSwap)
            {
                switch (this.dictionarySort)
                {
                    case DictionarySort.ByName:
                        // Sắp xếp theo số lượng nếu cùng tên
                        if (currentProfile.itemName == nextProfile.itemName)
                        {
                            int currentCount = currentUIItem.ItemDictionary.itemCount;
                            int nextCount = nextUIItem.ItemDictionary.itemCount;
                            isSwap = currentCount < nextCount;
                        }
                        break;
                    case DictionarySort.ByQuantity:
                        // Sắp xếp theo tên nếu cùng số lượng
                        if (currentUIItem.ItemDictionary.itemCount == nextUIItem.ItemDictionary.itemCount)
                        {
                            string currentName = currentProfile.itemName;
                            string nextName = nextProfile.itemName;
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
