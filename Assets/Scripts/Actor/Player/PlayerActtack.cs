public class PlayerActtack : ObjAttackByMouse, IObservationArmory
{
    /*    protected override void Update()
        {
            if (InputManager.Instance.FocusFirstWeapon()) Armory.Instance.FocusItem(1);
            if (InputManager.Instance.FocusSecondWeapon()) Armory.Instance.FocusItem(2);
            if (InputManager.Instance.FocusThirdWeapon()) Armory.Instance.FocusItem(3);

            base.Update();
        }*/

    protected override void Awake() => Armory.Instance.AddObservation(this);

    protected override void Start() => SetWeapon(this.GetWeapon());

    public void AddItem() => SetWeapon(this.GetWeapon());

    public void DeductItem() => SetWeapon(this.GetWeapon());

    public void UpgradeItem(bool isUpgradeSuccessful) => SetWeapon(this.GetWeapon());

    public void DecomposeItem() => SetWeapon(this.GetWeapon());

    public void EquipItem(ItemArmory item, int position) => SetWeapon(this.GetWeapon());

    public void UnequipItem(ItemArmory item) => SetWeapon(this.GetWeapon());

    public void FocusItem(int position) => SetWeapon(this.GetWeapon());

    protected Weapon GetWeapon()
    {
        if (Armory.Instance.GetFocusEquippedWeapon() == null) return null;
        if (Armory.Instance.GetFocusEquippedWeapon().weapon == null) return null;
        return Armory.Instance.GetFocusEquippedWeapon().weapon;
    }
}
