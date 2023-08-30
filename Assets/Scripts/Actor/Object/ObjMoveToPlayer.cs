using UnityEngine;

public class ObjMoveToPlayer : ObjMoveToTagert
{
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTarget();
    }

    protected void LoadTarget()
    {
        if (this.target != null) return;
        this.target = GameObject.FindGameObjectWithTag("Player").transform;
        Debug.Log(transform.name + ": LoadTarget", gameObject);
    }
}
