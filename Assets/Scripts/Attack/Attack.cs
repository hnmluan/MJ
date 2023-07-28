using UnityEngine;

public abstract class Attack : InitMonoBehaviour
{
    [SerializeField] protected bool isShooting = false;
    [SerializeField] protected float shootDelay = 0.2f;
    [SerializeField] protected float shootTimer = 0f;

    [SerializeField] protected string damageObjectName;

    [SerializeField] protected DamageObjectSO damageObjectSO;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageObjectSO();
    }

    protected virtual void Update()
    {
        if (CanAttack()) PlayAttack();
    }

    protected abstract void LoadDamageObjectSO();
    protected abstract void PlayAttack();
    protected abstract bool CanAttack();
}
