using UnityEngine;

public class AttackByDistance : Attack
{
    [Header("Attack by Distance")]

    [SerializeField] protected Transform target;

    [SerializeField] protected float distance = Mathf.Infinity;

    [SerializeField] protected float rangeAttack = 3f;

    [SerializeField] protected Quaternion rotation;

    public virtual void SetTarget(Transform target) => this.target = target;

    protected override Quaternion GetRotation()
    {
        Vector3 direction = target.position - transform.parent.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        //Debug.Log(", direction = " + direction + ", angleRadians = " + ", rotation = " + rotation);
        return Quaternion.AngleAxis(angle, Vector3.forward);
    }

    protected override bool IsAttacking()
    {
        this.distance = Vector3.Distance(transform.position, this.target.position);
        this.isAttacking = this.distance < this.rangeAttack && target != null;
        return this.isAttacking;
    }
}
