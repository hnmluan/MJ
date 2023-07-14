using UnityEngine;

public class DespawnByTime : Despawn
{
    [SerializeField] protected float despawnTime = 4f;

    protected float timer = 0f;

    protected override void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (!CanDespawn()) return;
        DespawnObject();
        timer = 0f;
    }

    protected override bool CanDespawn() => timer >= despawnTime;
}
