using System.Collections;
using UnityEngine;

public class EnemyDamageReceiver : DamageReceiver
{
    [Header("Enemy")]

    [SerializeField] protected EnemyCtrl enemyCtrl;

    [Header("Blood Loss Effect")]

    [SerializeField] protected int blinkCount = 3;

    [SerializeField] protected float blinkDuration = 0.1f;

    [SerializeField] protected float blinkInterval = 0.1f;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (this.enemyCtrl != null) return;
        this.enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadAnimalCtrl", gameObject);
    }

    protected override void OnDead()
    {
        this.OnDeadFX();
        this.OnDeadDrop();
        this.enemyCtrl.EnemyDespawn.DespawnObject();
    }

    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.enemyCtrl.EnemySO.dropListItem, dropPos, dropRot);
    }

    protected virtual void OnDeadFX() { }

    public override void Reborn()
    {
        enemyCtrl.Model.enabled = true;
        this.hpMax = this.enemyCtrl.EnemySO.hpMax;
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

    private void UpdateHeathBar() => enemyCtrl.HeathBar.value = (hp / hpMax);

    private void PlayBloodLossEffect() { if (hp != 0 && enemyCtrl.Model != null) StartCoroutine(BloodLossEffect()); }

    private IEnumerator BloodLossEffect()
    {
        for (int i = 0; i < blinkCount; i++)
        {
            enemyCtrl.Model.enabled = true;

            yield return new WaitForSeconds(blinkDuration);

            enemyCtrl.Model.enabled = false;

            yield return new WaitForSeconds(blinkInterval);
        }

        enemyCtrl.Model.enabled = true;
    }
}
