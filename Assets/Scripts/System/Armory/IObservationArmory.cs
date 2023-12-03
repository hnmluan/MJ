public interface IObservationArmory
{
    void AddItem();

    void DeductItem();

    void UpgradeItem(bool canUpgrade);

    void DecomposeItem();
}
