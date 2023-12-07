using UnityEngine;

public class HotKeyEquippedWeapon : Singleton<HotKeyEquippedWeapon>, IObservationArmory
{
    [SerializeField] protected UIHotKeyWeapon weapon1;
    public UIHotKeyWeapon Weapon1 => weapon1;

    [SerializeField] protected UIHotKeyWeapon weapon2;
    public UIHotKeyWeapon Weapon2 => weapon2;

    [SerializeField] protected UIHotKeyWeapon weapon3;
    public UIHotKeyWeapon Weapon3 => weapon3;

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
        this.LoadHotKey1();
        this.LoadHotKey2();
        this.LoadHotKey3();
    }

    protected virtual void LoadHotKey1()
    {
        if (this.weapon1 != null) return;
        this.weapon1 = transform.Find("HotKey1").GetComponent<UIHotKeyWeapon>();
        weapon1.SetPosition(1);
        Debug.Log(transform.name + ": LoadWeapon1", gameObject);
    }

    protected virtual void LoadHotKey2()
    {
        this.weapon2 = transform.Find("HotKey2").GetComponent<UIHotKeyWeapon>();
        weapon2.SetPosition(2);
        Debug.Log(transform.name + ": LoadWeapon2", gameObject);
    }

    protected virtual void LoadHotKey3()
    {
        if (this.weapon3 != null) return;
        this.weapon3 = transform.Find("HotKey3").GetComponent<UIHotKeyWeapon>();
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
        Weapon1.SetEquipMode(true);
        Weapon2.SetEquipMode(true);
        Weapon3.SetEquipMode(true);
    }

    public void AddItem() => this.Show();

    public void DeductItem() => this.Show();

    public void UpgradeItem(bool isUpgradeSuccessful) => this.Show();

    public void DecomposeItem() => this.Show();

    public void EquipItem(ItemArmory item, int position) => this.Show();

    public void FocusItem(int position) => this.Show();

    public void UnequipItem(ItemArmory item) => this.Show();
}
