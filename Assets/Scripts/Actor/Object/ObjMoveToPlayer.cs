using UnityEngine;

public class ObjMoveToPlayer : ObjMoveToTarget
{
    protected override void LoadTarget()
    {
        if (this.target != null) return;
        target = GameObject.FindWithTag("Player").transform;
        Debug.Log(transform.name + ": LoadTarget", gameObject);
    }
}