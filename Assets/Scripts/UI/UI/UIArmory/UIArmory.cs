using Assets.SimpleLocalization;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class UIArmory : BaseUI
{
    [Header("UI Armory")]
    private static UIArmory instance;
    public static UIArmory Instance => instance;

    [SerializeField] protected ArmorySort armorySort = ArmorySort.ByName;

    [SerializeField] protected WeaponType armoryFilter = WeaponType.NoType;

    [SerializeField] public int currentItemArmory = -1;

    [Header("Armory Weapon Spawner")]

    [SerializeField] protected Transform content;
    public Transform Content => content;

    protected override void Awake()
    {
        base.Awake();
        if (UIArmory.instance != null) Debug.LogError("Only 1 UIArmory allow to exist");
        UIArmory.instance = this;
    }

    protected override void OnEnable()
    {
        ClearFocusItem();
        currentItemArmory = -1;
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadContent();
    }

    protected virtual void LoadContent()
    {
        if (this.content != null) return;
        this.content = transform.Find("Scroll View").Find("Viewport").Find("Content");
        Debug.Log(transform.name + ": LoadContent", gameObject);
    }

    public override void Open()
    {
        base.Open();
        ShowWeapons();
    }

    public void SetArmorySort(ArmorySort armorySort)
    {
        this.armorySort = armorySort;
        this.ShowWeapons();
    }

    public void SetArmoryFilter(WeaponType armoryFilter)
    {
        this.armoryFilter = armoryFilter;
        this.ShowWeapons();
    }

    public virtual void SetCurrentItemInventory(int currentItemArmory) => this.currentItemArmory = currentItemArmory;

    public void ClearFocusItem()
    {
        foreach (UIItemArmory item in GetListUIItemArmory()) item.Focus.gameObject.SetActive(false);
    }

    public void KeepFocusInCurrentItemArmory()
    {
        ClearFocusItem();
        try
        {
            if (currentItemArmory == -1) return;
            GetListUIItemArmory()[currentItemArmory].Focus.gameObject.SetActive(true);
            UIArmoryDetail.Instance.SetUIArmoryDetail(GetListUIItemArmory()[currentItemArmory].Weapon);
        }
        catch (System.Exception)
        {
            currentItemArmory = -1;
        }
    }

    public List<UIItemArmory> GetListUIItemArmory()
    {
        List<UIItemArmory> list = new List<UIItemArmory>();

        int itemCount = content.childCount;

        for (int i = 0; i < itemCount; i++)
        {
            Transform currentItem = content.GetChild(i);

            if (currentItem.gameObject.activeSelf == true)
            {
                UIItemArmory currentUIItem = currentItem.GetComponent<UIItemArmory>();

                list.Add(currentUIItem);
            }
        }
        return list;
    }

    public int GetIndexItemInventory(Weapon weapon)
    {
        int itemCount = GetListUIItemArmory().Count;

        for (int i = 0; i < itemCount; i++) if (GetListUIItemArmory()[i].Weapon == weapon) return i;

        return -1;
    }

    public void ShowWeapons()
    {
        this.ClearWeapons();

        List<Weapon> weapons = Armory.Instance.Weapons;

        weapons = armoryFilter == WeaponType.NoType ? weapons : weapons.Where(item => item.weaponProfile.damageObjectType == armoryFilter).ToList();

        foreach (Weapon weapon in weapons) UIArmoryItemSpawner.Instance.SpawnWeapon(weapon);

        this.SortItems();
    }

    protected virtual void ClearWeapons() => UIArmoryItemSpawner.Instance.ClearWeapons();

    protected virtual void SortItems()
    {
        if (this.armorySort == ArmorySort.NoSort) return;

        int itemCount = content.childCount;
        bool isSorting = false;

        for (int i = 0; i < itemCount - 1; i++)
        {
            Transform currentItem = content.GetChild(i);
            Transform nextItem = content.GetChild(i + 1);

            UIItemArmory currentUIItem = currentItem.GetComponent<UIItemArmory>();
            UIItemArmory nextUIItem = nextItem.GetComponent<UIItemArmory>();

            Weapon currentWeapon = currentUIItem.Weapon;
            Weapon nextWeapon = nextUIItem.Weapon;

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
}
