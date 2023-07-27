using UnityEngine;

public class DOShoot : DOMovement
{
    [SerializeField] protected float movespeed;

    [SerializeField] protected Vector3 direction = Vector3.right;

    protected override void ResetValue() => movespeed = damageObjectCtrl.DamageObjectSO.speed;

    protected override void Move() => transform.parent.Translate(this.direction * this.movespeed * Time.deltaTime);
}
