using UnityEngine;

public class InventoryAbstract : InitMonoBehaviour
{
    [Header("Inventory Abstract")]
    [SerializeField] protected Inventory inventory;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadInventory();
    }

    protected virtual void LoadInventory()
    {
        if (this.inventory != null) return;
        this.inventory = transform.parent.GetComponent<Inventory>();
        Debug.LogWarning(transform.name + " LoadInventory", gameObject);
    }
}
