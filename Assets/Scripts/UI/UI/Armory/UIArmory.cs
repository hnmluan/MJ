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

    [SerializeField] protected ItemArmory currentItem;
    public ItemArmory CurrentItem => currentItem;

    [SerializeField] protected UIArmoryItemSpawner itemSpawner;
    public UIArmoryItemSpawner ItemSpawner => itemSpawner;

    [SerializeField] protected UIArmoryDetail uiArmoryDetail;
    public UIArmoryDetail UIArmoryDetail => uiArmoryDetail;

    [SerializeField] protected UIDecompose uiDecompose;
    public UIDecompose UIDecompose => uiDecompose;

    [SerializeField] protected ArmorySort armorySort = ArmorySort.ByName;

    [SerializeField] protected WeaponType armoryFilter = WeaponType.NoType;

    protected override void Awake()
    {
        base.Awake();
        if (UIArmory.instance != null) Debug.LogError("Only 1 UIArmory allow to exist");
        UIArmory.instance = this;
    }

    protected override void OnEnable()
    {
        this.armorySort = ArmorySort.ByName;
        this.armoryFilter = WeaponType.NoType;
        Armory.Instance.AddObservation(this);
        this.ShowItems();
        this.SetCurrentItem(null);
    }

    protected override void OnDisable() => Armory.Instance.RemoveObservation(this);

    public void SetSort(ArmorySort armorySort) { this.armorySort = armorySort; this.ShowItems(); }

    public void SetFilter(WeaponType armoryFilter) { this.armoryFilter = armoryFilter; this.ShowItems(); }

    public void ShowItems()
    {
        this.ClearItems();

        List<ItemArmory> weapons = Armory.Instance.Weapons;

        weapons = armoryFilter == WeaponType.NoType ? weapons : weapons.Where(item => item.weapon.dataSO.damageObjectType == armoryFilter).ToList();

        foreach (ItemArmory weapon in weapons) itemSpawner.Spawn(weapon);

        this.SortItems();
    }

    protected virtual void ClearItems() => itemSpawner.Clear();

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

            WeaponDataSO currentProfile = currentWeapon.weapon.dataSO;
            WeaponDataSO nextProfile = nextWeapon.weapon.dataSO;

            bool isSwap = false;

            switch (this.armorySort)
            {
                case ArmorySort.ByName:
                    string currentName = LocalizationManager.Localize(currentProfile.keyName);
                    string nextName = LocalizationManager.Localize(nextProfile.keyName);
                    isSwap = string.Compare(currentName, nextName) == 1; // Đổi từ -1 thành 1 để đảo ngược thứ tự
                    break;
                case ArmorySort.ByLevel:
                    int currentCount = currentWeapon.weapon.level;
                    int nextCount = nextWeapon.weapon.level;
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
                            int currentLevel = currentWeapon.weapon.level;
                            int nextLevel = nextWeapon.weapon.level;
                            isSwap = currentLevel < nextLevel;
                        }
                        break;
                    case ArmorySort.ByLevel:
                        // Sắp xếp theo tên nếu cùng level
                        if (currentWeapon.weapon.level == nextWeapon.weapon.level)
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

    public virtual void SetCurrentItem(ItemArmory item)
    {
        this.currentItem = item;
        uiArmoryDetail.Show();
        this.ShowItems();
    }

    public void AddItem()
    {
        this.SetCurrentItem(null);
        this.ShowItems();
    }

    public void DeductItem()
    {
        this.SetCurrentItem(null);
        this.ShowItems();
    }

    public void UpgradeItem(bool isUpgradeSuccessful)
    {
        UITextSpawner.Instance.SpawnUITextWithMousePosition(isUpgradeSuccessful
            ? LocalizationManager.Localize("Armory.Upgrade.Success")
            : LocalizationManager.Localize("Armory.Upgrade.Check"));
        if (!isUpgradeSuccessful) return;
        this.SetCurrentItem(this.currentItem);
        this.ShowItems();
    }

    public void DecomposeItem()
    {
        List<WeaponRecipeIngredient> listRecipeIngredient = currentItem.GetRecipeDecompose();

        List<ImageText> textList = listRecipeIngredient.Select(item => new ImageText
        {
            text = LocalizationManager.Localize(item.itemProfile.keyName) + "+" + item.itemCount,
            image = item.itemProfile.itemSprite
        }).ToList();

        UITextSpawner.Instance.SpawnUIImageTextWithMousePosition(textList);

        this.UIDecompose.Close();

        this.ShowItems();

        this.UIDecompose.gameObject.SetActive(false);

        this.uiArmoryDetail.Show();
    }

    public void EquipItem(ItemArmory item, int position)
    {
        this.uiArmoryDetail.Show();
        this.ShowItems();
    }

    public void FocusItem(int position)
    {
        ItemArmory itemArmory = Armory.Instance.GetEquippedWeapon(position);

        if (itemArmory == null) return;

        this.SetCurrentItem(itemArmory);
    }

    public void UnequipItem(ItemArmory item) => this.uiArmoryDetail.Show();
}
