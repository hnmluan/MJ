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

    [SerializeField] protected float dropDistance = 2f;

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
        Dictionary.Instance.AddDictionary(enemyCtrl.EnemySO);
    }

    protected virtual void OnDeadDrop()
    {
        Vector3 dropPos = transform.position;
        Quaternion dropRot = transform.rotation;
        ItemDropSpawner.Instance.Drop(this.enemyCtrl.EnemySO.dropListItem, transform.position, dropRot, dropDistance);
    }

    protected virtual void OnDeadFX() { }

    public override void Reborn()
    {
        enemyCtrl.Model.enabled = true;
        this.HPMax = this.enemyCtrl.EnemySO.hpMax;
        base.Reborn();
    }

    public override void Deduct(int deduct)
    {
        base.Deduct(deduct);
        PlayBloodLossEffect();
        AudioController.Instance.PlayVFX("sfx_loss_hp");
    }

    private void PlayBloodLossEffect() { if (HP != 0 && enemyCtrl.Model != null) StartCoroutine(BloodLossEffect()); }

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
