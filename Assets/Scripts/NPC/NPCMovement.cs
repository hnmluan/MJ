using UnityEngine;

public class NPCMovement : MoveFree
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
        Debug.Log(transform.name + ": LoadNPCCtrl", gameObject);
    }

    protected override void Update()
    {
        SetAnimation();
        base.Update();
    }

    private void SetAnimation()
    {
        npcCtrl.Animator.SetFloat("X", moveDirection.x);
        npcCtrl.Animator.SetFloat("Y", moveDirection.y);
        npcCtrl.Animator.SetBool("isWalking", this.isMoving);
    }
}
