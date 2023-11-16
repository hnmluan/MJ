using Pathfinding;
using UnityEngine;

[RequireComponent(typeof(Seeker))]
public class ObjMoveToTagertWithOutline : ObjMoveToTagert
{
    public float nonMovableRange;
    /*    protected override void MoveToTarget()
        {
            if (Vector3.Distance(transform.position, target.position) <= nonMovableRange) return;
            base.MoveToTarget();
        }*/
}
