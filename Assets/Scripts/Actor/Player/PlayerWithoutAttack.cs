using UnityEngine;

public class PlayerWithoutAttack : ObjWithoutAttack
{
    [Header("PlayerCtrl")]
    [SerializeField] protected PlayerCtrl playerCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadPlayerCtrl();
    }

    protected virtual void LoadPlayerCtrl()
    {
        if (playerCtrl != null) return;
        playerCtrl = transform.parent.GetComponent<PlayerCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }

    public override void SetDirection() => direction = new Vector2(playerCtrl.Animator.GetFloat("X"), playerCtrl.Animator.GetFloat("Y"));

    public override void SetObjAttack() => attack = playerCtrl.ObjAttack;
}
