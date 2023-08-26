using System.Collections.Generic;
using UnityEngine;

public abstract class ObjAttack : InitMonoBehaviour
{
    [SerializeField] protected WeaponCode damageObject = WeaponCode.NoWeapon;

    [SerializeField] protected bool isAttacking = false;

    [SerializeField] protected float attackDelay = 0.2f;

    [SerializeField] protected float attackTimer = 0f;

    [SerializeField] protected List<IObjAttackObserver> observers = new List<IObjAttackObserver>();

    void Update() => this.IsAttacking();

    private void FixedUpdate() => this.Attacking();

    protected virtual void Attacking()
    {
        this.attackTimer += Time.fixedDeltaTime;

        if (!this.isAttacking)
        {
            this.OnWithoutAttack();
            return;
        }

        if (GetDamageObjectSO() == null) return;
        attackDelay = GetDamageObjectSO().attackRate;
        if (this.attackTimer < attackDelay) return;
        this.attackTimer = 0;

        this.OnAttacking();

        SpawnDamageObject();
    }

    private void SpawnDamageObject()
    {
        Vector3 spawnPos = transform.position;
        Quaternion rotation = transform.parent.rotation;
        Transform damageObject = DOSpawner.Instance.Spawn(this.damageObject.ToString(), spawnPos, GetRotation());
        if (damageObject == null) return;

        damageObject.gameObject.SetActive(true);
        DOCtrl doCtrl = damageObject.GetComponent<DOCtrl>();
        doCtrl.SetAttacker(transform.parent);
    }

    public WeaponDataSO GetDamageObjectSO()
    {
        string resPath = "DamageObject/ScriptableObject/" + this.damageObject.ToString();
        return Resources.Load<WeaponDataSO>(resPath);
    }

    protected abstract bool IsAttacking();

    protected abstract Quaternion GetRotation();

    public virtual void AddObserver(IObjAttackObserver observer) => this.observers.Add(observer);

    protected virtual void OnAttacking()
    {
        foreach (IObjAttackObserver observer in this.observers) observer.OnAttacking();
    }

    protected virtual void OnWithoutAttack()
    {
        foreach (IObjAttackObserver observer in this.observers) observer.OnWithoutAttack();
    }
}