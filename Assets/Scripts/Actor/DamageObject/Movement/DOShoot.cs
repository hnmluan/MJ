using UnityEngine;

public class DOShoot : DOMovement
{
    [SerializeField] protected float movespeed;

    [SerializeField] protected Vector3 direction = Vector3.right;

    protected override void Move() => transform.parent.Translate(this.direction * this.movespeed * Time.deltaTime);

    public override void ResetMotionParameters()
    {
        base.ResetMotionParameters();
        this.movespeed = damageObjectCtrl.Data.speed;
    }
}
