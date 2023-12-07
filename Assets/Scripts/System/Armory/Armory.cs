using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[Serializable]
public class Armory : Singleton<Armory>
{
    List<IObservationArmory> observations = new List<IObservationArmory>();

    [SerializeField] protected List<ItemArmory> weapons;
    public List<ItemArmory> Weapons => weapons;

    public static float ratioDecompose = 1f;

    protected override void Awake()
    {
        base.Awake();
        this.LoadData();
    }

    protected void LoadData()
    {
        ArmoryData armoryData = SaveLoadHandler.LoadFromFile<ArmoryData>(FileNameData.Armory);

        if (armoryData == null)
        {
            weapons.Add(new ItemArmory(WeaponDataSO.FindByCode(WeaponCode.Bow), 2));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByCode(WeaponCode.Bow), 1));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByCode(WeaponCode.Lance), 1));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByCode(WeaponCode.Lance), 2));

            SaveData();
            return;
        }

        armoryData.weapons.ForEach(item => this.weapons.Add(new ItemArmory(item)));
    }

    protected void SaveData() => SaveLoadHandler.SaveToFile(FileNameData.Armory, new ArmoryData(this));

    public ItemArmory GetEquippedWeapon(int position) => weapons.FirstOrDefault(weapon => weapon.position == position);

    public ItemArmory GetFocusEquippedWeapon() => weapons.FirstOrDefault(weapon => weapon.isFocus == true);

    public virtual void AddItem(WeaponCode weaponCode, int addCount, int level)
    {
        for (int i = 0; i < addCount; i++)
        {
            ItemArmory weapon = new ItemArmory(WeaponDataSO.FindByCode(weaponCode), level);
            weapons.Add(weapon);
        }
        this.SaveData();
        this.ExcuteAddItemsObservation();
    }

    public virtual void DeductItem(ItemArmory weapon)
    {
        this.weapons.Remove(weapon);
        this.SaveData();
        this.ExcuteDeductItemObservation();
    }

    public virtual void UpgradeItem(ItemArmory item)
    {
        this.ExcuteUpgradeItemObservation(item.Upgrade());
        this.SaveData();
    }

    public virtual void DecomposeItem(ItemArmory item)
    {
        this.ExcuteDecomposeItemObservation();
        item.Decompose();
        this.SaveData();
    }

    public virtual void EquipItem(ItemArmory item, int position)
    {
        if (GetEquippedWeapon(position) != null) this.GetEquippedWeapon(position).position = 0;
        item.position = position;
        this.ExcuteEquipItemObservation(item, position);
        this.SaveData();
    }

    public virtual void UnequipItem(ItemArmory item)
    {
        item.position = 0;
        item.isFocus = false;
        this.ExcuteUnequipItemObservation(item);
        this.SaveData();
    }

    public virtual void FocusItem(int position)
    {
        ItemArmory item = GetEquippedWeapon(position);
        if (item == null) return;
        weapons.ForEach(item => item.isFocus = false);
        item.isFocus = true;
        this.ExcuteFocusItemObservation(position);
        this.SaveData();
    }

    public void AddObservation(IObservationArmory observation) => observations.Add(observation);

    public void RemoveObservation(IObservationArmory observation) => observations.Remove(observation);

    public void ExcuteDeductItemObservation() { foreach (IObservationArmory observation in observations) observation.DeductItem(); }

    public void ExcuteAddItemsObservation() { foreach (IObservationArmory observation in observations) observation.AddItem(); }

    public void ExcuteUpgradeItemObservation(bool isUpgradeSuccessful) { foreach (IObservationArmory observation in observations) observation.UpgradeItem(isUpgradeSuccessful); }

    public void ExcuteDecomposeItemObservation() { foreach (IObservationArmory observation in observations) observation.DecomposeItem(); }

    public void ExcuteEquipItemObservation(ItemArmory item, int position) { foreach (IObservationArmory observation in observations) observation.EquipItem(item, position); }

    public void ExcuteUnequipItemObservation(ItemArmory item) { foreach (IObservationArmory observation in observations) observation.UnequipItem(item); }

    public void ExcuteFocusItemObservation(int position) { foreach (IObservationArmory observation in observations) observation.FocusItem(position); }
}
