using UnityEngine;

public class EnemyMoveToPlayer : ObjMoveToPlayer
{
    [SerializeField] protected EnemyCtrl enemyCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadEnemyCtrl();
    }

    protected virtual void LoadEnemyCtrl()
    {
        if (enemyCtrl != null) return;
        enemyCtrl = transform.parent.GetComponent<EnemyCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }

    protected override void Update()
    {
        base.Update();
        SetAnimation((transform.position - target.position).normalized);
    }

    private void SetAnimation(Vector3 moveDirection)
    {
        float x = moveDirection.x;
        float y = moveDirection.y;

        enemyCtrl.Animator.SetFloat("X", x);
        enemyCtrl.Animator.SetFloat("Y", y);
        enemyCtrl.Animator.SetBool("isWalking", this.isMoving);
    }
}
