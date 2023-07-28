using UnityEngine;

public abstract class Attack2 : InitMonoBehaviour
{
    [SerializeField] protected DamageObjectCode damageObject = DamageObjectCode.NoDamageObject;

    [SerializeField] protected bool isAttacking = false;

    [SerializeField] protected float attackDelay = 0.2f;

    [SerializeField] protected float attackTimer = 0f;

    void Update() => this.IsAttacking();

    private void FixedUpdate() => this.Attacking();

    protected virtual void Attacking()
    {
        this.attackTimer += Time.fixedDeltaTime;

        if (!this.isAttacking) return;
        if (GetDamageObjectSO() == null) return;
        attackDelay = GetDamageObjectSO().attackRate;
        if (this.attackTimer < attackDelay) return;
        this.attackTimer = 0;

        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform damageObject = DOSpawner.Instance.Spawn(this.damageObject.ToString(), spawnPos, GetRotation());
        if (damageObject == null) return;

        damageObject.gameObject.SetActive(true);
        DOCtrl doCtrl = damageObject.GetComponent<DOCtrl>();
        doCtrl.SetAttacker(transform.parent);
    }

    private DamageObjectSO GetDamageObjectSO()
    {
        string resPathMelee = "DamageObject/Melee/" + this.damageObject.ToString();
        string resPathRanged = "DamageObject/Ranged/" + this.damageObject.ToString();
        return Resources.Load<DamageObjectSO>(resPathMelee) != null ? Resources.Load<DamageObjectSO>(resPathMelee) : Resources.Load<DamageObjectSO>(resPathRanged);
    }

    protected abstract bool IsAttacking();
    protected abstract Quaternion GetRotation();
}