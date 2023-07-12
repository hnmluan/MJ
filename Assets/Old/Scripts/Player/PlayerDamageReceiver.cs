using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    [SerializeField] protected PlayerCtrl playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadPlayerCtrl();
    }


    protected virtual void LoadPlayerCtrl()
    {
        if (this.playerCtrl != null) return;
        this.playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }


    protected override void OnDead()
    {
        Debug.Log("Player Die");
    }

    public override void Deduct(int deduct)
    {
        base.Deduct(deduct);
        playerCtrl.HPBar.value = (hp / hpMax);
        playerCtrl.HealthBlink.StartBinkCoroutine(playerCtrl.PlayerSprite);
    }


}
