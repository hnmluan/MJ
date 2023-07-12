using UnityEngine;

public class EnemyAttack : InitMonoBehaviour
{
    [SerializeField] protected float attackDelay = 2f;

    [SerializeField] protected float attackTimer;

    [SerializeField] protected GameObject target;

    [SerializeField] protected Vector3 targetDamageReciver;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTarget();
    }

    private void LoadTarget()
    {
        if (this.target != null) return;
        target = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(transform.name + ": LoadTarget", gameObject);
    }

    private void LoadTargetDamageReciver()
    {
        targetDamageReciver = target.GetComponentInChildren<DamageReceiver>().transform.position;
    }

    private void Update()
    {
        attackTimer += Time.deltaTime;

        if (attackTimer <= attackDelay) return;

        LoadTargetDamageReciver();

        Attack();

        attackTimer = 0f;
    }

    private void Attack()
    {
        Transform projectile = ProjectileSpawner.Instance.Spawn(ProjectileSpawner.projectileTwo, transform.position, Quaternion.identity);
        if (projectile == null) return;
        projectile.gameObject.SetActive(true);
        Vector3 direction = targetDamageReciver - transform.parent.position;
        direction.z = 0;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        projectile.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        SoundController.Instance.PlayVFX("sfx_fire");
    }
}
