using UnityEngine;

public class RewardItemUISpawner : Spawner
{
    private static RewardItemUISpawner instance;
    public static RewardItemUISpawner Instance => instance;

    public static string item = "Item";

    protected override void Awake()
    {
        base.Awake();
        if (RewardItemUISpawner.instance != null) Debug.Log("Only 1 RewardItemUISpawner allow to exist");
        RewardItemUISpawner.instance = this;
    }
    protected override void LoadHolder()
    {
        if (this.holder != null) return;
        this.holder = this.transform.parent;
        Debug.LogWarning(transform.name + ": LoadHodler", gameObject);
    }

    public virtual void Clear() { foreach (Transform weapon in this.holder) this.Despawn(weapon); }

    public virtual void Spawn(ItemCode itemCode, int quantity)
    {
        Transform uiWeapon = this.Spawn(RewardItemUISpawner.item, Vector3.zero, Quaternion.identity);
        uiWeapon.transform.localScale = new Vector3(1, 1, 1);

        RewardItemUI rewardItemUI = uiWeapon.GetComponent<RewardItemUI>();
        rewardItemUI.ShowItem(itemCode, quantity);

        uiWeapon.gameObject.SetActive(true);
    }

    public virtual void Spawn(WeaponCode weaponCode, int level)
    {
        Transform uiWeapon = this.Spawn(RewardItemUISpawner.item, Vector3.zero, Quaternion.identity);
        uiWeapon.transform.localScale = new Vector3(1, 1, 1);

        RewardItemUI rewardItemUI = uiWeapon.GetComponent<RewardItemUI>();
        rewardItemUI.ShowWeapon(weaponCode, level);

        uiWeapon.gameObject.SetActive(true);
    }
}
