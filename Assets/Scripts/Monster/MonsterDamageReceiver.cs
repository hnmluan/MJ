using UnityEngine;

public class MonsterDamageReceiver : DamageReceiver
{
    [Header("Monster")]
    [SerializeField] protected MonsterCtrl monsterCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMonsterCtrl();
    }

    protected virtual void LoadMonsterCtrl()
    {
        if (this.monsterCtrl != null) return;
        this.monsterCtrl = transform.parent.GetComponent<MonsterCtrl>();
        Debug.Log(transform.name + ": LoadMonsterCtrl", gameObject);
    }

    protected override void OnDead()
    {
        this.monsterCtrl.MonsterDespawn.DespawnObject();
    }

    public override void Deduct(int deduct)
    {
        base.Deduct(deduct);
        //monsterCtrl.HPBarSprite.value = (hp / hpMax);
        //monsterCtrl.HealthBlink.StartBinkCoroutine(monsterCtrl.EnemySprite);
    }
}
