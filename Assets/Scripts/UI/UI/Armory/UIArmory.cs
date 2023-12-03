using Assets.SimpleLocalization;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public enum ArmorySort
{
    NoSort = 0,
    ByName = 1,
    ByLevel = 2,
}

public class UIArmory : UIBase, IObservationArmory
{
    private static UIArmory instance;
    public static UIArmory Instance => instance;

    [SerializeField] protected ArmorySort armorySort = ArmorySort.ByName;

    [SerializeField] protected WeaponType armoryFilter = WeaponType.NoType;

    [SerializeField] UIArmoryItemSpawner itemSpawner;

    protected override void Awake()
    {
        base.Awake();
        if (UIArmory.instance != null) Debug.LogError("Only 1 UIArmory allow to exist");
        UIArmory.instance = this;
    }

    protected override void OnEnable()
    {
        Armory.Instance.AddObservation(this);
        ShowItems();
    }

    protected override void OnDisable() => Armory.Instance.RemoveObservation(this);

    public void SetSort(ArmorySort armorySort)
    {
        this.armorySort = armorySort;
        this.ShowItems();
    }

    public void SetFilter(WeaponType armoryFilter)
    {
        this.armoryFilter = armoryFilter;
        this.ShowItems();
    }

    public void ShowItems()
    {
        this.ClearAllItems();

        List<ItemArmory> weapons = Armory.Instance.Weapons;

        weapons = armoryFilter == WeaponType.NoType ? weapons : weapons.Where(item => item.weaponProfile.damageObjectType == armoryFilter).ToList();

        foreach (ItemArmory weapon in weapons) itemSpawner.SpawnWeapon(weapon);

        this.SortItems();
    }

    protected virtual void ClearAllItems() => itemSpawner.ClearWeapons();

    protected virtual void SortItems()
    {
        if (this.armorySort == ArmorySort.NoSort) return;

        int itemCount = itemSpawner.Content.childCount;
        bool isSorting = false;

        for (int i = 0; i < itemCount - 1; i++)
        {
            Transform currentItem = itemSpawner.Content.GetChild(i);
            Transform nextItem = itemSpawner.Content.GetChild(i + 1);

            UIItemArmory currentUIItem = currentItem.GetComponent<UIItemArmory>();
            UIItemArmory nextUIItem = nextItem.GetComponent<UIItemArmory>();

            ItemArmory currentWeapon = currentUIItem.Weapon;
            ItemArmory nextWeapon = nextUIItem.Weapon;

            WeaponDataSO currentProfile = currentWeapon.weaponProfile;
            WeaponDataSO nextProfile = nextWeapon.weaponProfile;

            bool isSwap = false;

            switch (this.armorySort)
            {
                case ArmorySort.ByName:
                    string currentName = LocalizationManager.Localize(currentProfile.keyName);
                    string nextName = LocalizationManager.Localize(nextProfile.keyName);
                    isSwap = string.Compare(currentName, nextName) == 1; // Đổi từ -1 thành 1 để đảo ngược thứ tự
                    break;
                case ArmorySort.ByLevel:
                    int currentCount = currentWeapon.level;
                    int nextCount = nextWeapon.level;
                    isSwap = currentCount < nextCount; // Đổi dấu > thành <
                    break;
            }

            // Sắp xếp theo tiêu chí phụ (nếu có) khi không có swap theo tiêu chí chính
            if (!isSwap)
            {
                switch (this.armorySort)
                {
                    case ArmorySort.ByName:
                        // Sắp xếp theo số lượng nếu cùng tên
                        if (currentProfile.keyName == nextProfile.keyName)
                        {
                            int currentLevel = currentWeapon.level;
                            int nextLevel = nextWeapon.level;
                            isSwap = currentLevel < nextLevel;
                        }
                        break;
                    case ArmorySort.ByLevel:
                        // Sắp xếp theo tên nếu cùng level
                        if (currentWeapon.level == nextWeapon.level)
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

    public void AddItem() => this.ShowItems();

    public void DeductItem() => this.ShowItems();

    public void UpgradeItem()
    {
        this.ShowItems();
        UIArmoryDetail.Instance.SetDetail(UIArmoryDetail.Instance.Weapon);
    }

    public void DecomposeItem()
    {
        this.ShowItems();
        UIArmoryDetail.Instance.ClearDetail();
    }

    public void UnfocusAll()
    {
        foreach (Transform item in itemSpawner.Content)
        {
            UIItemArmory uiItem = item.GetComponent<UIItemArmory>();
            if (uiItem == null) return;
            uiItem.UnfocusItem();
        }
    }
}
