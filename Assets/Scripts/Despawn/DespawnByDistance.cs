using UnityEngine;

public class DespawnByDistance : Despawn
{
    [SerializeField] protected float disLimit;
    [SerializeField] protected float distance;
    [SerializeField] protected Vector3 root;

    protected override bool CanDespawn()
    {
        this.distance = Vector3.Distance(transform.position, root);
        if (this.distance > this.disLimit) return true;
        return false;
    }
}