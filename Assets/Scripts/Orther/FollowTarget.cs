using UnityEngine;

public class FollowTarget : InitMonoBehaviour
{

    [SerializeField] protected Transform target;
    [SerializeField] protected float speed = 2f;

    protected virtual void FixedUpdate() => this.Following();

    protected virtual void Following()
    {
        if (this.target == null) return;
        transform.position = Vector3.Lerp(transform.position, this.target.position, Time.fixedDeltaTime * this.speed);
        //  transform.position = this.target.position;
    }

    public virtual void SetTarget(Transform target) => this.target = target;
}
