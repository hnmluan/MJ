﻿using UnityEngine;

public abstract class ObjAttack : InitMonoBehaviour
{
    [SerializeField] protected WeaponCode damageObject;

    [SerializeField] protected int level;

    [SerializeField] protected bool isAttacking = false;

    [SerializeField] protected float attackDelay = 0.2f;

    [SerializeField] protected float attackTimer = 0f;

    void Update() => this.IsAttacking();

    private void FixedUpdate() => this.Attacking();

    protected virtual void Attacking()
    {
        this.attackTimer += Time.fixedDeltaTime;

        if (!this.isAttacking) return;

        WeaponDataSO weaponData = WeaponDataSO.FindByCode(this.damageObject);

        if (weaponData == null) return;

        attackDelay = WeaponDataSO.FindByCode(damageObject).attackRate;

        if (this.attackTimer < attackDelay) return;

        this.attackTimer = 0;

        SpawnDamageObject();
    }

    protected virtual void SpawnDamageObject()
    {
        Transform damageObject = DOSpawner.Instance.Spawn(
            this.damageObject.ToString(),
            transform.position,
            GetRotation());

        if (damageObject == null) return;
        DOCtrl doCtrl = damageObject.GetComponent<DOCtrl>();
        doCtrl.SetLevel(level);

        damageObject.gameObject.SetActive(true);
        doCtrl.SetAttacker(transform.parent.tag);
    }

    protected abstract bool IsAttacking();

    protected abstract Quaternion GetRotation();
}