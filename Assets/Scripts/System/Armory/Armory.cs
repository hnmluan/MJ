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
        LoadData();
    }

    public void LoadData()
    {
        ArmoryData armoryData = SaveLoadHandler.LoadFromFile<ArmoryData>(FileNameData.Armory);

        if (armoryData == null)
        {
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Bow), 3));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Bow), 3));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Bow), 3));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Lance), 1));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Lance), 1));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Bow), 3));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Bow), 3));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Bow), 3));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Lance), 1));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Lance), 1));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Bow), 3));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Bow), 3));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Bow), 3));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Lance), 1));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Bow), 3));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Bow), 3));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Bow), 3));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Lance), 1));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Lance), 1));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Bow), 3));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Bow), 3));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Bow), 3));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Lance), 1));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Lance), 1));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Bow), 3));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Bow), 3));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Bow), 3));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Lance), 1));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Lance), 1));
            weapons.Add(new ItemArmory(WeaponDataSO.FindByItemCode(WeaponCode.Lance), 1));
            SaveData();
            return;
        }

        weapons = armoryData.weapons.Select(item => new ItemArmory(WeaponDataSO.FindByName(item.name), item.level)).ToList();
    }

    public void SaveData() => SaveLoadHandler.SaveToFile(FileNameData.Armory, new ArmoryData(this));

    public virtual void AddItem(WeaponCode weaponCode, int addCount, int level)
    {
        for (int i = 0; i < addCount; i++)
        {
            ItemArmory weapon = new ItemArmory(WeaponDataSO.FindByItemCode(weaponCode), level);
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
        if (!item.CanUpgrade()) return;
        item.Upgrade();
        this.ExcuteUpgradeItemObservation(item.CanUpgrade());
        this.SaveData();
    }

    public virtual void DecomposeItem(ItemArmory item)
    {
        this.ExcuteDecomposeItemObservation();
        item.Decompose();
        this.SaveData();
    }

    public void AddObservation(IObservationArmory observation) => observations.Add(observation);

    public void RemoveObservation(IObservationArmory observation) => observations.Remove(observation);

    public void ExcuteDeductItemObservation() { foreach (IObservationArmory observation in observations) observation.DeductItem(); }

    public void ExcuteAddItemsObservation() { foreach (IObservationArmory observation in observations) observation.AddItem(); }

    public void ExcuteUpgradeItemObservation(bool canUpgrade) { foreach (IObservationArmory observation in observations) observation.UpgradeItem(canUpgrade); }

    public void ExcuteDecomposeItemObservation() { foreach (IObservationArmory observation in observations) observation.DecomposeItem(); }
}
