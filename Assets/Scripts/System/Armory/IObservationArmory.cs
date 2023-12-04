public interface IObservationArmory
{
    void AddItem();

    void DeductItem();

    void UpgradeItem(bool isUpgradeSuccessful);

    void DecomposeItem();
}
