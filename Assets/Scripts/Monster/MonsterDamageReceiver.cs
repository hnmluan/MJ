using System.Collections;
using UnityEngine;

public class MonsterDamageReceiver : DamageReceiver
{
    [Header("Monster")]

    [SerializeField] protected MonsterCtrl monsterCtrl;

    [Header("Blood Loss Animation")]

    [SerializeField] protected int blinkCount = 3;

    [SerializeField] protected float blinkDuration = 0.1f;

    [SerializeField] protected float blinkInterval = 0.1f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadMonsterCtrl();
    }

    protected virtual void LoadMonsterCtrl()
    {
        if (this.monsterCtrl != null) return;
        this.monsterCtrl = transform.parent.GetComponent<MonsterCtrl>();
        Debug.Log(transform.name + ": LoadAnimalCtrl", gameObject);
    }

    protected override void OnDead() => this.monsterCtrl.MonsterDespawn.DespawnObject();

    public override void Deduct(int deduct)
    {
        base.Deduct(deduct);
        PlayBloodLossAnimation();
    }

    private void PlayBloodLossAnimation()
    {
        if (monsterCtrl.Model == null) return;
        StartCoroutine(BloodLossAnimation());
    }

    private IEnumerator BloodLossAnimation()
    {
        for (int i = 0; i < blinkCount; i++)
        {
            monsterCtrl.Model.enabled = true;

            yield return new WaitForSeconds(blinkDuration);

            monsterCtrl.Model.enabled = false;

            yield return new WaitForSeconds(blinkInterval);
        }

        monsterCtrl.Model.enabled = true;
    }
}
