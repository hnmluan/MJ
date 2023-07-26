using System;
using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class ItemPickupable : ItemAbstract
{
    [Header("Item Pickupable")]
    [SerializeField] protected SphereCollider _collider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
    }

    protected virtual void LoadTrigger()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.4f;
        Debug.LogWarning(transform.name + " LoadTrigger", gameObject);
    }

    public static ItemCode String2ItemCode(string itemName)
    {
        try
        {
            return (ItemCode)System.Enum.Parse(typeof(ItemCode), itemName);
        }
        catch (ArgumentException e)
        {
            Debug.LogError(e.ToString());
            return ItemCode.NoItem;
        };
    }

    public virtual ItemCode GetItemCode() => ItemPickupable.String2ItemCode(transform.parent.name);

    public virtual void Picked() => this.ItemCtrl.ItemDespawn.DespawnObject();

    public virtual void LootTo(Vector3 tagret) => transform.parent.position = Vector3.Lerp(transform.parent.position, tagret, Time.deltaTime * 8);

}