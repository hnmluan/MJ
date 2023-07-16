using UnityEngine;

public class MonsterDespawn : MonoBehaviour
{
    public void DespawnObject()
    {
        MonsterSpawner.Instance.Despawn(transform.parent);
        //SoundController.Instance.PlayVFX("sfx_enemy_dead");
    }
}
