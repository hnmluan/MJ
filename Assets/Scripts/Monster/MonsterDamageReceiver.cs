using System.Collections;
using UnityEngine;

public class MonsterDamageReceiver : DamageReceiver
{
    [Header("Monster")]

    [SerializeField] protected MonsterCtrl monsterCtrl;

    [Header("Blood Loss Effect")]

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

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.OnDeadDrop();
        this.monsterCtrl.MonsterDespawn.DespawnObject();
    }

    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.monsterCtrl.EnemySO.dropList, dropPos, dropRot);
    }

    protected virtual void OnDeadFX() { }

    public override void Reborn()
    {
        monsterCtrl.Model.enabled = true;
        this.hpMax = this.monsterCtrl.EnemySO.hpMax;
        base.Reborn();
        UpdateHeathBar();
    }

    public override void Deduct(int deduct)
    {
        base.Deduct(deduct);
        PlayBloodLossEffect();
        UpdateHeathBar();
        AudioController.Instance.PlayVFX("sfx_loss_hp");
    }

    private void UpdateHeathBar() => monsterCtrl.HeathBar.value = (hp / hpMax);

    private void PlayBloodLossEffect() { if (hp != 0 && monsterCtrl.Model != null) StartCoroutine(BloodLossEffect()); }

    private IEnumerator BloodLossEffect()
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
