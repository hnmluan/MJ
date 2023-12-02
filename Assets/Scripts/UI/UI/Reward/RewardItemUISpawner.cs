using UnityEngine;

public class RewardItemUISpawner : Spawner
{
    private static RewardItemUISpawner instance;
    public static RewardItemUISpawner Instance => instance;

    public static string rewardItemUI = "RewardItemUI";

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

    public virtual void ClearRewardItemUI()
    {
        foreach (Transform weapon in this.holder) this.Despawn(weapon);
    }

    public virtual void SpawnRewardItemUI(ItemCode itemCode, int quantity)
    {
        Transform uiWeapon = this.Spawn(RewardItemUISpawner.rewardItemUI, Vector3.zero, Quaternion.identity);
        uiWeapon.transform.localScale = new Vector3(1, 1, 1);

        RewardItemUI uiRecipeUpdateLevel = uiWeapon.GetComponent<RewardItemUI>();
        uiRecipeUpdateLevel.ShowItem(itemCode, quantity);

        uiWeapon.gameObject.SetActive(true);
    }
}
