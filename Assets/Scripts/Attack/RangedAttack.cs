using UnityEngine;

public abstract class RangedAttack : Attack
{
    protected override void PlayAttack() => DOSpawner.Instance.Spawn(damageObjectName, transform.position, GetQuatanion());

    protected abstract Quaternion GetQuatanion();
}
