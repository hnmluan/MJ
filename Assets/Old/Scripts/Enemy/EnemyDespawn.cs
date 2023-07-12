using UnityEngine;

public class EnemyDespawn : MonoBehaviour
{
    public void DespawnObject()
    {
        EnemySpawner.Instance.Despawn(transform.parent);
        SoundController.Instance.PlayVFX("sfx_enemy_dead");
    }
}
