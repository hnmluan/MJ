using UnityEngine;

public class UIArmoryItemSpawner : Spawner
{
    public static string normalWeapon = "UIItem";

    [SerializeField] private Transform content;
    public Transform Content => content;

    protected override void LoadHolder() => this.holder = this.content;

    public virtual void Clear() { foreach (Transform weapon in this.holder) this.Despawn(weapon); }

    public virtual void Spawn(ItemArmory weapon)
    {
        Transform uiWeapon = this.Spawn(UIArmoryItemSpawner.normalWeapon, Vector3.zero, Quaternion.identity);
        uiWeapon.transform.localScale = new Vector3(1, 1, 1);

        UIItemArmory Weapon = uiWeapon.GetComponent<UIItemArmory>();
        Weapon.ShowWeapon(weapon);

        uiWeapon.gameObject.SetActive(true);
    }
}