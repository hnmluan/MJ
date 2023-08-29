﻿using UnityEngine;

public class EnemyMoveFree : ObjMoveFree
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

    protected void FixUpdate() => SetAnimation();

    private void SetAnimation()
    {
        float x = direction.x;
        float y = direction.y;

        enemyCtrl.Animator.SetFloat("X", x);
        enemyCtrl.Animator.SetFloat("Y", y);
        enemyCtrl.Animator.SetBool("isWalking", this.isMoving);
    }

}