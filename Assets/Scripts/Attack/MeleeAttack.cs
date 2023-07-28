using UnityEngine;

public abstract class MeleeAttack : Attack
{

    [SerializeField] protected Transform damageObject;

    protected override void Update()
    {
        base.Update();
        if (damageObject == null) return;
        damageObject.position = transform.position;
    }

    protected override void PlayAttack()
    {
        damageObject = DOSpawner.Instance.Spawn(damageObjectName, transform.position, GetQuatanion());
        if (damageObject == null) return;
        damageObject.gameObject.SetActive(true);
    }

    protected abstract Quaternion GetQuatanion();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDamageObjectSO();
    }

    protected override void LoadDamageObjectSO()
    {
        if (this.damageObjectSO != null) return;
        string resPathMelee = "DamageObject/Melee/" + damageObjectName;
        this.damageObjectSO = Resources.Load<DamageObjectSO>(resPathMelee);
        Debug.Log(transform.name + ": GetDamageObjectSO " + resPathMelee, gameObject);
    }

    protected float GetTimeAttack() => damageObjectSO.attackTime;
}
