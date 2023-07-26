using UnityEngine;

public class EnemyMoveFree : MoveFree
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
        Debug.Log(transform.name + ": LoadAnimalCtrl", gameObject);
    }

    protected override void Update()
    {
        base.Update();
        SetAnimation();
    }

    private void SetAnimation()
    {
        float x = moveDirection.x;
        float y = moveDirection.y;

        enemyCtrl.Animator.SetFloat("X", x);
        enemyCtrl.Animator.SetFloat("Y", y);
        enemyCtrl.Animator.SetBool("isWalking", this.isMoving);
    }

}
