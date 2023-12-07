using UnityEngine;

public class HotKeyEquippedWeapon : Singleton<HotKeyEquippedWeapon>, IObservationArmory
{
    [SerializeField] protected UIEquippedWeapon weapon1;
    public UIEquippedWeapon Weapon1 => weapon1;

    [SerializeField] protected UIEquippedWeapon weapon2;
    public UIEquippedWeapon Weapon2 => weapon2;

    [SerializeField] protected UIEquippedWeapon weapon3;
    public UIEquippedWeapon Weapon3 => weapon3;

    protected override void Awake()
    {
        base.Awake();
        Armory.Instance.AddObservation(this);
    }

    protected override void Start()
    {
        base.Start();
        this.Show();
    }

    protected override void LoadComponents()
    {
        this.LoadWeapon1();
        this.LoadWeapon2();
        this.LoadWeapon3();
    }

    protected virtual void LoadWeapon1()
    {
        if (this.weapon1 != null) return;
        this.weapon1 = transform.Find("Weapon_1").GetComponent<UIEquippedWeapon>();
        weapon1.SetPosition(1);
        Debug.Log(transform.name + ": LoadWeapon1", gameObject);
    }

    protected virtual void LoadWeapon2()
    {
        this.weapon2 = transform.Find("Weapon_2").GetComponent<UIEquippedWeapon>();
        weapon2.SetPosition(2);
        Debug.Log(transform.name + ": LoadWeapon2", gameObject);
    }

    protected virtual void LoadWeapon3()
    {
        if (this.weapon3 != null) return;
        this.weapon3 = transform.Find("Weapon_3").GetComponent<UIEquippedWeapon>();
        weapon3.SetPosition(3);
        Debug.Log(transform.name + ": LoadWeapon3", gameObject);
    }

    public void Show()
    {
        Weapon1.Show(Armory.Instance.GetEquippedWeapon(1));
        Weapon2.Show(Armory.Instance.GetEquippedWeapon(2));
        Weapon3.Show(Armory.Instance.GetEquippedWeapon(3));
    }

    public void ActiveEquipMode()
    {
        Weapon1.EquipMode(true);
        Weapon2.EquipMode(true);
        Weapon3.EquipMode(true);
    }

    public void AddItem() => this.Show();

    public void DeductItem() => this.Show();

    public void UpgradeItem(bool isUpgradeSuccessful) => this.Show();

    public void DecomposeItem() => this.Show();

    public void EquipItem(ItemArmory item, int position) => this.Show();

    public void FocusItem(int position) => this.Show();

    public void UnequipItem(ItemArmory item) => this.Show();
}
