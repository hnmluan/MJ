using UnityEngine;

public class MonsterChasePlayer : ChasePlayer
{
    [SerializeField] protected MonsterCtrl monsterCtrl;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        LoadMonsterCtrl();
    }

    protected virtual void LoadMonsterCtrl()
    {
        if (monsterCtrl != null) return;
        monsterCtrl = transform.parent.GetComponent<MonsterCtrl>();
        Debug.Log(transform.name + ": LoadPlayerCtrl", gameObject);
    }

    protected override void Update()
    {
        base.Update();
        SetAnimation(moveDirection);
    }

    private void SetAnimation(Vector3 moveDirection)
    {
        float x = moveDirection.x;
        float y = moveDirection.y;

        monsterCtrl.Animator.SetFloat("X", x);
        monsterCtrl.Animator.SetFloat("Y", y);
        monsterCtrl.Animator.SetBool("isWalking", this.isMoving);
    }

}
