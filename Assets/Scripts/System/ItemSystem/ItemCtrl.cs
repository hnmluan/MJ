using UnityEngine;

public class ItemCtrl : InitMonoBehaviour
{
    [SerializeField] protected ItemDespawn itemDespawn;
    public ItemDespawn ItemDespawn => itemDespawn;

    [SerializeField] protected ItemInventory itemInventory;
    public ItemInventory ItemInventory => itemInventory;

    [SerializeField] protected SpriteRenderer itemSR;
    public SpriteRenderer ItemSR => itemSR;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadItemDespawn();
        this.LoadItemInventory();
        this.LoadItemSR();
    }

    protected virtual void LoadItemSR()
    {
        if (this.itemSR != null) return;
        this.itemSR = transform.Find("Model").GetComponentInChildren<SpriteRenderer>();
        Debug.Log(transform.name + ": LoadItemSR", gameObject);
    }

    protected virtual void LoadItemDespawn()
    {
        if (this.itemDespawn != null) return;
        this.itemDespawn = transform.GetComponentInChildren<ItemDespawn>();
        Debug.Log(transform.name + ": LoadItemDespawn", gameObject);
    }

    public virtual void SetItemInventory(ItemInventory itemInventory) => this.itemInventory = itemInventory.Clone();

    protected virtual void LoadItemInventory()
    {
        if (this.itemInventory.itemProfile != null) return;
        ItemCode itemCode = ItemCodeParser.FromString(transform.name);
        ItemDataSO itemProfile = ItemDataSO.FindByItemCode(itemCode);
        this.itemInventory.itemProfile = itemProfile;
        Debug.Log(transform.name + ": LoadItemInventory", gameObject);
    }
}
