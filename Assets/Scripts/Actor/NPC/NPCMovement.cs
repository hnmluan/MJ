using UnityEngine;

public class NPCMovement : ObjMoveFree
{
    [SerializeField] private Animator animator;

    protected override void Update()
    {
        SetAnimation();
        base.Update();
    }

    private void SetAnimation()
    {
        animator.SetFloat("X", direction.x);
        animator.SetFloat("Y", direction.y);
        animator.SetBool("isWalking", this.isMoving);
    }
}
