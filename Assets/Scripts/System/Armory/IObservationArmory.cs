public interface IObservationArmory
{
    void AddItem();

    void DeductItem();

    void UpgradeItem(bool isUpgradeSuccessful);

    void DecomposeItem();

    void EquipItem(ItemArmory item, int position);

    void UnequipItem(ItemArmory item);

    void FocusItem(int position);
}
