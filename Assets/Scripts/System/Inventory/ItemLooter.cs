using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(Rigidbody))]
public class ItemLooter : InitMonoBehaviour
{
    [SerializeField] protected SphereCollider _collider;

    [SerializeField] protected Rigidbody _rigidbody;

    [SerializeField] protected float lootSpeed = 5.0f;

    [SerializeField] protected float lootMinDistance = 2.0f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTrigger();
        this.LoadRigidbody();
    }

    protected virtual void LoadTrigger()
    {
        if (this._collider != null) return;
        this._collider = transform.GetComponent<SphereCollider>();
        this._collider.isTrigger = true;
        this._collider.radius = 0.3f;
        Debug.LogWarning(transform.name + " LoadTrigger", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this._rigidbody != null) return;
        this._rigidbody = transform.GetComponent<Rigidbody>();
        this._rigidbody.useGravity = false;
        this._rigidbody.isKinematic = true;
        Debug.LogWarning(transform.name + " LoadRigidbody", gameObject);
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        ItemPickupable itemPickupable = collider.GetComponent<ItemPickupable>();
        if (itemPickupable == null) return;



        ItemCode itemCode = itemPickupable.GetItemCode();
        if (Inventory.Ins.AddItem(itemCode, 1)) itemPickupable.Picked();
    }

    protected void LootItem(Transform item)
    {
        float distance = Vector3.Distance(transform.position, item.position);

        if (distance < lootMinDistance)
        {
            Vector3 dirToItem = (item.position - transform.position).normalized;
            transform.position += dirToItem * lootSpeed * Time.deltaTime;
        }
    }
}
