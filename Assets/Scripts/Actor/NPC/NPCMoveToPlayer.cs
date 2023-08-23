using UnityEngine;

public class NPCMoveToPlayer : ObjMoveToPlayer
{
    [SerializeField] protected NPCCtrl npcCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadNPCCtrl();
    }

    protected virtual void LoadNPCCtrl()
    {
        if (npcCtrl != null) return;
        npcCtrl = transform.parent.GetComponent<NPCCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }

    protected override void Update()
    {
        SetAnimation();
        base.Update();
    }

    private void SetAnimation()
    {
        npcCtrl.Animator.SetFloat("X", direction.x);
        npcCtrl.Animator.SetFloat("Y", direction.y);
        npcCtrl.Animator.SetBool("isWalking", !this.isTouchTagret);
    }
}
