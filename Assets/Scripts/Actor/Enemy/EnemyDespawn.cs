using UnityEngine;

public class EnemyDespawn : MonoBehaviour
{
    public void DespawnObject() => EnemySpawner.Instance.Despawn(transform.parent);
}
