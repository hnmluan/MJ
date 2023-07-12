using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("Enemy")]
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadEnemyCtrl", gameObject);
    }

    protected override void OnDead()
    {
        this.enemyCtrl.EnemyDespawn.DespawnObject();
    }

    public override void Deduct(int deduct)
    {
        base.Deduct(deduct);
        enemyCtrl.HPBarSprite.value = (hp / hpMax);
        enemyCtrl.HealthBlink.StartBinkCoroutine(enemyCtrl.EnemySprite);
    }
}
