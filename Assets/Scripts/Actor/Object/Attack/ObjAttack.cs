using UnityEngine;


public abstract class ObjAttack : InitMonoBehaviour
{
    [SerializeField] protected WeaponCode damageObject;

    [SerializeField] protected int level;

    [SerializeField] protected bool isAttacking = false;

    [SerializeField] protected float attackDelay = 0.2f;

    [SerializeField] protected float attackTimer = 0f;

    protected virtual void Update() => this.IsAttacking();

    protected virtual void FixedUpdate() => this.Attacking();

    protected virtual void Attacking()
    {
        if (damageObject == WeaponCode.NoWeapon) return;

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
        Transform damageObject = DOSpawner.Instance.Spawn(this.damageObject.ToString(), transform.position, GetRotation());

        if (damageObject == null) return;

        DOCtrl doCtrl = damageObject.GetComponent<DOCtrl>();

        doCtrl.InitDamageObject(level, transform.parent.tag);

        damageObject.gameObject.SetActive(true);
    }

    protected abstract bool IsAttacking();

    protected abstract Quaternion GetRotation();

    public void SetWeapon(Weapon weapon)
    {
        if (weapon == null)
        {
            this.damageObject = WeaponCode.NoWeapon;
            this.level = 0;
        }
        else
        {
            this.damageObject = weapon.dataSO.damageObjectCode;
            this.level = weapon.level;
        }
    }
}