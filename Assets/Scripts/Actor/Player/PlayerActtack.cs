public class PlayerActtack : ObjAttackByMouse, IObservationArmory
{
    protected override void Update()
    {
        if (InputManager.Instance.FocusFirstWeapon()) Armory.Instance.FocusItem(1);
        if (InputManager.Instance.FocusSecondWeapon()) Armory.Instance.FocusItem(2);
        if (InputManager.Instance.FocusThirdWeapon()) Armory.Instance.FocusItem(3);

        base.Update();
    }

    protected override void Start()
    {
        this.SetWeapon(Armory.Instance.GetFocusEquippedWeapon().weapon);
        Armory.Instance.AddObservation(this);
    }

    public void AddItem() => this.SetWeapon(Armory.Instance.GetFocusEquippedWeapon().weapon);

    public void DeductItem() => this.SetWeapon(Armory.Instance.GetFocusEquippedWeapon().weapon);

    public void UpgradeItem(bool isUpgradeSuccessful) => this.SetWeapon(Armory.Instance.GetFocusEquippedWeapon().weapon);

    public void DecomposeItem() => this.SetWeapon(Armory.Instance.GetFocusEquippedWeapon().weapon);

    public void EquipItem(ItemArmory item, int position) => this.SetWeapon(Armory.Instance.GetFocusEquippedWeapon().weapon);

    public void UnequipItem(ItemArmory item) => this.SetWeapon(Armory.Instance.GetFocusEquippedWeapon().weapon);

    public void FocusItem(int position) => this.SetWeapon(Armory.Instance.GetFocusEquippedWeapon().weapon);
}
